using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObsoleteAttribute
{
    class Program
    {
        [Obsolete("Use method SuperPrintOut")]
        static void PrintOut(string str)
        {
            Console.WriteLine(str);
        }

        static void Main(string[] args)
        {
            

        }
    }
}
