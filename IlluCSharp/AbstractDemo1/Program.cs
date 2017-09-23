using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractDemo1
{
    abstract class AbClass
    {
        public void IdentifyBase()
        {
            Console.WriteLine("I am AbClass");
        }

        abstract public void IdentifyDerived();
    }

    class DerivedClass : AbClass
    {
        public override void IdentifyDerived()
        {
            Console.WriteLine("I am DerivedClass");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //AbClass a = new AbClass();

            DerivedClass b = new DerivedClass();
            b.IdentifyBase();
            b.IdentifyDerived();
        }
    }
}
