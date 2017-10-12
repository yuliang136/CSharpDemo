using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDefinedConversion
{
    class Person
    {
        public string Name;
        public int Age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public static explicit operator int(Person p)
        {
            return p.Age;
        }

        public static explicit operator Person(int i)
        {
            return new Person("Nemo", i);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Person bill = new Person("bill", 25);

            int age = (int)bill;

            Console.WriteLine("Person Info: {0}, {1}", bill.Name, age);


            Person anon = (Person)35;
            Console.WriteLine("Person Info: {0}, {1}", anon.Name, anon.Age);

        }
    }
}
