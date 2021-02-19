using System;

namespace GenericDemo
{

    /// <summary>
    /// 通用的Generic数组类
    /// </summary>
    public class MyGenericArray<T>
    {
        private T[] array;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="size"></param>
        public MyGenericArray(int size)
        {
            array = new T[size];
        }

        /// <summary>
        /// 获得值
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T getItem(int index)
        {
            return array[index];
        }

        /// <summary>
        /// 处理的类型都是未知的. 设置值
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void setItem(int index, T value)
        {
            array[index] = value;
        }
    }


    class Program
    {

        static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }


        static void Main(string[] args)
        {
            
            // // 声明一个整数数组
            // MyGenericArray<int> intArray = new MyGenericArray<int>(5);
            //
            //
            // for (int i = 0; i < 5; i++)
            // {
            //     intArray.setItem(i, i*5);
            // }
            //
            // for (int i = 0; i < 5; i++)
            // {
            //     Console.Write(intArray.getItem(i) + " ");
            // }
            // Console.WriteLine();
            //
            //
            // // 字符数组
            // MyGenericArray<char> charArray = new MyGenericArray<char>(5);
            // for (int i = 0; i < 5; i++)
            // {
            //     charArray.setItem(i, (char)(i + 97));
            // }
            //
            // for (int i = 0; i < 5; i++)
            // {
            //     Console.Write(charArray.getItem(i) + " ");
            // }
            // Console.WriteLine();


            int a, b;
            char c, d;

            a = 10;
            b = 20;
            c = 'I';
            d = 'V';

            // 在交换之前显示值
            Console.WriteLine("Int values before calling swap:");
            Console.WriteLine("a = {0}, b = {1}", a, b);
            Console.WriteLine("Char values before calling swap:");
            Console.WriteLine("c = {0}, d = {1}", c, d);

            Swap<int>(ref a, ref b);
            Swap<char>(ref c, ref d);


            // 在交换之后显示值
            Console.WriteLine("Int values after calling swap:");
            Console.WriteLine("a = {0}, b = {1}", a, b);
            Console.WriteLine("Char values after calling swap:");
            Console.WriteLine("c = {0}, d = {1}", c, d);


        }
    }
}
