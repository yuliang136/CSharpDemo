using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace FindRefsMulti
{
    public class FindRefWithMulti
    {
        private string m_assetPath;
        private string m_filePath;
        private List<string> m_findFilesPath;

        // 设置一个内存锁.
        private readonly object locker = new object();
        private List<Thread> lstThreads = new List<Thread>();

        public List<string> m_lstResults = new List<string>();

        // 被依赖项的文件集合
        public Stack<CustomFileInfoBeenDep> m_stackDepFileInfos = new Stack<CustomFileInfoBeenDep>();

        // 要Check的文件集合
        public Stack<CustomFileInfoCheckFile> m_stackCheckFileInfos = new Stack<CustomFileInfoCheckFile>();


        // public FindRefWithMulti(string strAssetPath, string strFilePath)
        // {
        //     m_assetPath = strAssetPath;
        //     m_filePath = strFilePath;
        // }

        public FindRefWithMulti(string strAssetPath, List<string> strFindFilesPath)
        {
            m_assetPath = strAssetPath;
            m_findFilesPath = strFindFilesPath; // 传入一个List输入
        }

        /// <summary>
        /// 自定义文件结构 文件名和文件的字符串内容 被依赖项的文件信息
        /// </summary>
        public class CustomFileInfoBeenDep
        {
            public string strFileName = string.Empty;
            public string strFileContent = string.Empty;
        }

        /// <summary>
        /// 自定义文件结构 要搜索的文件信息 也需要切割进行内容分配.
        /// </summary>
        public class CustomFileInfoCheckFile
        {
            public string strFileName = string.Empty;
            public string strGuid = string.Empty;
        }

        // 这里设计出一个类结构来保存线程处理的数据和线程的信息.
        public class ThreadHandleInfo
        {
            public string threadName = string.Empty;
            // public Dictionary<string, string> inputDepData = new Dictionary<string, string>(); // 进行任务分配.
            // public string inputGuid = string.Empty; // 输入的Guid

            public List<CustomFileInfoCheckFile> inputCheckData; // 输入Check项
            public List<CustomFileInfoBeenDep> inputDepData; // 输入被依赖项
            public List<string> outputData; // 共用的一份地址 需要加锁处理
            // public int nWaitTime;
        }


        public void TheadEachRun(object obj)
        {
            // 进行拆箱.
            ThreadHandleInfo threadHandleInfo = obj as ThreadHandleInfo;

            List<string> findResult = new List<string>();
            int nHandleCheckIndex = 0;
            // int nHandleDepIndex = 0;

            foreach (var eachCheckInfo in threadHandleInfo.inputCheckData)
            {
                // 记录处理的每一个文件
                nHandleCheckIndex++;
                // Console.WriteLine("Handle Check Index = " + nHandleCheckIndex.ToString());

                foreach (var eachDepInfo in threadHandleInfo.inputDepData)
                {
                    if (Regex.IsMatch(eachDepInfo.strFileContent, eachCheckInfo.strGuid))
                    {
                        // 这里可能应该加入更复杂的结构.
                        findResult.Add(eachDepInfo.strFileName);

                        // 进行Debug输出.
                        string strShowTmp = string.Format("{0} refs {1}", eachDepInfo.strFileName,
                            eachCheckInfo.strFileName);
                        Console.WriteLine(strShowTmp);

                    }
                }
            }


            // 把结果写入.
            lock (locker)
            {
                // 加锁来处理 其他线程会阻塞住等待.
                foreach (var eachOutput in findResult)
                {
                    threadHandleInfo.outputData.Add(eachOutput);
                }
            }

            string strShow = string.Format("Thread {0} Done", threadHandleInfo.threadName);
            Console.WriteLine(strShow);

        }

        /// <summary>
        /// 进行任务切割.
        /// </summary>
        /// <param name="allTasks"></param>
        /// <param name="bIsLastThread">判断是否是最后一个Thread 返回所有任务.</param>
        /// <returns></returns>
        public List<CustomFileInfoCheckFile> CutCheckTasks(Stack<CustomFileInfoCheckFile> allTasks, int nCutNum, bool bIsLastThread)
        {
            List<CustomFileInfoCheckFile> lstFileInfo = new List<CustomFileInfoCheckFile>();

            if (bIsLastThread)
            {
                // 如果是最后一个线程 直接把剩余的allTasks返回为lstFileInfo
                lstFileInfo = allTasks.ToList();
            }
            else
            {
                // push出的个数
                for (int i = 0; i < nCutNum; i++)
                {
                    lstFileInfo.Add(allTasks.Pop());
                }

            }

            return lstFileInfo;
        }

        /// <summary>
        /// 进行任务切割.
        /// </summary>
        /// <param name="allTasks"></param>
        /// <param name="bIsLastThread">判断是否是最后一个Thread 返回所有任务.</param>
        /// <returns></returns>
        public List<CustomFileInfoBeenDep> CutDepTasks(Stack<CustomFileInfoBeenDep> allTasks, int nCutNum, bool bIsLastThread)
        {
            List<CustomFileInfoBeenDep> lstFileInfo = new List<CustomFileInfoBeenDep>();

            if (bIsLastThread)
            {
                // 如果是最后一个线程 直接把剩余的allTasks返回为lstFileInfo
                lstFileInfo = allTasks.ToList();
            }
            else
            {
                // push出的个数
                for (int i = 0; i < nCutNum; i++)
                {
                    lstFileInfo.Add(allTasks.Pop());
                }

            }

            return lstFileInfo;
        }

        public void Run()
        {
            // 开辟线程. 为不同线程分配不同任务.
            // 如何判断其他线程执行完毕. 切割任务.
            // 字典保存文件名和对应的文件字符串内容.

            // 目前认为 只有这6种资源才有可能包含其他资源.
            // ".prefab", ".unity", ".mat", ".asset", ".anim", ".controller"


            List<string> withExtensions = new List<string>()
            {
                ".prefab",
                ".unity",
                ".mat",
                ".asset",
                ".anim",
                ".controller",
                ".guiskin",
                ".mixer",
                ".fontsettings",
                ".flare",
                ".playable",
                ".overrideController",
            };
            string[] findFiles = Directory.GetFiles(m_assetPath, "*.*", SearchOption.AllDirectories)
                .Where(s => withExtensions.Contains(Path.GetExtension(s).ToLower())).ToArray();

            // 使用全文件测试.
            // string[] allFindFiles = Directory.GetFiles(m_assetPath, "*.*", SearchOption.AllDirectories);
            // List<string> findFiles = new List<string>();

            // // 先筛选出Dep项
            // List<string> withOutExtensions = new List<string>()
            // {
            //     ".png",".gif",".tif",".jpg",".psd",
            //     ".cginc",".shader",
            //     ".ttf",".TTF",".fnt",
            //     ".otf",
            //     ".mp3",".ogg",".aiff",".wav",
            //     ".proto",".sln",
            //     ".mm",".h",".m",".a",
            //     ".meta",".XML",".md",
            //     ".cs",".dll",".pfx",".jslib",
            //     ".json",".txt",".xml",".info",
            //     ".keystore",".plist",
            //     ".unity3d",".manifest",
            //     ".cs",".lua",".sh",".mdb",".csproj",".sln",
            //     ".exe",".py",
            //     ".jar",".aar",".gradle",
            //     ".DISABLED",".pri",".winmd",".bundle",
            //     ".bat",".podspec",".properties",".projmods",
            //     ".cer",".template",".so",
            //     ".exr",".bak",".proto",
            //     ".FBX",".fbx",".mingw",".bytes",".spine",
            //     ".html",".css",
            //     ".pom",".srcaar",".skel",
            //     ".sai2",".strings",".java",
            // };

            // foreach (var eachFile in allFindFiles)
            // {
            //     // 通过后缀名进行筛选.
            //     string strExt = Path.GetExtension(eachFile);
            //
            //     if (strExt == string.Empty || strExt == "")
            //     {
            //         continue;
            //     }
            //
            //     if (withOutExtensions.Contains(strExt))
            //     {
            //         // 如果包含 则不进行加入.
            //     }
            //     else
            //     {
            //         // 如果不包含 才加入.
            //         findFiles.Add(eachFile);
            //     }
            //
            // }
            //
            //
            // // 过滤掉之后 再看还有哪些有效的文件.
            //
            // HashSet<string> hashSetExts = new HashSet<string>();
            // foreach (var eachFileName in findFiles)
            // {
            //     string strExt = Path.GetExtension(eachFileName);
            //
            //     if (!hashSetExts.Contains(strExt))
            //     {
            //         hashSetExts.Add(strExt);
            //     }
            //
            // }
            //
            //
            // // 输出全部的Dep后缀名.
            // foreach (var eachExit in hashSetExts)
            // {
            //     Console.WriteLine(eachExit);
            // }



            // 对m_findFilesPath做过滤.
            // 某些文件不可能是会被其他地方引用到.
            // 这里可能不方便使用是否有GUID来判断



            foreach (var eachCheckFile in m_findFilesPath)
            {
                CustomFileInfoCheckFile customFileInfoCheckFile = new CustomFileInfoCheckFile();
                customFileInfoCheckFile.strFileName = eachCheckFile;
                customFileInfoCheckFile.strGuid = CommonUtils.GetGuidFromFile(eachCheckFile);
                m_stackCheckFileInfos.Push(customFileInfoCheckFile);
            }



            // 读取文件从硬盘到内存. 这里如果不做过滤 会把所有文件都读入.
            foreach (var eachFindFile in findFiles)
            {
                CustomFileInfoBeenDep customFileInfoBeenDep = new CustomFileInfoBeenDep();
                customFileInfoBeenDep.strFileName = eachFindFile;
                customFileInfoBeenDep.strFileContent = File.ReadAllText(eachFindFile);
                m_stackDepFileInfos.Push(customFileInfoBeenDep);
            }







            
            // 获得单个Guid
            // m_handleGuid = CommonUtils.GetGuidFromFile(m_filePath);
            // Console.WriteLine("Check Here");
            // 自定义线程个数 12-24个 测试花费时间.
            int nThreadNum = 200;

            // 这里可能会有点异常.
            // 就是出现Check File不够分的情况.
            // 这里感觉好像有点问题.  CheckFile是不能分出去的.
            // Deps 分出去后 每个线程里都要处理所有Check File.


            int cutDepNum = m_stackDepFileInfos.Count / nThreadNum;
            int cutCheckNum = m_stackCheckFileInfos.Count / nThreadNum;

            for (int i = 0; i < nThreadNum; i++)
            {
                Thread eachThread = new Thread(new ParameterizedThreadStart(TheadEachRun));
                lstThreads.Add(eachThread);
                ThreadHandleInfo threadHandleInfo = new ThreadHandleInfo();
                threadHandleInfo.threadName = "threadID-" + i.ToString();
                bool isLastThread = (i == (nThreadNum - 1));

                // 进行切割.
                // threadHandleInfo.inputCheckData = CutCheckTasks(m_stackCheckFileInfos, cutCheckNum, isLastThread);

                // 这里做个深度拷贝 为每个线程准备一个额外的inputCheckData.
                threadHandleInfo.inputCheckData = m_stackCheckFileInfos.ToList();



                threadHandleInfo.outputData = m_lstResults;
                threadHandleInfo.inputDepData = CutDepTasks(m_stackDepFileInfos, cutDepNum, isLastThread);
                eachThread.Start(threadHandleInfo);
            }


            for (int i = 0; i < nThreadNum; i++)
            {
                lstThreads[i].Join();
            }


            // 打印出结果.

            // m_lstResults
            foreach (var eachResult in m_lstResults)
            {
                Console.WriteLine("FileName = " + eachResult);
            }


           

        }



    }
}
