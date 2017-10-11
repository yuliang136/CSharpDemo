using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementMultiInterfaces
{
    interface IDataRetrieve
    {
        int GetData();
    }

    interface IDataStore
    {
        void SetData(int x);
    }

    class MyData : IDataRetrieve, IDataStore
    {
        int Mem1;
        public int GetData()
        {
            return Mem1;
        }

        public void SetData(int x)
        {
            Mem1 = x;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyData data = new MyData();
            data.SetData(5);
            Console.WriteLine("Value = {0}", data.GetData());
        }
    }
}
