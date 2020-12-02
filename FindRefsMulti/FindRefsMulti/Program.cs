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
            // 测试FindRefWithMulti
            // TestFindRefWithMulti.Run();

            // TestSetTextContent.Run();


            // Console.ReadKey();


            // 查看meta文件.
            AnalyzeABInMeta analyzeABInMeta = new AnalyzeABInMeta();
            analyzeABInMeta.Run();

        }
    }
}
