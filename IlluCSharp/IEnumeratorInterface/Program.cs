using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumeratorInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] MyArray = { 10, 11, 12, 13 };

            IEnumerator ie = MyArray.GetEnumerator();

            while (ie.MoveNext())
            {
                int i = (int)ie.Current;

                Console.WriteLine("{0}", i);
            }
        }
    }
}
