using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClasses
{
    static public class MyMath
    {
        public static float PI = 3.14f;
        public static bool IsOdd(int x)
        {
            return x % 2 == 1;
        }

        public static int Times2(int x)
        {
            return 2 * x;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int val = 3;
            Console.WriteLine("{0} is odd is {1}.", val, MyMath.IsOdd(val));
            Console.WriteLine("{0} * 2 = {1}", val, MyMath.Times2(val));
        }
    }
}
