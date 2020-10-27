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

            StopWatchUtils.WatchStopInit();


            // 取得Assets目录.
            string strApplicationDataPath = @"C:\gitWorks\gitbranch_ios_pack\Assets";
            string strTestFile = @"C:\gitWorks\gitbranch_ios_pack\Assets\Game\Art\Textures\Activity\ChestActivity\img_close.png";

            // // 不带多线程的方法.
            // FindRefWithoutMulti findWithoutMulti = new FindRefWithoutMulti(strApplicationDataPath, strTestFile);
            // findWithoutMulti.Run();


            // StopWatchUtils.WatchStopInit();
            //
            // FindRefWithMulti findRefWithMulti = new FindRefWithMulti(strApplicationDataPath, strTestFile);
            // findRefWithMulti.Run();
            //
            // StopWatchUtils.WatchStopOnceEnd("FindRefWithMulti Handle Done!");

            // 开始只对Textures进行测试

            StopWatchUtils.WatchStopInit();

            string strTestDir = @"C:\gitWorks\gitbranch_ios_pack\Assets";
            string[] testTexs = Directory.GetFiles(strTestDir, "*.*", SearchOption.AllDirectories);

            List<string> totalLst = testTexs.ToList();


            // 这里本身的meta文件应该屏蔽掉 否则找不到文件.


            // 有些超特殊文件没有meta. 需要先排除掉.


            // // 这里只使用500个文件.
            List<string> lstHandleFiles = new List<string>();
            foreach (var eachFileName in totalLst)
            {
                if (Path.GetExtension(eachFileName) != ".meta")
                {
                    lstHandleFiles.Add(eachFileName);
                }
            }



            FindRefWithMulti findRefWithMulti = new FindRefWithMulti(strApplicationDataPath, lstHandleFiles);
            findRefWithMulti.Run();

            // Console.WriteLine("Check Here");
            StopWatchUtils.WatchStopOnceEnd("FindRefWithMulti Handle Done!");

            Console.ReadKey();
        }
    }
}
