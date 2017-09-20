﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectInitializers
{
    public class Point
    {
        public int X = 1;
        public int Y = 2;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Point pt1 = new Point();
            Point pt2 = new Point { X = 5, Y = 6 };

            Console.WriteLine("pt1: {0}, {1}", pt1.X, pt1.Y);
            Console.WriteLine("pt2: {0}, {1}", pt2.X, pt2.Y);
        }
    }
}
