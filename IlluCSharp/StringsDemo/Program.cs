using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //string s = "Hi there.";

            //Console.WriteLine("{0}", s.ToUpper());
            //Console.WriteLine("{0}", s);

            //string s1 = "hi there!  this, is: a string.";

            //char[] delimiters = { ' ', '!', ',', ':', '.'};

            //string[] words = s1.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            //Console.WriteLine("Word Count: {0}\n\rThe Words...", words.Length);

            //foreach (string s in words)
            //{
            //    Console.WriteLine("     {0}", s);
            //}

            StringBuilder sb = new StringBuilder("Hi there.");
            Console.WriteLine("{0}", sb.ToString());

            sb.Replace("Hi", "Hello");
            Console.WriteLine("{0}", sb.ToString());

        }
    }
}
