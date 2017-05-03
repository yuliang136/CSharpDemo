using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptTool
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] argsArray = System.Environment.GetCommandLineArgs();

            HandleEncryptTool het = new HandleEncryptTool();
            het.Run(argsArray);

            Console.Read();
        }
    }
}
