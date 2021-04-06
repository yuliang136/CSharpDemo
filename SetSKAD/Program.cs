using System;
using System.Collections.Generic;
using System.IO;

namespace SetSKAD
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");

            // 读入extra_skad.txt

            // 遍历每行. 找到<string>这行.
            // 找到第一个出现的> 后面提取固定位数?

            // <string>4468km3ulz.skadnetwork</string>

            string[] strLines = File.ReadAllLines(@"D:\Desktop\documents\TripleWin\extra_skad\extra_skad.txt");

            // Console.WriteLine("Check here");

            List<string> lstSKAdNetwork = new List<string>();

            foreach (var eachLine in strLines)
            {
                if (eachLine.Contains("<string>"))
                {
                    int nFirstAppear = eachLine.IndexOf('>');
                    string strSubString = eachLine.Substring(nFirstAppear + 1, 22);

                    // Console.WriteLine("Check here");
                    lstSKAdNetwork.Add(strSubString);
                }
            }


            // 拼接出添加字符串.
            // PlistElementDict pd_AppLovin = arraySKAdNetworkItems.AddDict();
            // pd_AppLovin.SetString("SKAdNetworkIdentifier", "ludvb6z3bs.skadnetwork");

            // 组装字符串 最后输出一个文件.
            // string str1 = "PlistElementDict pd_ = arraySKAdNetworkItems.AddDict();";
            // string str2 = string.Format("")

            List<string> lstOutput = new List<string>();

            int index = 1;
            foreach (var eachNetwork in lstSKAdNetwork)
            {
                string str1 = string.Format("PlistElementDict pd_{0} = arraySKAdNetworkItems.AddDict();", index);
                string str2 = string.Format("pd_{0}.SetString(\"SKAdNetworkIdentifier\", \"{1}\");", index, eachNetwork);

                lstOutput.Add(str1);
                lstOutput.Add(str2);

                index++;
            }

            // 写出文件.
            // Console.WriteLine("Check here");
            File.WriteAllLines(@"D:\Desktop\documents\TripleWin\extra_skad\extra_skad_output.txt", lstOutput);
        }
    }
}
