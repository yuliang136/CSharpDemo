using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertPunctuate
{
    class ConvertPunctuate
    {
        public void Run(string strInputDir, string strOutDir)
        {
            // 批处理多个文件.
            string[] files = Directory.GetFiles(strInputDir);
            for (int i = 0; i < files.Length; i++)
            {
                HandleEachFile(files[i], strOutDir);
            }
        }

        private void HandleEachFile(string strFilePath, string strOutDir)
        {
            List<string> strInputList = new List<string>();

            // 循环获取每一行
            StreamReader sr = new StreamReader(strFilePath, Encoding.UTF8);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                strInputList.Add(line);
            }
            sr.Close();

            List<string> strOutList = new List<string>();

            // 替换标点
            ConvertPunc(strInputList, strOutList);

            // 写出文件.
            if (!Directory.Exists(strOutDir))
            {
                Directory.CreateDirectory(strOutDir);
            }

            FileInfo fi = new FileInfo(strFilePath);
            String fileOutPath = string.Format(@"{0}\{1}", strOutDir, fi.Name);

            Write2File(fileOutPath, strOutList);
        }

        private void ConvertPunc(List<string> strList, List<string> strOutList)
        {
            string strNew = string.Empty;
            foreach (var item in strList)
            {
                strNew = item.Replace(',', '`');
                strOutList.Add(strNew);
            }
        }

        private void Write2File(string strOutFilePath, List<string> strList)
        {
            FileStream fs = new FileStream(strOutFilePath, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            
            //开始写入
            string strEachLine = string.Empty;
            for (int i = 0; i < strList.Count; i++)
            {
                strEachLine = strList[i];

                if (i == strList.Count - 1)
                {
                    sw.Write(strEachLine);
                }
                else
                {
                    sw.WriteLine(strEachLine);
                }
            }

            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
        }
    }
}
