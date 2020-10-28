using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Newtonsoft.Json;

namespace FindRefsMulti
{
    public class FindRefWithMulti
    {
        private string m_DepFilesPath;              // 指定的依赖文件查找目录.
        private List<string> m_findFilesPath;       // 所有需要Check的文件List.
        private string m_outputPath;                // 输出文件路径
        private string m_unityDataPath;             // 固定的unityDataPath目录.
        private int m_ThreadNum;                    // 开辟的线程数

        // 设置一个内存锁.
        private readonly object locker = new object();
        private List<Thread> lstThreads = new List<Thread>();

        // 需要汇总的数据
        public AssetFileRef m_assetFileRef = new AssetFileRef();

        // 被依赖项的文件集合
        public Stack<CustomFileInfoBeenDep> m_stackDepFileInfos = new Stack<CustomFileInfoBeenDep>();

        // 要Check的文件集合
        public Stack<CustomFileInfoCheckFile> m_stackCheckFileInfos = new Stack<CustomFileInfoCheckFile>();

        /// <summary>
        /// 为TextureRef添加序列化属性.
        /// 序列化为一个字符串 然后写出来.
        /// </summary>
        [Serializable]
        public class AssetFileRef
        {
            public Dictionary<string, List<string>> dicAssetFileRefs = new Dictionary<string, List<string>>();
        }

        public FindRefWithMulti(string strDepFilesPath, List<string> strFindFilesPath, string strOutputPath, string UnityDataPath, int nThreadNum)
        {
            m_DepFilesPath = strDepFilesPath;
            m_findFilesPath = strFindFilesPath; // 传入一个List输入
            m_outputPath = strOutputPath; // 传入输出文件的名字
            m_unityDataPath = CommonUtils.windows2Unity_FS(UnityDataPath); // Unity的固定Asset目录
            m_ThreadNum = nThreadNum;
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
            public List<CustomFileInfoCheckFile> inputCheckData; // 输入Check项
            public List<CustomFileInfoBeenDep> inputDepData; // 输入被依赖项
            public Dictionary<string, List<string>> dicFileDeps = new Dictionary<string, List<string>>(); // 共用的一份地址 需要加锁处理
        }


        public void TheadEachRun(object obj)
        {
            // 进行拆箱.
            ThreadHandleInfo threadData = obj as ThreadHandleInfo;

            // 这里写的输出结果有问题.
            // 应该使用<string, List<string>>后面的是依赖项.
            // 每个线程有个结果 最终有个汇总结果.
            // List<string> findResult = new List<string>();

            // 输出结果
            Dictionary<string,List<string>> resultDic = new Dictionary<string, List<string>>();

            // int nCheckFileNum = threadData.inputCheckData.Count;
            // int nHandleCheckIndex = 0;
            // string strShowProgress = string.Empty;

            // 这个inputCheckData没有做切割.
            foreach (var eachCheckInfo in threadData.inputCheckData)
            {
                // 记录处理的每一个文件
                // nHandleCheckIndex++;

                // strShowProgress = string.Format("Thread {0}  {1}/{2}", threadData.threadName,
                //                         nHandleCheckIndex,
                //                         nCheckFileNum);
                // Console.WriteLine(strShowProgress);

                foreach (var eachDepInfo in threadData.inputDepData)
                {
                    if (Regex.IsMatch(eachDepInfo.strFileContent, eachCheckInfo.strGuid))
                    {
                        if (resultDic.ContainsKey(eachCheckInfo.strFileName))
                        {
                            // 如果包含Key 应该已经有了List<string>
                            resultDic[eachCheckInfo.strFileName].Add(eachDepInfo.strFileName);
                        }
                        else
                        {
                            resultDic[eachCheckInfo.strFileName] = new List<string>();
                            resultDic[eachCheckInfo.strFileName].Add(eachDepInfo.strFileName);
                        }
                    }
                }
            }


            // 把结果写入.
            lock (locker)
            {
                Dictionary<string, List<string>> outputData = threadData.dicFileDeps;

                // 加锁来处理 其他线程会阻塞住等待.
                // 把resultDic里的结果导入outputData里.
                foreach (var threadResultItem in resultDic)
                {
                    // threadData.outputData.Add(eachOutput);

                    // 判断check项在outputData里是否存在.
                    string strSaveKey = CommonUtils.GetAssetNameFromPath(threadResultItem.Key, m_unityDataPath);

                    if (outputData.ContainsKey(threadResultItem.Key))
                    {
                    }
                    else
                    {
                        outputData[strSaveKey] = new List<string>();
                    }

                    foreach (var eachDep in threadResultItem.Value)
                    {
                        // 改变eachDep为一个Asset的值.
                        string strSaveDep = CommonUtils.GetAssetNameFromPath(eachDep, m_unityDataPath);
                        outputData[strSaveKey].Add(strSaveDep);
                    }

                }
            }

            string strShow = string.Format("Thread {0} Done", threadData.threadName);
            Console.WriteLine(strShow);

        }

        // /// <summary>
        // /// 进行任务切割.
        // /// </summary>
        // /// <param name="allTasks"></param>
        // /// <param name="bIsLastThread">判断是否是最后一个Thread 返回所有任务.</param>
        // /// <returns></returns>
        // public List<CustomFileInfoCheckFile> CutCheckTasks(Stack<CustomFileInfoCheckFile> allTasks, int nCutNum, bool bIsLastThread)
        // {
        //     List<CustomFileInfoCheckFile> lstFileInfo = new List<CustomFileInfoCheckFile>();
        //
        //     if (bIsLastThread)
        //     {
        //         // 如果是最后一个线程 直接把剩余的allTasks返回为lstFileInfo
        //         lstFileInfo = allTasks.ToList();
        //     }
        //     else
        //     {
        //         // push出的个数
        //         for (int i = 0; i < nCutNum; i++)
        //         {
        //             lstFileInfo.Add(allTasks.Pop());
        //         }
        //
        //     }
        //
        //     return lstFileInfo;
        // }

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


            List<string> lstDepWithExt = new List<string>()
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
            string[] findFiles = Directory.GetFiles(m_DepFilesPath, "*.*", SearchOption.AllDirectories)
                .Where(s => lstDepWithExt.Contains(Path.GetExtension(s).ToLower())).ToArray();


            // 对Check资源再进行一个筛选
            List<string> lstCheckWithExt = new List<string>()
            {
                ".controller",
                ".asset",
                ".cs",
                ".json",
                ".dll",
                ".txt",

                ".png",
                ".guiskin",
                ".prefab",
                ".mixer",
                ".fontsettings",
                ".mat",

                ".TTF",
                ".ttf",
                ".psd",
                ".otf",
                ".shader",
                ".anim",

                ".ogg",
                ".cginc",
                ".FBX",
                ".jpg",
                ".tif",
                ".flare",

                ".fbx",
                ".mp3",
                ".playable",
                ".gif",
                ".aiff",
                ".wav",

                ".overrideController",
                ".bytes",
                ".spine",
            };

            m_findFilesPath = m_findFilesPath.Where(s => lstCheckWithExt.Contains(Path.GetExtension(s).ToLower())).ToList();

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
            int nThreadNum = m_ThreadNum;
            int cutDepNum = m_stackDepFileInfos.Count / nThreadNum;
            // int cutCheckNum = m_stackCheckFileInfos.Count / nThreadNum;

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


                threadHandleInfo.dicFileDeps = m_assetFileRef.dicAssetFileRefs;
                threadHandleInfo.inputDepData = CutDepTasks(m_stackDepFileInfos, cutDepNum, isLastThread);
                eachThread.Start(threadHandleInfo);
            }


            for (int i = 0; i < nThreadNum; i++)
            {
                lstThreads[i].Join();
            }


            // 打印出结果.
            // m_lstResults
            // Console.WriteLine("Check Result");

            // 直接把对象序列化为字符串.

            string strResult = JsonConvert.SerializeObject(m_assetFileRef.dicAssetFileRefs, Formatting.Indented);
            CommonUtils.WriteFile(m_outputPath, strResult);







        }



    }
}
