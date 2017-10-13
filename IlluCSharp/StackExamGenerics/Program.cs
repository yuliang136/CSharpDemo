using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExamGenerics
{
    class MyStack<T>
    {
        T[] StackArray;

        // 为0时 没有元素 指向栈顶的位置.
        int StackPointer = 0;

        const int MaxStack = 10;
        bool IsStackFull
        {
            get
            {
                return StackPointer >= MaxStack;
            }
        }

        bool IsStackEmpty
        {
            get
            {
                return StackPointer <= 0;
            }
        }

        public void Push(T x)
        {
            if (!IsStackFull)
            {
                // 改变栈顶位置 之后把指针+1
                StackArray[StackPointer++] = x;
            }
        }

        public T Pop()
        {
            // 出栈时。
            // 如果不为空 StackPointer至少为1

            // 如果没有元素时 返回一个默认值？
            // 出栈时有个问题 只是返回了相应的元素 没有把栈里元素剔除.

            return (!IsStackEmpty) ? StackArray[--StackPointer] : StackArray[0];
        }

        public MyStack()
        {
            StackArray = new T[MaxStack];
        }

        public void Print()
        {
            for (int i = StackPointer-1; i >= 0; i--)
            {
                Console.WriteLine("    Value: {0}", StackArray[i]);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> StackInt = new MyStack<int>();
            MyStack<string> StackString = new MyStack<string>();

            StackInt.Push(5);



            int nCheck = StackInt.Pop();
            Console.WriteLine("nCheck = {0}", nCheck);

            nCheck = StackInt.Pop();
            Console.WriteLine("nCheck = {0}", nCheck);

            //StackInt.Push(3);
            //StackInt.Push(5);
            //StackInt.Push(7);
            //StackInt.Push(9);
            //StackInt.Print();

            //StackString.Push("This is fun");
            //StackString.Push("Hi there! ");
            //StackString.Print();

        }
    }
}
