using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleJaggedArray
{
    class Program
    {
        public static void PrintArray(int[] a)
        {
            foreach (var x in a)
            {
                Console.Write("{0} ", x);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            //int total = 0;

            //int[][] arr1 = new int[2][];

            //arr1[0] = new int[] { 10, 11 };
            //arr1[1] = new int[] { 12, 13, 14 };

            //foreach (int[] array in arr1)
            //{
            //    Console.WriteLine("Starting new array");

            //    foreach (int item in array)
            //    {
            //        total += item;
            //        Console.WriteLine(" Item:{0}, Current Total: {1}", item, total);
            //    }
            //}

            int[] arr = new int[] { 15, 20, 5, 25, 10 };

            PrintArray(arr);

            Array.Sort(arr);

            PrintArray(arr);

            Array.Reverse(arr);

            PrintArray(arr);

            Console.WriteLine("Rank = {0}, Length = {1}", arr.Rank, arr.Length);

            Console.WriteLine("GetLength(0) = {0}", arr.GetLength(0));

            Console.WriteLine("GetType() = {0}", arr.GetType());
        }
    }
}
