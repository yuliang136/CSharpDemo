using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullCoalescingOperator
{
    struct MyStruct
    {
        public int X;
        public int Y;

        public MyStruct(int xVal, int yVal)
        {
            X = xVal;
            Y = yVal;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //int? myI4 = null;
            //Console.WriteLine("myI4: {0}", myI4 ?? -1);

            //myI4 = 10;
            //Console.WriteLine("myI4: {0}", myI4 ?? -1);

            //int? i1 = null;
            //int? i2 = null;

            //if (i1 == i2)
            //{
            //    Console.WriteLine("Equal");
            //}

            //MyStruct mSStruct = new MyStruct(6, 11);

            Nullable<MyStruct> mSNull = new MyStruct(5, 10);

            //MyStruct? mSNull = new MyStruct(5, 10);

            //Console.WriteLine("mSStruct.X: {0}", mSStruct.X);
            //Console.WriteLine("mSStruct.Y: {0}", mSStruct.Y);

            Console.WriteLine("mSNull.X: {0}", mSNull.Value.X);
            Console.WriteLine("mSNull.Y: {0}", mSNull.Value.Y);
        }
    }
}
