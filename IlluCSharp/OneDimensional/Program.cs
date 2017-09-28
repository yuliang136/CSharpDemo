using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDimensional
{
    class Program
    {
        static void Main(string[] args)
        {
            ////long[] secondArray;

            ////long[3,2,6] secondArray;

            //// Declare the array.
            //int[] myIntArray;

            //// Instantiate the array.
            //myIntArray = new int[4];

            //for (int i = 0; i < myIntArray.Length; i++)
            //{
            //    myIntArray[i] = i * 10;
            //}

            ////for (int i = 0; i < myIntArray.Length; i++)
            ////{
            ////    Console.WriteLine("Value of element {0} = {1}", i, myIntArray[i]);
            ////}

            //int[] arr1 = { 10, 20, 30 };

            //int[,] arr = {
            //                 {0, 1, 2},
            //                 {10, 11,12}
            //             };

            //var intArr2 = new[] { 10, 20, 30, 40 };
            //var intArr4 = new[,] { { 10, 1 }, { 2, 10 }, { 11, 9 } };
            //var sArr2 = new[] {"life", "libety"};


            var arr = new int[,] { 
                                    {0,1,2,4},
                                    {10,11,12,20},
                                    {10,11,12,21}
                                    };

            // 从哪里知道arr有几组元素
            Console.WriteLine(arr.Rank);

            int a = arr.GetLength(0);
            int b = arr.GetLength(1);

            Console.WriteLine(a);
            Console.WriteLine(b);

            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    Console.WriteLine("Element [{0},{1}] is {2}", i, j, arr[i, j]);
                }
            }
            


            // 每一组有多少个元素.

            Console.WriteLine();
        }
    }
}
