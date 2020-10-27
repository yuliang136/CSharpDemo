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

            FindRefWithMulti findRefWithMulti = new FindRefWithMulti(strApplicationDataPath, strTestFile);
            findRefWithMulti.Run();

        }
    }
}
