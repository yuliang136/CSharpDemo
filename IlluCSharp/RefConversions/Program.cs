using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefConversions
{
    class A
    {
        public int Field1;
    }

    class B : A 
    {
        public int Field2;
    }



    class Program
    {
        static void Main(string[] args)
        {
            //B myVar1 = new B();

            //A myVar2 = (A)myVar1;

            //Console.WriteLine("{0}", myVar2.Field1);
            ////Console.WriteLine("{0}", myVar2.Field2);

            //A myVar1 = new A();

            //B myVar2 = (B)myVar1;



            B myVar1 = new B();
            A myVar2 = myVar1;
            B myVar3 = (B)myVar2;
        }
    }
}
