using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FindRefsMulti
{
    public static class TestSetTextContent
    {
        public static void Run()
        {
            StopWatchUtils.WatchStopInit();
            // 取得Assets目录.
            string strCheckFilesPath = @"C:\svnWorks\android142_cjp_pack\Assets";
            string[] checkFiles = Directory.GetFiles(strCheckFilesPath, "*.unity", SearchOption.AllDirectories);
            List<string> totalLst = checkFiles.ToList();                             // Check文件列表

            // 筛选出特定Prefab.
            // List<string> lstUseCheckFiles = new List<string>();
            // foreach (var eachPrefabFile in totalLst)
            // {
            //     if (eachPrefabFile.ToLower().Contains("shoppanel"))
            //     {
            //         lstUseCheckFiles.Add(eachPrefabFile);
            //     }
            // }





            string strDepFilesPath = @"C:\svnWorks\android142_cjp_pack\Assets";      // Dep文件查找目录.
            string strUnityAssetPath = @"C:\svnWorks\android142_cjp_pack\Assets";    // Unity Assets固定目录.
            string strOutputFilePath = @"D:\checkText_cjp.json";         // 输出文件名字
            int nThreadNum = 200;


            SetTextContent setTextContent = new SetTextContent(
                strDepFilesPath,
                totalLst,
                strOutputFilePath,
                strUnityAssetPath,
                nThreadNum);


            // setTextContent.FindPrefabWithText();
            setTextContent.SetTextOverflow();

            StopWatchUtils.WatchStopOnceEnd("SetTextContent Handle Done!");
        }

        
    }
}
