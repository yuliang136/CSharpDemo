using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifiersOnAccessors
{
    class Person
    {
        public string Name { get; private set; }

        public Person(string name)
        {
            this.Name = name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person("Capt. Ernest Evans");

            Console.WriteLine("Person's name is {0}", p.Name);

            //p.Name = "11";
        }
    }
}
