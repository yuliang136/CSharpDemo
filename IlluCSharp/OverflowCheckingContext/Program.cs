using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverflowCheckingContext
{
    class Program
    {
        static void Main(string[] args)
        {
            //ushort sh = 200;
            //byte sb;

            //sb = unchecked((byte)sh);
            //Console.WriteLine("sb: {0}", sb);

            //try
            //{
            //    sb = checked((byte)sh);
            //    Console.WriteLine("sb: {0}", sb);
            //}
            //catch (Exception e)
            //{

            //    throw e;
            //}
            //finally
            //{

            //}

            byte sb;
            ushort sh = 2000;

            unchecked
            {
                sb = (byte)sh;
                Console.WriteLine("sb: {0}", sb);

                checked
                {
                    sb = (byte)sh;
                    Console.WriteLine("sb: {0}", sb);
                }
            }

        }
    }
}
