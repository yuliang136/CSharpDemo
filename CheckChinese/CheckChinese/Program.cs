using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CheckChinese
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Check Chinese");

            DirectoryInfo di = new DirectoryInfo(@"G:\Apks\0710\11\38918\StreamingAssets");

            FileInfo[] files = di.GetFiles();

            foreach (var eachFile in files)
            {
                //Console.WriteLine(eachFile.Name);

                if (CheckStringChineseReg(eachFile.Name))
                {
                    Console.WriteLine(eachFile.Name);
                }

            }

            
        }

        public static bool CheckStringChineseReg(string text)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(text, @"[\u4e00-\u9fbb]");
        }
    }
}
