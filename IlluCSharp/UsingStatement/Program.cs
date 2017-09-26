using System;
using System.IO;

namespace UsingStatement
{
    class Program
    {
        static void Main(string[] args)
        {
            using (TextWriter tw = File.CreateText("Lincoln.txt"))
            {
                tw.WriteLine("Four score and ");
            }

            using (TextReader tr = File.OpenText("Lincoln.txt"))
            {
                string InputString;

                while (null != (InputString = tr.ReadLine()))
                {
                    Console.WriteLine(InputString);
                }
            }


        }
    }
}
