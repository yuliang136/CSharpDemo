using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexerEmployee
{
    class Employee
    {
        public string LastName;
        public string FirstName;
        public string CityOfBirth;

        public string this[int index]
        {
            set
            {
                switch (index)
                {
                    case 0: LastName = value;
                        break;
                    case 1: FirstName = value;
                        break;
                    case 2: CityOfBirth = value;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException("index");
                }
            }

            get
            {
                switch (index)
                {
                    case 0: return LastName;
                    case 1: return FirstName;
                    case 2: return CityOfBirth;

                    default:
                        throw new ArgumentOutOfRangeException("index");

                }
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Employee();

            emp1[0] = "Doe";
            emp1[1] = "Jane";
            emp1[2] = "Dallas";

            Console.WriteLine("{0}", emp1[0]);
            Console.WriteLine("{0}", emp1[1]);
            Console.WriteLine("{0}", emp1[2]);
        }
    }
}
