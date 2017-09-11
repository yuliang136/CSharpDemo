using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinGanCi
{
    class MinGanCi
    {
        public List<string> m_contents = new List<string>();

        public string fileContent = @"F:\资源备份保存\ShuiHu\tanyu1100\渠道资料\Baidu\insen.txt";

        public void Run(string[] argsArray)
        {
            // 读取文件.取出每一行元素.
            m_contents = ReadListFromFile(fileContent);

            Console.WriteLine("here");



            // 组合为一个字符串
            String strOne = ConnectOne(m_contents);


            // 写入到一个文件.
        }

        private string ConnectOne(List<string> ltContents)
        {
            String strRtn = string.Empty;


            strRtn = ",";
            for (int i = 0; i < ltContents.Count; i++)
            {
                if (i != (ltContents.Count - 1))
                {
                    strRtn = strRtn + ltContents[i] + ",";
                }
                else
                {
                    strRtn = strRtn + ltContents[i];
                }
            }

            return strRtn;
        }

        private List<string> ReadListFromFile(string strFileName)
        {
            List<string> ltRtn = new List<string>();

            StreamReader sr = new StreamReader(strFileName, Encoding.UTF8);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                ltRtn.Add(line);
            }

            return ltRtn;
        }
    }
}
