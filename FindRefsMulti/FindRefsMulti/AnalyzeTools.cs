using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace FindRefsMulti
{
    /// <summary>
    /// 分析工具类.
    /// </summary>
    public static class AnalyzeTools
    {
        // 检查文件后缀名.
        public static void CheckFileExts(string strAssetPath)
        {
            string[] files = Directory.GetFiles(strAssetPath, "*.*", SearchOption.AllDirectories);

            // 找到不重复的项.
            HashSet<string> hashSetExts = new HashSet<string>();

            // 获得所有后缀名
            foreach (var eachFileName in files)
            {
                string strExt = Path.GetExtension(eachFileName);

                // // 这里有个为空的后缀名 需要看看.
                // if((strExt == string.Empty) || (strExt == ""))
                // {
                //     Console.WriteLine("FileName = " + eachFileName);
                // }

                if (!hashSetExts.Contains(strExt))
                {
                    hashSetExts.Add(strExt);
                }

            }

            foreach (var eachExt in hashSetExts)
            {
                Console.WriteLine(eachExt);
            }


            Console.WriteLine("CheckFileExts");


        }

        /// <summary>
        /// 通过guid 去查看哪些资源引用了这个guid
        /// </summary>
        public static void CheckDepByGuid(string strAssetPath)
        {
            string guid = "c79f6cb9d22b7f54e8eb1628776aea42";

            // 找到所有资源 除开.meta .png等？
            // 哪些资源本身有可能引用到其他资源？

            // 排除绝对的文件 .meta和png来搜索.

            string[] files = Directory.GetFiles(strAssetPath, "*.*", SearchOption.AllDirectories);
            HashSet<string> hashSetExts = new HashSet<string>();
            foreach (var eachFileName in files)
            {
                string strExt = Path.GetExtension(eachFileName);

                if (strExt == ".meta")
                {
                    continue;
                }

                if (strExt == ".png")
                {
                    continue;
                }


                if (!hashSetExts.Contains(eachFileName))
                {
                    hashSetExts.Add(eachFileName);
                }

            }

            // 16000个文件.
            // string strGuid = CommonUtils.GetGuidFromFile(strTestFile);
            int index = 0;
            foreach (var eachFile in hashSetExts)
            {
                index++;
                string strFileContent = File.ReadAllText(eachFile);

                // Console.WriteLine("Check Here");

                if (Regex.IsMatch(strFileContent, guid))
                {
                    Console.WriteLine("Find File : " + eachFile);
                }

                // Console.WriteLine("index = " + index);


            }



            Console.WriteLine("Check Here");
            Console.ReadLine();

        }
    }
}
