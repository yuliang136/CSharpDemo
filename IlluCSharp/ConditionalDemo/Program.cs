#define DoTrace

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace ConditionalDemo
{
    class Program
    {
        [Conditional("DoTrace")]
        static void TraceMessage(string str)
        {
            Console.WriteLine(str);
        }

        static void Main(string[] args)
        {
            TraceMessage("Start of Main");
            Console.WriteLine("Doing work in Main.");
            TraceMessage("End of Main");

        }
    }
}
