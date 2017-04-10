using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMuliBC
{
    class Program
    {
        static void Main(string[] args)
        {
            OpenMultiBC omb = new OpenMultiBC();
            omb.Open(@"F:\CompareCSV\trunkCSV", @"F:\CompareCSV\outCSV");
        }
    }
}
