using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousMethods
{


    class Program
    {
        //public static int Add20(int x)
        //{
        //    return x + 20;
        //}

        delegate int OtherDel(int InParam);

        static void Main(string[] args)
        {
            //OtherDel del = Add20;

            OtherDel del = delegate(int x)
            {
                return x + 20;
            };

            Console.WriteLine("{0}", del(5));
            Console.WriteLine("{0}", del(6));
        }
    }
}
