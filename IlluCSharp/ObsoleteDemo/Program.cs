using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObsoleteDemo
{
    class Program
    {
        [Obsolete("Use method SuperPrintOut", false)]
        static void PrintOut(string str)
        {
            Console.WriteLine(str);
        }

        static void Main(string[] args)
        {
            PrintOut("Start of Main");
        }
    }
}
