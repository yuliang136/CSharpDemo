using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExample
{
    delegate void PrintFunction();

    class Test
    {
        public void Print1()
        {
            Console.WriteLine("Print1 -- instance");
        }

        public static void Print2()
        {
            Console.WriteLine("Print2 -- static");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Test t = new Test();

            PrintFunction pf;

            pf = t.Print1;

            pf += Test.Print2;
            pf += t.Print1;
            pf += Test.Print2;

            if (null != pf)
            {
                pf();
            }
            else
            {
                Console.WriteLine("Delegate is empty");
            }
        }
    }
}
