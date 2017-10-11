using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessingExplicitIMI
{
    interface IIfc1
    {
        void PrintOut(string s);
    }

    class MyClass : IIfc1
    {
        void IIfc1.PrintOut(string s)
        {
            Console.WriteLine("IIfc1");
        }

        public void Method1()
        {
            //PrintOut("...");
            //this.PrintOut("...");

            ((IIfc1)this).PrintOut("...");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyClass mc = new MyClass();
            mc.Method1();
        }
    }
}
