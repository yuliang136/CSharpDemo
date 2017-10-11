using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaisingEvent
{
    // Declare the delegate
    //delegate void Handler();

    public class IncrementerEventArgs : EventArgs
    {
        public int IterationCount { get; set; }
    }

    // Publisher
    class Incrementer
    {
        // Create and publish an event.
        //public event Handler CountedADozen;
        //public event EventHandler CountedADozen;
        public event EventHandler<IncrementerEventArgs> CountedADozen;

        public void DoCount()
        {
            IncrementerEventArgs args = new IncrementerEventArgs();

            for (int i = 1; i < 100; i++)
            {
                if (i % 12 == 0 && CountedADozen != null)
                {
                    args.IterationCount = i;
                    // Raise the event
                    CountedADozen(this, args);
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

        void IncremenDozensCount(object source, IncrementerEventArgs e)
        {
            Console.WriteLine("Incremented at iteration: {0} in {1}", e.IterationCount, source.ToString());

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
