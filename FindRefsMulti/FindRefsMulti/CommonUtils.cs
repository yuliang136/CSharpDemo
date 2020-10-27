using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FindRefsMulti
{
    public static class CommonUtils
    {
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
    }
}
