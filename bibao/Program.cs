using System;

namespace bibao
{
    class Program
    {
        // 定义一个Calc委托类型, 计算a*b
        //private delegate int Calc(int a, int b);

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // 调用GetClosureFunction()返回一个Func<int,int> 再传入一个int参数.
            // 那么即使在外部 GetClosureFunction里引用到的val值的空间不会被清除掉？

            // val 作为一个局部变量。它的生命周期本应该在GetClosureFunction执行完毕后就结束了。为什么还会对之后的结果产生影响呢?

            Console.WriteLine(GetClosureFunction()(30));
            Console.WriteLine("Check here");



            //// 这里本质还是Delegate.
            //Action<int, string> eat = Eat;
            //eat(5, "Apple");
            //// 这样可以把eat指向不同的函数.
            //// 从而可以不改变eat(5, "Apple")这种函数调用.

            //Calc calc = calcMul;

            //Func<int, int, int> calc = delegate (int x, int y)
            //  {
            //      return x * y;
            //  };

            //Func<int, int, int> calc = (x, y) =>
            //{
            //    return x * y;
            //};
            //Console.WriteLine(calc(10, 12));

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

            // Func这里简化掉 第二个参数为返回值.
            // 后面是个Lambda表达式.
            // 两个点都是语法糖.

            // 这里的val使用GetClosureFunction函数的局部变量val.
            // 当internalAdd引用到此函数的外部变量val时 就自动定义是一个闭包.
            Func<int, int> internalAdd = x => x + val;



            Console.WriteLine(internalAdd(10));

            // 这个值改变之后 直接影响了internalAdd内的输出.
            // 说明internalAdd内对val的引用不是值的传递
            // 是个地址引用到val的地址, 再使用时再取值出来处理.
            val = 30;

            // 局部变量的改变影响了委托的执行结果.
            Console.WriteLine(internalAdd(10));

            return internalAdd;

        }
    }
}
