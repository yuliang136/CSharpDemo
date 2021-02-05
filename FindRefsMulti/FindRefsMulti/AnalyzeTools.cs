using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
    }
}
