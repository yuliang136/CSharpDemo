using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FindRefsMulti
{
    public static class TestFindRefWithMulti
    {
        public static void Run()
        {
            StopWatchUtils.WatchStopInit();
            // 取得Assets目录.
            string strCheckFilesPath = @"C:\svnWorks\ios145_pack\Assets";
            string[] checkFiles = Directory.GetFiles(strCheckFilesPath, "*.*", SearchOption.AllDirectories);
            List<string> totalLst = checkFiles.ToList();                            // Check文件列表
            string strDepFilesPath = @"C:\svnWorks\ios145_pack\Assets";      // Dep文件查找目录.
            string strUnityAssetPath = @"C:\svnWorks\ios145_pack\Assets";    // Unity Assets固定目录.
            string strOutputFilePath = @"D:\check_ios145.json";         // 输出文件名字
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
