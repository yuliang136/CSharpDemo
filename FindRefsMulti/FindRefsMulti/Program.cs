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
            string strCheckFilesPath = @"C:\gitWorks\gitbranch_ios_pack\Assets\UTNotifications";
            string[] checkFiles = Directory.GetFiles(strCheckFilesPath, "*.*", SearchOption.AllDirectories);
            List<string> totalLst = checkFiles.ToList();                            // Check文件列表
            string strDepFilesPath = @"C:\gitWorks\gitbranch_ios_pack\Assets";      // Dep文件查找目录.
            string strUnityAssetPath = @"C:\gitWorks\gitbranch_ios_pack\Assets";    // Unity Assets固定目录.
            string strOutputFilePath = @"D:\checkUTNotifications.json";         // 输出文件名字
            int nThreadNum = 200;


            FindRefWithMulti findRefWithMulti = new FindRefWithMulti(
                                                        strDepFilesPath, 
                                                        totalLst, 
                                                        strOutputFilePath, 
                                                        strUnityAssetPath,
                                                        nThreadNum);
            findRefWithMulti.Run();
            StopWatchUtils.WatchStopOnceEnd("FindRefWithMulti Handle Done!");



            // AnalyzeTools.CheckFileExts(strApplicationDataPath);
            Console.ReadKey();
        }
    }
}
