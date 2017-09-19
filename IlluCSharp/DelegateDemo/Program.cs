using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    public delegate void Print();

    class Program
    {
        public static void PrintMethod1()
        {
            Console.WriteLine("First Method");
        }

        public static void PrintMethod2()
        {
            Console.WriteLine("Second Method");
        }

        static void Main(string[] args)
        {
            Print print = PrintMethod1;

            print += PrintMethod2;

            //print();

            print -= PrintMethod1;

            print();

        }
    }
}
