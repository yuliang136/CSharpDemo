using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverridingOther
{
    class MyBaseClass
    {
        private int _myInt = 5;
    }

    class MyDerivedClass : MyBaseClass
    {
        // private 成员变量不会继承.
        private int _myInt = 10;
        
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
