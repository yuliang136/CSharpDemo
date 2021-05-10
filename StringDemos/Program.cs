using System;

namespace StringDemos
{
    class Program
    {
        static void Main(string[] args)
        {
            // string EndsWith的方法.
            string strTest = "luaprefab_m20003_uiprefab_whatsnewspanel.unity3d";
            string strFind = "luaprefab_m20003_uiprefab_whatsnewspanel.unity3d";

            bool bFindString = strTest.EndsWith(strFind);

            Console.WriteLine("Check Here");

        }
    }
}
