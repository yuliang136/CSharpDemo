using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffClassImpleInterface
{
    interface ILiveBirth
    {
        string BabyCalled();
    }

    class Animal { }

    class Cat : Animal, ILiveBirth
    {
        string ILiveBirth.BabyCalled()
        {
            return "kitten";
        }
    }

    class Dog : Animal, ILiveBirth
    {
        string ILiveBirth.BabyCalled()
        {
            return "puppy";
        }
    }

    class Bird : Animal 
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            Animal[] animalArray = new Animal[3];

            animalArray[0] = new Cat();
            animalArray[1] = new Bird();
            animalArray[2] = new Dog();

            foreach (Animal a in animalArray)
            {
                ILiveBirth b = a as ILiveBirth;
                if (b != null)
                {
                    Console.WriteLine("Baby is called: {0}", b.BabyCalled());
                }
            }
        
        }
    }
}
