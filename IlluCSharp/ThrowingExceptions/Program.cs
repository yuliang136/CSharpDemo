﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThrowingExceptions
{
    class MyClass
    {
        public static void PrintArg(string arg)
        {
            try
            {
                try
                {
                    if (arg == null)
                    {
                        ArgumentNullException myEx = new ArgumentNullException("arg");
                        throw myEx;
                    }
                    Console.WriteLine(arg);
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine("Inner Catch: {0}", e.Message);
                    throw;
                }
            }
            catch
            {
                Console.WriteLine("Outer Catch: Handling an Exception.");
            }

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string s = null;
            MyClass.PrintArg(s);

            //MyClass.PrintArg("Hi there!");
        }
    }
}
