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

            //Console.WriteLine("decimal.MinValue = {0}", decimal.MinValue);
            //Console.WriteLine("decimal.MaxValue = {0}", decimal.MaxValue);

            //Console.WriteLine();

            //Console.WriteLine("double.MinValue = {0}", double.MinValue);
            //Console.WriteLine("double.MaxValue = {0}", double.MaxValue);


            //if (ulong.MaxValue > float.MaxValue)
            //{
            //    Console.WriteLine("ulong.MaxValue > float.MaxValue");
            //}

            //float a = 1.999999f;

            ////decimal a = 1.99999999999999999999999999999999m;

            //int result = (int)a;

            ////int result = Convert.ToInt32(a);

            //Console.WriteLine("result = {0}", a);


            ////decimal result = Math.Ceiling(32.0m);

            //decimal result = (decimal)100 / (decimal)300 * (decimal)60;

            ////decimal result = (decimal)100 / (decimal)300;

            //int nResult = Convert.ToInt32(4.5m);

            //Console.WriteLine("result = {0}", nResult);


            //float fA = 1f;

            double dA = 1d;


            // 数字精度问题
            //long lA = 1862278065L;

            long lA = 18622780651862278L;

            var varCheck = dA * lA;

            Type trCheck = varCheck.GetType();

            long lWrong = (long)varCheck;

            Console.WriteLine("lWrong = {0}", lWrong);

        }
    }
}
