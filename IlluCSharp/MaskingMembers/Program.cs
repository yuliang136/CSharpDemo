using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaskingMembers
{
    class SomeClass
    {
        public string Field1 = "SomeClass Field1";

        public void Method1(string value)
        {
            Console.WriteLine("SomeClass.Method1: {0}", value);
        }
    }

    class OtherClass : SomeClass
    {
        new public string Field1 = "OtherClass Field1";

        new public void Method1(string value)
        {
            Console.WriteLine("OtherClass.Method1: {0}", value);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            OtherClass oc = new OtherClass();

            oc.Method1(oc.Field1);
        }
    }
}
