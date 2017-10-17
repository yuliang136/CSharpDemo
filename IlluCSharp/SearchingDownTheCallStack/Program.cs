using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingDownTheCallStack
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass MCls = new MyClass();

            try
            {
                MCls.A();
            }
            catch (DivideByZeroException)
            {

                Console.WriteLine("catch clause in Main()");
            }
            finally
            {
                Console.WriteLine("fianlly clause in Main()");
            }

            Console.WriteLine("After try statement in Main.");
            Console.WriteLine(" -- Keep running.");
        }
    }

    class MyClass
    {
        public void A()
        {
            try
            {
                B();
            }
            catch (System.NullReferenceException)
            {

                Console.WriteLine("catch clause in A()");
            }
            finally
            {
                Console.WriteLine("finally clause in A()");
            }
        }

        void B()
        {
            int x = 10, y = 0;
            try
            {
                x /= y;
            }
            catch (System.IndexOutOfRangeException)
            {

                Console.WriteLine("catch clause in B()");
            }
            finally
            {
                Console.WriteLine("finally clause in B()");
            }
        }
    }
}
