using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverridingMethod
{
    class MyBaseClass
    {
        virtual public void Print()
        {
            Console.WriteLine("This is the base class.");
        }
    }

    class MyDerivedClass : MyBaseClass
    {
        public override void Print()
        {
            Console.WriteLine("This is the derived class.");
        }
    }

    class SecondDerived : MyDerivedClass
    {
        new public void Print()
        {
            Console.WriteLine("This is the second derived class.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SecondDerived derived = new SecondDerived();

            MyBaseClass mybc = (MyBaseClass)derived;

            derived.Print();

            mybc.Print();
        }
    }
}
