using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // 
            //string strHandle = @"F:\Lzyy115\Lzyy115FullPack\lzyy_1150_20170906\Assets\Resources\Assets\csv\achieve.bytes";


            string strHandle = @"csv\achieve.bytes";
            //configList[i] = configList[i].Substring(0, configList[i].LastIndexOf('.'));

            // 获得索引值.
            // 索引从0开始计数.
            // 当索引返回81时，从该索引到开头的字符个数应该+1
            int nLength = strHandle.LastIndexOf('.');

            //int nLength = strHandle.IndexOf('.');

            Console.WriteLine(nLength);


            // Length从1开始计数.
            // 这里直接用索引值当长度用, 相当于把找到的字符省略掉
            string strGet = strHandle.Substring(0, nLength);
        }
    }
}
