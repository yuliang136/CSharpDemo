using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covariance
{
    class Animal
    {
        public int Legs = 4;
    }

    class Dog : Animal
    {
    }

    delegate T Factory<out T>();

    class Program
    {
        static Dog MakeDog()
        {
            return new Dog();
        }

        static void Main(string[] args)
        {
            //Animal a1 = new Animal();
            //Animal a2 = new Dog();

            //Console.WriteLine("Number of dog legs: {0}", a2.Legs);

            Factory<Dog> dogMaker = MakeDog;

            Factory<Animal> animalMaker = dogMaker;

            //Animal a = dogMaker();

            Animal a = animalMaker();

            //Animal a = dogMaker();

            Console.WriteLine();
        }
    }
}
