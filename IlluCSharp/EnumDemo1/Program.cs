using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumDemo1
{
    enum TrafficLight : int
    {
        Green = 0,
        Yellow = 1,
        Red = 2
    }

    class Program
    {
        static void Main(string[] args)
        {
            TrafficLight t1 = TrafficLight.Red;
            TrafficLight t2 = TrafficLight.Green;
            TrafficLight t3 = t2;

            Console.WriteLine(t1);
            Console.WriteLine(t2);
            Console.WriteLine(t3);

            //string strShow = t1;
        }
    }
}
