using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinGanCi
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] argsArray = System.Environment.GetCommandLineArgs();

            MinGanCi mgc = new MinGanCi();
            mgc.Run(argsArray);
        }
    }
}
