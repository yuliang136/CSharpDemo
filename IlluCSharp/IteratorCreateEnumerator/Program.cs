using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorCreateEnumerator
{
    class MyClass
    {
        public IEnumerator<string> GetEnumerator()
        {
            return BlackAndWhite();
        }

        public IEnumerator<string> BlackAndWhite()
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

            foreach (string shade in mc)
            {
                Console.WriteLine(shade);
            }
        }
    }
}
