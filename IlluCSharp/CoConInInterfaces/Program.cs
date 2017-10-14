using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoConInInterfaces
{
    class Animal 
    {
        public string Name;
    }

    class Dog : Animal
    { 
    }

    interface IMyIfc<out T>
    {
        T GetFirst();
    }

    class SimpleReturn<T> : IMyIfc<T>
    {
        // new 初始化数据.
        public T[] items = new T[2];
        public T GetFirst()
        {
            return items[0];
        }
    }


    class Program
    {
        static void DoSomething(IMyIfc<Animal> returner)
        {
            Console.WriteLine(returner.GetFirst().Name);
        }

        static void Main(string[] args)
        {
            SimpleReturn<Dog> dogReturner = new SimpleReturn<Dog>();

            dogReturner.items[0] = new Dog() { Name = "Avonlea" };

            //SimpleReturn<Animal> animalReturn = dogReturner;

            //IMyIfc<Dog> dogIMyIfc = dogReturner;
            //Console.WriteLine(dogIMyIfc.GetFirst().Name);

            IMyIfc<Animal> animalIMyIfc = dogReturner;
            Console.WriteLine(animalIMyIfc.GetFirst().Name);

            //DoSomething(dogReturner);

        }
    }
}
