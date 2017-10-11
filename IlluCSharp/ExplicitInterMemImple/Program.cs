using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplicitInterMemImple
{
    interface IIfc1
    {
        void PrintOut(string s);
    }

    interface IIfc2
    {
        void PrintOut(string s);
    }

    class MyClass : IIfc1, IIfc2
    {
        void IIfc1.PrintOut(string s)
        {
            Console.WriteLine("IIfc1: {0}", s);
        }

        void IIfc2.PrintOut(string s)
        {
            Console.WriteLine("IIfc2: {0}", s);
        }

        public void PrintOut(string s)
        {
            Console.WriteLine("object: {0}", s);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyClass mc = new MyClass();

            mc.PrintOut("object");

            IIfc1 ifc1 = (IIfc1)mc;
            ifc1.PrintOut("interface 1");

            IIfc2 ifc2 = (IIfc2)mc;
            ifc2.PrintOut("interface 2");


        }
    }
}
