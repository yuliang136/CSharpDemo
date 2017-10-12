using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WuChaCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            //float a = 0.65f;
            //float b = 0.6f;

            //float c = a - b;

            //Console.WriteLine("c = {0}", c);

            //// 乘以100 再转为整数 就会产生相对很大的误差.

            //if (c == 0.05)
            //{
            //    Console.WriteLine("c == 0.05");
            //}

            //c = c * 100;

            //int result = (int)c;

            //// 正确结果应该是5.
            //Console.WriteLine("result = {0}", result);


            //decimal a = 0.65m;
            //decimal b = 0.6m;

            //decimal c = a - b;

            //Console.WriteLine("c = {0}", c);

            //// 乘以100 再转为整数 就会产生相对很大的误差.

            //c = c * 100;

            //int result = (int)c;

            //// 正确结果应该是5.
            //Console.WriteLine("result = {0}", result);



            

            //double dd = 10000000000000000000000d;

            //dd += 1;

            //Console.WriteLine("{0:G50}", dd);


            //decimal dd = 10000000000000000000000m;
            //dd += 1;
            //Console.WriteLine("{0:G50}", dd);

            //decimal dd = 10000000000000000000000000000m;

            //dd += 0.1m;

            //Console.WriteLine("{0:G50}", dd);

            Console.WriteLine("decimal.MinValue = {0}", decimal.MinValue);
            Console.WriteLine("decimal.MaxValue = {0}", decimal.MaxValue);

            Console.WriteLine();

            //Console.WriteLine("double.MinValue = {0}", double.MinValue);
            //Console.WriteLine("double.MaxValue = {0}", double.MaxValue);

            

        }
    }
}
