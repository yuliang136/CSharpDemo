using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverridingOtherMember
{
    class MyBaseClass
    {
        private int _myInt = 5;
        virtual public int MyProperty
        {
            get { return _myInt; }
        }
    }

    class MyDerivedClass : MyBaseClass
    {
        private int _myInt = 10;
        override public int MyProperty
        {
            get { return _myInt; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyDerivedClass derived = new MyDerivedClass();
            MyBaseClass mybc = (MyBaseClass)derived;

            Console.WriteLine(derived.MyProperty);
            Console.WriteLine(mybc.MyProperty);
        }
    }
}
