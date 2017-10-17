using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatIsLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 2, 12, 5, 15 };

            IEnumerable<int> lowNums =
                                from n in numbers
                                where n < 10
                                select n;

            foreach (var x in lowNums)
            {
                Console.Write("{0}, ",x);
            }
        }
    }
}
