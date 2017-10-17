using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinallyBlock
{
    class Program
    {
        static void Main(string[] args)
        {
            int inVal = 5;

            try
            {
                if (inVal < 10)
                {
                    Console.Write("First Branch - ");
                    return;
                }
                else
                {
                    Console.Write("Second Branch - ");
                }
            }
            finally
            {
                Console.WriteLine("In finally statement");
            }

        }
    }
}
