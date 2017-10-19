using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingStringsToData
{
    class Program
    {
        static void Main(string[] args)
        {
            //string s1 = "25.873";
            //string s2 = "36.240";

            //double d1 = double.Parse(s1);
            //double d2 = double.Parse(s2);

            //double total = d1 + d2;
            //Console.WriteLine("Total: {0}", total);

            string parseResultSummary;
            string stringFirst = "28";

            int intFirst;

            bool success = int.TryParse(stringFirst, out intFirst);

            parseResultSummary = success
                                    ? "was successfully parsed"
                                    : "was not successfully parsed";

            Console.WriteLine("String {0} {1}", stringFirst, parseResultSummary);


            string stringSecond = "vt750";
            int intSecond;

            success = int.TryParse(stringSecond, out intSecond);
            parseResultSummary = success
                                    ? "was successfully parsed"
                                    : "was not successfully parsed";

            Console.WriteLine("String {0} {1}", stringSecond, parseResultSummary);
        }
    }
}
