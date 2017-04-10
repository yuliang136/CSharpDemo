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
        public void Run()
        {
            // 读取一个文件.
            string strFilePath = @"F:\CompareCSV\trunkCSV\achieve.csv";

            string strOutDir = @"F:\CompareCSV\outCSV";

            List<string> strList = new List<string>();

            // 循环获取每一行
            StreamReader sr = new StreamReader(strFilePath,Encoding.UTF8);
            String line;
            while ((line = sr.ReadLine()) != null) 
            {
                //Console.WriteLine(line.ToString());
                strList.Add(line);
            }
            sr.Close();

            

            // 替换标点

            // 写出到另一个目录里
            FileInfo fi = new FileInfo(strFilePath);
            String strFileName = fi.Name;

            if (!Directory.Exists(strOutDir))
            {
                Directory.CreateDirectory(strOutDir);
            }

            string strOutFilePath = string.Format(@"{0}\{1}",strOutDir,strFileName);

            Write2File(strOutFilePath, strList);

            Console.WriteLine(strOutFilePath);
        }

        private void Write2File(string strOutFilePath, List<string> strList)
        {
            FileStream fs = new FileStream(strOutFilePath, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            //开始写入
            //sw.Write("Hello World!!!!");

            foreach (var item in strList)
            {
                sw.WriteLine(item);
            }

            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
        }
    }
}
