using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheForeach
{
    class MyClass
    {
        public int MyField = 0;
    }

    class Program
    {
        static void Main(string[] args)
        {
            //int[] arr1 = { 10, 11, 12, 13 };

            //foreach (var item in arr1)
            //{
            //    //Console.WriteLine("Item Value: {0}", item);

            //    //item++;
            //}

            MyClass[] mcArray = new MyClass[4];

            for (int i = 0; i < mcArray.Length; i++)
            {
                mcArray[i] = new MyClass();
                mcArray[i].MyField = i;
            }

            foreach (MyClass item in mcArray)
            {
                item.MyField += 10;
            }

            foreach (MyClass item in mcArray)
            {
                Console.WriteLine("{0}", item.MyField);
            }
        }
    }
}
