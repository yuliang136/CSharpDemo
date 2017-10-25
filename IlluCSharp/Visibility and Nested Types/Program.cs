using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visibility_and_Nested_Types
{
    class SomeClass
    {
        int Field1 = 15;
        int Field2 = 20;

        MyNested mn = null;

        public void PrintMyMembers()
        {
            mn.PrintOuterMembers();
        }

        public SomeClass()
        {
            mn = new MyNested(this);
        }

        class MyNested
        {
            SomeClass sc = null;

            public MyNested(SomeClass SC)
            {
                sc = SC;
            }

            public void PrintOuterMembers()
            {
                Console.WriteLine("Field1: {0}", sc.Field1);
                Console.WriteLine("Field2: {0}", sc.Field2);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SomeClass MySC = new SomeClass();

            MySC.PrintMyMembers();
        }
    }
}
