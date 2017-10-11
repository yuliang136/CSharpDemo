using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComarableExam
{
    class MyClass : IComparable
    {
        public int TheValue;

        public int CompareTo(object obj)
        {
            MyClass mc = (MyClass)obj;

            // 对象的值和参数的值做比较.
            if (this.TheValue < mc.TheValue)
            {
                return -1;
            }
            else if (this.TheValue > mc.TheValue)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }

    class Program
    {
        static void PrintOut(string s, MyClass[] mc)
        {
            Console.Write(s);

            foreach (var m in mc)
            {
                Console.Write("{0} ", m.TheValue);
            }

            Console.WriteLine("");
        }

        static void Main(string[] args)
        {
            var myInt = new[] { 20, 4, 16, 9, 2 };

            MyClass[] mcArr = new MyClass[5];

            for (int i = 0; i < myInt.Length; i++)
            {
                mcArr[i] = new MyClass();
                mcArr[i].TheValue = myInt[i];
            }

            PrintOut("Initial Order: ", mcArr);

            Array.Sort(mcArr);

            PrintOut("Sorted Order: ", mcArr);
        }
    }
}
