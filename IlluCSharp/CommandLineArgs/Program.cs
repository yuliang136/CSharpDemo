using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineArgs
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string s in args)
            {
                Console.WriteLine(s);
            }
        }
    }
}
