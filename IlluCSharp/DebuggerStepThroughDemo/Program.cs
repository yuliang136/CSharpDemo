using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DebuggerStepThroughDemo
{
    class Program
    {
        int _x = 1;
        int X
        {
            get { return _x; }

            //[DebuggerStepThrough]
            set
            {
                _x = _x * 2;
                _x += value;
            }
        }

        public int Y { get; set; }

        //[DebuggerStepThrough]
        void IncrementFields()
        {
            X++;
            Y++;
        }

        static void Main(string[] args)
        {
            Program p = new Program();

            p.IncrementFields();
            p.X = 5;
            Console.WriteLine("X = {0}, Y = {1}", p.X, p.Y);

        }
    }
}
