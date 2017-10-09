using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaisingEvent
{
    // Declare the delegate
    delegate void Handler();

    // Publisher
    class Incrementer
    {
        // Create and publish an event.
        public event Handler CountedADozen;

        public void DoCount()
        {
            for (int i = 1; i < 100; i++)
            {
                if (i % 12 == 0 && CountedADozen != null)
                {
                    // Raise the event
                    CountedADozen();
                }
            }
        }
    }

    // Subscriber
    class Dozens
    {
        public int DozensCount
        {
            get;
            private set;
        }

        public Dozens(Incrementer incrementer)
        {
            DozensCount = 0;
            incrementer.CountedADozen += IncremenDozensCount;
        }

        void IncremenDozensCount()
        {
            DozensCount++;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Incrementer incrememter = new Incrementer();

            Dozens dozensCounter = new Dozens(incrememter);

            incrememter.DoCount();

            Console.WriteLine("Number of dozens = {0}", dozensCounter.DozensCount);
        }
    }
}
