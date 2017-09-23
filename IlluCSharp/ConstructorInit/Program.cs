using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorInit
{
    class MyClass
    {
        readonly int firstVar;
        readonly double secondVar;

        public string UserName;
        public int UserIdNumber;

        private MyClass()
        {
            firstVar = 20;
            secondVar = 30.5;
        }

        public MyClass(string firstName)
            : this()
        {
            UserName = firstName;
            UserIdNumber = -1;
        }

        public MyClass(int idNumber)
            : this()
        {
            UserName = "Anonymous";
            UserIdNumber = idNumber;
        }

    }

    class SecondClass : MyClass
    {

        public SecondClass(string strInput)
            : this()
        {

        }


        public SecondClass()
            : base("test")
        {

        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            //MyClass my = new MyClass(2);

            SecondClass sc = new SecondClass();

        }
    }
}
