using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace FindRefsMulti
{
    public class SetTextContent
    {
        [Serializable]
        public class FilesInfo
        {
            public List<string> lstFiles = new List<string>();
        }

        private string m_outputPath = string.Empty;
        private string m_DepFilesPath = string.Empty;
        private List<string> m_findFilesPath = new List<string>();
        private string m_unityDataPath = string.Empty;
        private int m_ThreadNum = 0;

        public SetTextContent(
                                string strDepFilesPath, 
                                List<string> strFindFilesPath, 
                                string strOutputPath,
                                string UnityDataPath, 
                                int nThreadNum)
        {
            m_DepFilesPath = strDepFilesPath;   // 传入Dep总的目录的名字
            m_findFilesPath = strFindFilesPath; // 传入一个List输入
            m_outputPath = strOutputPath;       // 传入输出文件的名字
            m_unityDataPath = CommonUtils.windows2Unity_FS(UnityDataPath); // Unity的固定Asset目录
            m_ThreadNum = nThreadNum;
        }

        public void SetTextOverflow()
        {
            int nFileTotal = m_findFilesPath.Count;
            int nIndex = 0;
            string strShowInfo = string.Empty;

            foreach (var eachFile in m_findFilesPath)
            {
                // Console.WriteLine(eachFile);
                SetFileOverflow(eachFile);

                nIndex++;
                strShowInfo = string.Format("Handle {0}/{1}", nIndex.ToString(), nFileTotal.ToString());
                Console.WriteLine(strShowInfo);
            }
        }

        /// <summary>
        /// 设置单个文件的
        /// </summary>
        /// <param name="strFilePath"></param>
        public void SetFileOverflow(string strFilePath)
        {
            // 按行读取文件?
            string strFileContent = File.ReadAllText(strFilePath);

            // 读取整个文件 进行字符串替换.
            string strNewFileContent = strFileContent.Replace("m_HorizontalOverflow: 0", "m_HorizontalOverflow: 1");
            strNewFileContent = strNewFileContent.Replace("m_VerticalOverflow: 0", "m_VerticalOverflow: 1");



            // 再把内容写回原文件.
            File.WriteAllText(strFilePath, strNewFileContent);

        }



        /// <summary>
        /// 查找满足条件的Prefab并进行输出.
        /// </summary>
        public void FindPrefabWithText()
        {
            FilesInfo fiObject = new FilesInfo();

            // 写出Json记录文件.
            // 找出所有带有Text控件的Prefab.
            // m_outputPath = @"D:\saveText_cjp.json";
            // string strCheckFilesPath = @"C:\svnWorks\android142_cjp_pack\Assets";
            // string strUnityDataPath = @"C:\svnWorks\android142_cjp_pack\Assets";
            // string[] checkFiles = Directory.GetFiles(strCheckFilesPath, "*.prefab", SearchOption.AllDirectories);
            List<string> totalLst = m_findFilesPath;

            string strSetFileName = string.Empty;

            foreach (var eachFile in totalLst)
            {
                bool bIsContainText = CheckIfContainText(eachFile);

                // 转换eachFile里的文件格式.
                // GetAssetNameFromPath
                if (bIsContainText)
                {
                    strSetFileName = CommonUtils.GetAssetNameFromPath(eachFile, m_unityDataPath);
                    //
                    // Console.WriteLine();
                    fiObject.lstFiles.Add(strSetFileName);
                }
            }



            string strResult = JsonConvert.SerializeObject(fiObject, Formatting.Indented);
            CommonUtils.WriteFile(m_outputPath, strResult);


            // Console.ReadKey();

        }

        public bool CheckIfContainText(string strPath)
        {
            bool bRtn = false;

            string fileContent = File.ReadAllText(strPath);

            // if (fileContent.Contains("m_HorizontalOverflow") || fileContent.Contains("m_VerticalOverflow"))

            if (fileContent.Contains("m_HorizontalOverflow: 0") || fileContent.Contains("m_VerticalOverflow: 0"))
            {
                bRtn = true;
            }

            return bRtn;
        }

    }
}
