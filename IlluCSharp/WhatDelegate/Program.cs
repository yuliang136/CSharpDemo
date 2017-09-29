using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatDelegate
{
    delegate void MyDel(int value); // Declare delegate TYPE.

    class Program
    {
        void PrintLow(int value)
        {
            Console.WriteLine("{0} - Low Value", value);
        }

        void PrintHigh(int value)
        {
            Console.WriteLine("{0} - High Value", value);
        }

        static void Main(string[] args)
        {
            // 使用一个对象的函数.
            Program program = new Program();

            MyDel del;

            Random rand = new Random();
            int randomValue = rand.Next(99);

            del = randomValue < 50
                    ? new MyDel(program.PrintLow)
                    : new MyDel(program.PrintHigh);

            del(randomValue);
                    
        }
    }
}
