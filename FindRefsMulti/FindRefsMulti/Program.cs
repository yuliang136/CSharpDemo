using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace FindRefsMulti
{
    class Program
    {
        /// <summary>
        /// 快速找到guid 不用使用Unity内部方法.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetGuid(string filePath)
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

        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");

            // 统计用时.
            // Stopwatch stopWatch = new Stopwatch();
            // stopWatch.Start();
            StopWatchUtils.WatchStopInit();


            // 取得Assets目录.
            string strApplicationDataPath = @"C:\gitWorks\gitbranch_ios_pack\Assets";


            List<string> withExtensions = new List<string>() { ".prefab", ".unity", ".mat", ".asset", ".anim", ".controller" };
            string[] findFiles = Directory.GetFiles(strApplicationDataPath, "*.*", SearchOption.AllDirectories)
                .Where(s => withExtensions.Contains(Path.GetExtension(s).ToLower())).ToArray();


            // // 获得某个文件的guid.
            string strTestFile = @"C:\gitWorks\gitbranch_ios_pack\Assets\Game\Art\Textures\Activity\ChestActivity\img_close.png";
            string strTestFileMeta = strTestFile + ".meta";
            string strGuid = GetGuid(strTestFileMeta);
            // if (File.Exists(strTestFileMeta))
            // {
            //     // Console.WriteLine("File Exists");
            //     // 按行读取文件. 当有guid字段时 取出后面的内容.
            //     string strGuid = GetGuid(strTestFileMeta);
            //     Console.WriteLine(strGuid);
            // }


            // Console.WriteLine("Hello World!");


            // stopWatch.Stop();
            // string m_stopWatchShow = string.Format("ReadAllFiles from Disk Cost time : " + stopWatch.ElapsedMilliseconds / 1000.0f);
            // Console.WriteLine(m_stopWatchShow);
            //
            // stopWatch.Reset();
            // stopWatch.Start();
            StopWatchUtils.RecordWatchStop("ReadAllFiles from Disk");


            // 遍历所有files 针对某个文件进行搜索.
            foreach (var eachFindFile in findFiles)
            {
                if (Regex.IsMatch(File.ReadAllText(eachFindFile), strGuid))
                {
                    Console.WriteLine("Find File = " + eachFindFile);
                }
            }

            // 搜索一个文件还是用了1秒.

            // stopWatch.Stop();
            // m_stopWatchShow = string.Format("FindGuide Cost time : " + stopWatch.ElapsedMilliseconds / 1000.0f);
            // Console.WriteLine(m_stopWatchShow);
            StopWatchUtils.WatchStopOnceEnd("FindGuid");



            // Console.ReadLine();

        }
    }
}
