using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotoStatement
{
    class Program
    {
        static void Main(string[] args)
        {
            //{
            //    goto HaHa;
            //}
            {
            HaHa: Console.WriteLine("Here");
            int i = 50;
            }

            goto HaHa;
            



            Console.WriteLine("Before");





            Console.WriteLine("Over");
        }
    }
}
