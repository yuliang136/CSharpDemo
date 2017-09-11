using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AssetDownloadTool
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] argsArray = System.Environment.GetCommandLineArgs();

            AssetDownloadTool adt = new AssetDownloadTool();
            adt.Run(argsArray);
        }
    }
}
