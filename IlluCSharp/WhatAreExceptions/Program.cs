using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatAreExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            //int x = 10, y = 0;
            //x /= y;

            try
            {
                int x = 10, y = 0;
                x /= y;

            }
            catch(DivideByZeroException e)
            {

                Console.WriteLine("Message: {0}", e.Message);
                Console.WriteLine("Source:: {0}", e.Source);
                Console.WriteLine("Stack: {0}", e.StackTrace);

                //Console.WriteLine("Handling all exceptions - Keep on Running");
            }

            Console.WriteLine("Continue");
        }
    }
}
