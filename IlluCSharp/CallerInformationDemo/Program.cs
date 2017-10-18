using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CallerInformationDemo
{
    class Program
    {
        public static void MyTrace(string message,
                                    [CallerFilePath] string fileName = "",
                                    [CallerLineNumber] int lineNumber = 0,
                                    [CallerMemberName] string callingMember = "")
        {
            Console.WriteLine("File:        {0}", fileName);
            Console.WriteLine("Line:        {0}", lineNumber);
            Console.WriteLine("Called From:        {0}", callingMember);
            Console.WriteLine("Message:        {0}", message);
        }

        static void Main(string[] args)
        {
            MyTrace("Simple message");
        }
    }
}
