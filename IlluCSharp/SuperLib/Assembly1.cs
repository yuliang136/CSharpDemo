using System;
using System.Reflection;


namespace BaseClassNS
{
    public struct Simple
    {
        public int x;
        public int y;
    }

    public class MyBaseClass
    {
        public void PrintMe()
        {
            Console.WriteLine("I am MyBaseClass");

            Console.WriteLine("I am MyBaseClass : " + Assembly.GetExecutingAssembly().FullName);
        }
    }
}
