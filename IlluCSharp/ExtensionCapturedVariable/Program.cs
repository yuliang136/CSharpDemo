using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionCapturedVariable
{
    delegate void MyDel();

    class Program
    {
        static void Main(string[] args)
        {
            MyDel mDel;
            {
                int x = 5;
                mDel = delegate
                {
                    Console.WriteLine("Value of x: {0}", x);
                };
            }

            //Console.WriteLine("Value of x: {0}", x);

            if (null != mDel)
            {
                mDel();
            }
        }
    }
}
