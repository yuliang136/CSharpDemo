﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefToBase
{
    class MyBaseClass
    {
        public void Print()
        {
            Console.WriteLine("This is the base class.");
        }
    }

    class MyDerivedClass : MyBaseClass
    {
        new public void Print()
        {
            Console.WriteLine("This is the derived class");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyDerivedClass derived = new MyDerivedClass();
            MyBaseClass mybc = (MyBaseClass)derived;

            derived.Print();
            mybc.Print();
        }
    }
}
