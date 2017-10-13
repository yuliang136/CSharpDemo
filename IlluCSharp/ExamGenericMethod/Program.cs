using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamGenericMethod
{
    class Simple
    {
        static public void ReverseAndPrint<T>(T[] arr)
        {
            Array.Reverse(arr);

            foreach (T item in arr)
            {
                Console.WriteLine("{0}, ", item.ToString());
            }

            Console.WriteLine("");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var intArray = new int[] { 3, 5, 7, 9, 11 };

            var stringArray = new string[] 
            {
                "first",
                "second",
                "third"
            };

            var doubleArray = new double[] { 3.567, 7.891, 2.345 };

            Simple.ReverseAndPrint<int>(intArray);
            Simple.ReverseAndPrint(intArray);

            Simple.ReverseAndPrint<string>(stringArray);
            Simple.ReverseAndPrint(stringArray);

            Simple.ReverseAndPrint<double>(doubleArray);
            Simple.ReverseAndPrint(doubleArray);
        }
    }
}
