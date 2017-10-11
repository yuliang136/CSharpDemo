using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritedMemberAsImplement
{
    interface IIfc1
    {
        void PrintOut(string s);
    }

    class MyBaseClass
    {
        public void PrintOut(string s)
        {
            Console.WriteLine("Calling through:  {0}", s);
        }
    }

    class Derived : MyBaseClass, IIfc1
    {
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            Derived d = new Derived();
            d.PrintOut("object.");

            IIfc1 ifc1 = d as IIfc1;
            if (ifc1 != null)
            {
                ifc1.PrintOut("IIfc1");
            }
        }
    }
}
