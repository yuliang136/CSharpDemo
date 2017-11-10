using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            ulong m_Max = 50000000;

            ArrayList list = new ArrayList();
            Stopwatch watch = new Stopwatch();
            watch.Start();

            for (ulong i = 0; i < m_Max; i++)
            {
                list.Add(i);
            }

            watch.Stop();
            Console.WriteLine("ArrayList Time : " + watch.Elapsed);


            //Stopwatch watch = new Stopwatch();
            //List<ulong> uLongList = new List<ulong>();
            //watch.Start();
            //for (ulong i = 0; i < m_Max; i++)
            //{
            //    uLongList.Add(i);
            //}
            //watch.Stop();
            //Console.WriteLine("List<T> Time : " + watch.Elapsed);

        }
    }
}
