using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AssetDownloadTool
{
    class AssetDownloadTool
    {
        public string m_resPath = string.Empty;
        //public string m_qianzui = "http://img.palmfuns-zyxd.com/android_20170503";
        public string m_qianzui = "http://cdn.haoxingame.com/shuihu/android/android_20170511";

        public List<string> m_fileList = new List<string>();

        public string m_CDNFile = string.Empty;

        public string m_jieDuan = "http://cdn.haoxingame.com/shuihu/android/";

        public void Run(string[] argsArray)
        {
            // 读取文件.
            m_CDNFile = argsArray[1];

            // 把文件读取到List.
            m_fileList = ReadListFromFile(m_CDNFile);

            // 下载资源.
            Console.WriteLine("下载资源...");
            ServicePointManager.DefaultConnectionLimit = 512;
            WebClient Client = new WebClient();
            foreach (string eachUrl in m_fileList)
            {
                Console.WriteLine("Download..." + eachUrl);

                // 组合保存文件的位置.
                string strFilePath = eachUrl.Replace(m_jieDuan, "");

                // /->\\
                strFilePath = strFilePath.Replace('/', '\\');

                // 获得程序执行的目录 再做拼接.

                string strDir = System.IO.Path.GetDirectoryName(strFilePath);
                if (!Directory.Exists(strDir))
                {
                    Directory.CreateDirectory(strDir);
                }

                try
                {
                    // 如果没有目录 需要生成目录.
                    Client.DownloadFile(eachUrl, strFilePath);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }


            //m_resPath = argsArray[1];

            //Console.WriteLine(m_resPath);

            //// 遍历res文件夹.
            //string destPath = string.Empty;
            //DirectoryInfo diSource = new DirectoryInfo(m_resPath);
            //FileInfo[] sourceFileInfos = diSource.GetFiles("*", SearchOption.AllDirectories);

            //foreach (var eachFileInfo in sourceFileInfos)
            //{
            //    Console.WriteLine(eachFileInfo.FullName);

            //    string strFullName = eachFileInfo.FullName;

            //    string newPath = strFullName.Replace(m_resPath, m_qianzui);

            //    newPath = newPath.Replace('\\', '/');

            //    m_fileList.Add(newPath);

            //    //Console.WriteLine(newPath);
            //}

            //WriteToFile("CDNUrl.txt", m_fileList);

            ////// 开始下载.
            ////ServicePointManager.DefaultConnectionLimit = 512;
            ////DownLoadFiles(m_fileList, "TestCDN");


            //Console.WriteLine("Downing Done");
        }

        private List<string> ReadListFromFile(string strCDNFile)
        {
            List<string> ltRtn = new List<string>();

            StreamReader sr = new StreamReader(strCDNFile, Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                ltRtn.Add(line);
            }

            return ltRtn;
        }

        private void DownLoadFiles(List<string> m_fileList, string strDownloadPath)
        {
            if (!Directory.Exists(strDownloadPath))
            {
                Directory.CreateDirectory(strDownloadPath);
            }

            WebClient Client = new WebClient();

            foreach (string eachUrl in m_fileList)
            {
                // 组合出下载的文件绝对位置

                Console.WriteLine("Downing ... " + eachUrl);

                string strFileUrl = eachUrl;

                string strTest = strFileUrl.Replace(m_qianzui, strDownloadPath);
                // / -> \\
                strTest = strTest.Replace('/', '\\');

                string strDir = System.IO.Path.GetDirectoryName(strTest);
                if (!Directory.Exists(strDir))
                {
                    Directory.CreateDirectory(strDir);
                }

                try
                {
                    // 如果没有目录 需要生成目录.
                    Client.DownloadFile(eachUrl, strTest);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }


 
            }
        }

        private void WriteToFile(string strFilePath, List<string> m_fileList)
        {
            FileStream fs = new FileStream(strFilePath, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);

            foreach (string eachUrl in m_fileList)
            {
                //开始写入
                sw.WriteLine(eachUrl);
            }

            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
        }

        //private void WriteToFile(string strFilePath, )
        //{

        //}
    }
}
