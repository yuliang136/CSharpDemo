using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FindRefsMulti
{
    public static class CommonUtils
    {
        #region Unity资源操作

        /// <summary>
        /// 快速找到guid 不用使用Unity内部方法.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetGuidFromMeta(string filePath)
        {
            string strRtn = string.Empty;

            string[] fileLines = File.ReadAllLines(filePath);

            foreach (var eachLine in fileLines)
            {
                if (eachLine.Contains("guid"))
                {
                    // 使用:拆分字符串.
                    string[] parts = eachLine.Split(':');
                    string strGuid = parts[1].Trim();
                    strRtn = strGuid;
                    break;
                }
            }

            return strRtn;
        }

        /// <summary>
        /// 从一个文件里查出guid 先要查找同目录的meta
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetGuidFromFile(string filePath)
        {
            string strRtn = string.Empty;

            strRtn = GetGuidFromMeta(filePath + ".meta");

            return strRtn;
        }

        public static string windows2Unity_FS(string fileName)
        {
            return fileName.Replace("\\", "/");
        }

        /// <summary>
        /// 从filePath切换到Asset下的名字
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetAssetNameFromPath(string fileName, string strDataPath)
        {
            string strRtn = string.Empty;

            string strUnityFS = windows2Unity_FS(fileName).ToLower();

            string strAssetPath = strUnityFS.Replace(strDataPath.ToLower(), "assets");

            return strAssetPath;


            return strRtn;
        }

        #endregion

        #region 文件操作

        public static void WriteFile(string strFileName, string strContent)
        {
            FileStream fs = new FileStream(strFileName, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(strContent);

            sw.Flush();
            sw.Close();
            fs.Close();
        }

        #endregion

    }
}
