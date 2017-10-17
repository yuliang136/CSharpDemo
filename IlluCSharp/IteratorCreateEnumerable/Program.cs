using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorCreateEnumerable
{
    class MyClass
    {
        //public IEnumerator<string> GetEnumerator()
        //{
        //    IEnumerable<string> myEnumerable = BlackAndWhite();
        //    return myEnumerable.GetEnumerator();
        //}

        public IEnumerable<string> BlackAndWhite()
        {
            yield return "black";
            yield return "gray";
            yield return "white";
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            MyClass mc = new MyClass();

            foreach (string shade in mc.BlackAndWhite())
            {
                Console.Write("{0} ", shade);
            }
                
        }
    }
}
