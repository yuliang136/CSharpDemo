using System;
using System.Reflection;


namespace BaseClassNS
{
    public class MyBaseClass
    {
        public void PrintMe()
        {
            Console.WriteLine("I am MyBaseClass");

            Console.WriteLine("I am MyBaseClass : " + Assembly.GetExecutingAssembly().FullName);
        }
    }
}
