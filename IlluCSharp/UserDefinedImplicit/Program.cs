using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDefinedImplicit
{
    class LimitedInt
    {
        const int MaxValue = 100;
        const int MinValue = 0;

        private int _theValue = 0;
        public int TheValue
        {
            get { return _theValue; }
            set
            {
                if (value < MinValue)
                {
                    value = MinValue;
                }
                else
                {
                    _theValue = value > MaxValue ? MaxValue : value;
                }
            }
        }


        public static explicit operator int(LimitedInt li)
        {
            return li.TheValue;
        }

        public static explicit operator LimitedInt(int x)
        {
            LimitedInt li = new LimitedInt();
            li.TheValue = x;
            return li;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //LimitedInt li = 500;
            //int value = li;

            LimitedInt li = (LimitedInt)500;

            int value = (int)li;

            Console.WriteLine("li: {0}, value:{1}", li.TheValue, value);
        }
    }
}
