using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCloneMethod
{
    class A
    {
        public int Value = 5;
    }

    class Program
    {
        static void Main(string[] args)
        {
            //int[] intArr1 = { 1, 2, 3 };

            //int[] intArr2 = (int[])intArr1.Clone();

            //intArr2[0] = 100;
            //intArr2[1] = 200;
            //intArr2[2] = 300;

            //A[] AArray1 = new A[] { new A(), new A(), new A() };
            A[] AArray1 = { new A(), new A(), new A() };

            A[] AArray2 = (A[])AArray1.Clone();

            AArray2[0].Value = 100;
            AArray2[1].Value = 200;
            AArray2[2].Value = 300;


            Console.WriteLine();
        }
    }
}
