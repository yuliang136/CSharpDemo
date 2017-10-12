using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastingExam
{
    class Program
    {
        static void Main(string[] args)
        {
            //ushort sh = 10;

            //byte sb = sh;

            //byte sb = 10;

            //ushort sh = sb;

            //Console.WriteLine("Value = {0}", sh);


            ushort sh = 10;
            byte sb = (byte)sh;
            Console.WriteLine("sb:  {0} = 0x{0:X}", sb);

            sh = 1365;
            sb = (byte)sh;
            Console.WriteLine("sb:  {0} = 0x{0:X}", sb);

        }
    }
}
