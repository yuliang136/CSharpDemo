using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreEnums
{
    //enum FirstEnum
    //{
    //    Mem1,
    //    Mem2
    //}

    //enum SecondEnum
    //{
    //    Mem1,
    //    Mem2
    //}

    enum TrafficLight
    {
        Green,
        Yellow,
        Red
    }

    class Program
    {
        static void Main(string[] args)
        {
            //if (FirstEnum.Mem1 < FirstEnum.Mem2)
            //{
            //    Console.WriteLine("True");
            //}

            //if (FirstEnum.Mem1 < SecondEnum.Mem1)
            //{
            //    Console.WriteLine("True");
            //}

            Console.WriteLine(Enum.GetName(typeof(TrafficLight), 0));

            foreach (var name in Enum.GetNames(typeof(TrafficLight)))
            {
                Console.WriteLine(name);
            }
        }
    }
}
