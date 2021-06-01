using System;

namespace DefaultModifier
{

    /// <summary>
    /// 这里类的默认修饰符应该是public?
    /// </summary>
    class TestA
    {
        // 这里必须显式设置
        public int testa;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            TestA a = new TestA();
            a.testa = 100;


        }
    }
}
