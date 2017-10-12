using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsOperator
{
    class Employee : Person 
    {
    }

    class Person
    {
        public string Name = "Anonymous";
        public int Age = 25;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee bill = new Employee();
            Person p;

            p = bill as Person;
            if(p != null)
            {
                Console.WriteLine("Person Info: {0}, {1}", p.Name, p.Age);
            }

            //if (bill is Person)
            //{
            //    p = bill;
            //    Console.WriteLine("Person Info: {0}, {1}", p.Name, p.Age);
            //}
        }
    }
}
