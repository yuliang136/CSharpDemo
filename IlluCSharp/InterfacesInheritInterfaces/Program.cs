using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesInheritInterfaces
{
    interface IDataRetrieve
    {
        int GetData();
    }

    interface IDataStore
    {
        void SetData(int x);
    }

    interface IDataIO : IDataRetrieve, IDataStore
    { 
    }

    class MyData : IDataIO
    {
        int nPrivateData;

        public int GetData()
        {
            return nPrivateData;
        }

        public void SetData(int x)
        {
            nPrivateData = x;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyData data = new MyData();

            data.SetData(5);

            Console.WriteLine("{0}", data.GetData());
        }
    }
}
