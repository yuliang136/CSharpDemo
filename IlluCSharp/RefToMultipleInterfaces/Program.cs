using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefToMultipleInterfaces
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
        public void PrintOut(string s)
        {
            Console.WriteLine("Calling through: {0}", s);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyClass mc = new MyClass();

            IIfc1 ifc1 = (IIfc1)mc;
            IIfc2 ifc2 = (IIfc2)mc;

            mc.PrintOut("object");

            ifc1.PrintOut("interface 1");
            ifc2.PrintOut("interface 2");
        }
    }
}
