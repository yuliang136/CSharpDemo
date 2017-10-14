using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contravariance
{
    class Animal
    {
        public int NumberOfLegs = 4;
    }

    class Dog : Animal { }

    class Program
    {
        delegate void Action1<in T>(T a);

        static void ActOnAnimal(Animal a)
        {
            Console.WriteLine(a.NumberOfLegs);
        }

        static void Main(string[] args)
        {
            Action1<Animal> act1 = ActOnAnimal;

            Action1<Dog> dog1 = act1;

            //dog1(new Dog());

            act1(new Dog());
        }
    }
}
