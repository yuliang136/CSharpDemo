using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace FindRefsMulti
{
    /// <summary>
    /// 扫描Assets目录 输出所有的AB名字设置 通过meta文件 分析AB名称.
    /// </summary>
    public class AnalyzeABInMeta
    {
        [Serializable]
        public class MetaFileInfo
        {
            // public Dictionary<string, List<string>> dicAssetFileRefs = new Dictionary<string, List<string>>();
            public string fileName = string.Empty;
            public string bundleName = string.Empty;
        }

        public void Run()
        {
            Console.WriteLine("Check Check");
            StopWatchUtils.WatchStopInit();

            List<MetaFileInfo> lstMetaFileInfo = new List<MetaFileInfo>(); 


            // 读取Unity目录.
            string strUnityAssetData = @"C:\svnWorks\android151_cjp";

            DirectoryInfo diAssetData = new DirectoryInfo(strUnityAssetData);
            FileInfo[] metaFiles = diAssetData.GetFiles("*.meta", SearchOption.AllDirectories);

            foreach (var eachMetaFile in metaFiles)
            {
                // eachMetaFile.FullName
                string[] fileLines = File.ReadAllLines(eachMetaFile.FullName);

                // 再次遍历每个文件的每一行.
                foreach (var eachFileLine in fileLines)
                {
                    if (eachFileLine.Contains("assetBundleName:"))
                    {
                        string handleEachLine = eachFileLine.Trim();

                        // 分开:
                        string[] parts = handleEachLine.Split(':');
                        string strBundleName = parts[1].Trim();
                        if(!string.IsNullOrEmpty(strBundleName))
                        {
                            // 这里输出文件名和Bundle名.

                            string strSaveFileName = CommonUtils.GetAssetNameFromPath(eachMetaFile.FullName, strUnityAssetData);

                            MetaFileInfo metaFile = new MetaFileInfo();
                            metaFile.fileName = strSaveFileName;
                            metaFile.bundleName = strBundleName;
                            lstMetaFileInfo.Add(metaFile);
                            //
                            // Console.WriteLine(eachMetaFile.FullName);
                            // Console.WriteLine(strBundleName);
                        }

                    }
                }

            }


            string strResult = JsonConvert.SerializeObject(lstMetaFileInfo, Formatting.Indented);
            CommonUtils.WriteFile(@"D:\AnalyzeABInMeta.json", strResult);

            StopWatchUtils.WatchStopOnceEnd("AnalyzeABInMeta");


            Console.WriteLine("1");

        }
    }
}
