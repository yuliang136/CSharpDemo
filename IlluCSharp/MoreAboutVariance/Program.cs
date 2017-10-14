using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreAboutVariance
{
    class Animal
    {
        public int Legs = 4;
    }

    class Dog : Animal
    { 
    }


    class Program
    {
        delegate T Factory<out T>();

        static Dog MakeDog()
        {
            return new Dog();
        }



        static void Main(string[] args)
        {
            //Factory<Animal> animalMaker1 = MakeDog;
            //Animal a = animalMaker1();

            //Factory<Dog> dogMaker = MakeDog;
            //Factory<Animal> animalMaker2 = dogMaker;

            Factory<Animal> animalMaker3 = new Factory<Dog>(MakeDog);

            Console.WriteLine();


        }
    }
}
