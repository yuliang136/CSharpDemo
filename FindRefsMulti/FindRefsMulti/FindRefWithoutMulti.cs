using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FindRefsMulti
{
    public class FindRefWithoutMulti
    {
        private string m_assetPath;
        private string m_filePath;

        public FindRefWithoutMulti(string strAssetPath, string strFilePath)
        {
            m_assetPath = strAssetPath;
            m_filePath = strFilePath;
        }

        public void Run()
        {
            // 字典保存文件名和对应的文件字符串内容.
            Dictionary<string, string> dicFileContent = new Dictionary<string, string>();



            List<string> withExtensions = new List<string>() { ".prefab", ".unity", ".mat", ".asset", ".anim", ".controller" };
            string[] findFiles = Directory.GetFiles(m_assetPath, "*.*", SearchOption.AllDirectories)
                .Where(s => withExtensions.Contains(Path.GetExtension(s).ToLower())).ToArray();

            // 读取文件从硬盘到内存.
            foreach (var eachFindFile in findFiles)
            {
                dicFileContent.Add(eachFindFile, File.ReadAllText(eachFindFile));
            }

            StopWatchUtils.RecordWatchStop("ReadAllFiles from Disk");


            // 获得某个文件的guid.
            string strTestFile = m_filePath;
            string strGuid = CommonUtils.GetGuidFromFile(strTestFile);


            // 遍历所有files 针对某个文件进行搜索.
            foreach (var eachFindFile in findFiles)
            {
                // 时间应该是消耗在硬盘读取上了.
                if (Regex.IsMatch(dicFileContent[eachFindFile], strGuid))
                {
                    Console.WriteLine("Find File = " + eachFindFile);
                }
            }

            // 搜索一个文件还是用了1秒.
            StopWatchUtils.WatchStopOnceEnd("FindGuid");
        }
    }
}
