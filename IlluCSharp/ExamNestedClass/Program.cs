using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamNestedClass
{
    class MyClass
    {
        class MyCounter
        {
            public int Count
            {
                get;
                private set;
            }

            public static MyCounter operator ++(MyCounter current)
            {
                current.Count++;

                return current;
            }
        }

        private MyCounter counter;

        public MyClass()
        {
            counter = new MyCounter();
        }

        public int Incr()
        {
            return (counter++).Count;
        }

        public int GetValue()
        {
            return counter.Count;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyClass mc = new MyClass();

            mc.Incr();
            mc.Incr();

            Console.WriteLine("Total: {0}", mc.GetValue());
        }
    }
}
