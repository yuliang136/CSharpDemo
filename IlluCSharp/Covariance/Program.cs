using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covariance
{
    class Animal
    {
        public int NumberOfLegs = 4;
    }

    class Dog : Animal
    {
        public int nDog;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Animal a1 = new Animal();
            Animal a2 = new Dog();

            Console.WriteLine("Number of dog legs: {0}", a2.NumberOfLegs);
        }
    }
}
