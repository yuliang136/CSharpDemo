using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesWithReference
{
    delegate void MyDel(ref int X);

    class Program
    {
        public void Add2(ref int x) 
        {
            x += 2;
        }

        public void Add3(ref int x)
        {
            x += 3;
        }

        //static void Main(string[] args)
        //{
        //}

        static void Main()
        {
            Program mc = new Program();

            MyDel mDel = mc.Add2;
            mDel += mc.Add3;
            mDel += mc.Add2;

            int x = 5;
            mDel(ref x);

            Console.WriteLine("Value: {0}", x);
        }
    }
}
