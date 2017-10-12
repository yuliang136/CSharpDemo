using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxingConversions
{
    class Program
    {
        static void Main(string[] args)
        {
            //int i = 12;

            //object oi = null;

            //oi = i;

            //Console.WriteLine("oi = {0}", oi);


            //int i = 10;

            //object oi = i;

            //Console.WriteLine("i: {0}, io: {1}", i, oi);

            //i = 12;
            //oi = 15;

            //Console.WriteLine("i: {0}, io: {1}", i, oi);


            int i = 10;
            object oi = i;

            int j = (int)oi;

            Console.WriteLine("i: {0}, oi: {1}, j: {2}", i, oi, j);
        }
    }
}
