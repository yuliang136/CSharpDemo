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
        static void Main(string[] args)
        {
            StopWatchUtils.WatchStopInit();
            // 取得Assets目录.
            string strApplicationDataPath = @"C:\gitWorks\gitbranch_ios_pack\Assets";
            string[] testTexs = Directory.GetFiles(strApplicationDataPath, "*.lua", SearchOption.AllDirectories);
            List<string> totalLst = testTexs.ToList();
            
            
            FindRefWithMulti findRefWithMulti = new FindRefWithMulti(strApplicationDataPath, totalLst);
            findRefWithMulti.Run();
            // Console.WriteLine("Check Here");
            StopWatchUtils.WatchStopOnceEnd("FindRefWithMulti Handle Done!");



            // AnalyzeTools.CheckFileExts(strApplicationDataPath);
            // Console.ReadKey();
        }
    }
}
