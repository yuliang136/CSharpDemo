using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssigningStruct
{
    struct Simple
    {
        public int X;
        public int Y;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Simple ss1;
            Simple ss2;

            ss1.X = 5;
            ss1.Y = 10;

            ss2 = ss1;

            Console.WriteLine("here");
        }
    }
}
