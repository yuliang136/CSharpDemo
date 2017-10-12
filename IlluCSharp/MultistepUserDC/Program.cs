using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultistepUserDC
{
    class Employee : Person { }

    class Person
    {
        public string Name;
        public int Age;

        public static implicit operator int(Person p)
        {
            return p.Age;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee bill = new Employee();

            bill.Name = "William";
            bill.Age = 25;

            float fVar = bill;

            Console.WriteLine("Person Info: {0}, {1}", bill.Name, fVar);
        }
    }
}
