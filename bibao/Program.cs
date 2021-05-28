using System;

namespace bibao
{
    class Program
    {
        // 定义一个Calc委托类型, 计算a*b
        private delegate int Calc(int a, int b);

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //Console.WriteLine(GetClosureFunction()(30));
            //Console.WriteLine("Check here");
            //// 这里本质还是Delegate.
            //Action<int, string> eat = Eat;
            //eat(5, "Apple");
            //// 这样可以把eat指向不同的函数.
            //// 从而可以不改变eat(5, "Apple")这种函数调用.

            Calc calc = calcMul;
            Console.WriteLine(calc(10, 12));

        }

        private static int calcMul(int a, int b)
        {
            return a * b;
        }

        private static void Eat(int num, string name)
        {
            Console.WriteLine($"I eat {num} 个 {name} ");
        }

        /// <summary>
        /// 这里的Func<int, int>本身是什么意思.
        /// </summary>
        /// <returns></returns>
        static Func<int, int> GetClosureFunction()
        {
            int val = 10;

            Func<int, int> internalAdd = x => x + val;

            Console.WriteLine(internalAdd(10));

            val = 30;

            Console.WriteLine(internalAdd(10));

            return internalAdd;

        }
    }
}
