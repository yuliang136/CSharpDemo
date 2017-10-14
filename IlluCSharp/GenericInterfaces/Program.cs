using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericInterfaces
{
    interface IMyIfc<T>
    {
        T ReturnIt(T inValue);
    }

    //class Simple<S> : IMyIfc<S>
    //{
    //    public S ReturnIt(S inValue)
    //    {
    //        return inValue;
    //    }
    //}

    //class Simple : IMyIfc<int>, IMyIfc<string>
    //{
    //    public int ReturnIt(int inValue)
    //    {
    //        return inValue;
    //    }

    //    public string ReturnIt(string inValue)
    //    {
    //        return inValue;
    //    }
    //}

    //class Simple<S> : IMyIfc<int>, IMyIfc<S>
    //{
 
    //}

    class Program
    {
        static void Main(string[] args)
        {
            //var trivInt = new Simple<int>();
            //var trivString = new Simple<string>();
            //Simple trivial = new Simple();

            //Console.WriteLine("{0}", trivInt.ReturnIt(5));
            //Console.WriteLine("{0}", trivString.ReturnIt("Hi there"));

            //Console.WriteLine("{0}", trivial.ReturnIt(5));
            //Console.WriteLine("{0}", trivial.ReturnIt("Hi there."));
        }
    }
}
