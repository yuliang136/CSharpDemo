using System;
using BaseClassNS;
using System.Reflection;

namespace UsesBaseClass
{
    class DerivedClass: MyBaseClass
    {

    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Assembly2.cs : " + Assembly.GetExecutingAssembly().FullName);

            //Console.WriteLine(Assembly.GetExecutingAssembly().FullName);

            //DerivedClass dc = new DerivedClass();
            //dc.PrintMe();

            //SquareWidget sq = new SquareWidget();

            //sq.SideLength = 5.0;

            //Console.WriteLine(sq.Area);

            Simple s = new Simple();


            Console.WriteLine(s.x);

            DerivedClass mdc = new DerivedClass();

            mdc.PrintMe();
            

            Console.ReadKey();
        }
    }
}
