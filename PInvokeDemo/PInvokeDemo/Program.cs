using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;

namespace PInvokeDemo
{
    class Program
    {
        [DllImportAttribute("user32.dll", EntryPoint = "SetCursorPos")]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        public static extern bool SetCursorPos(int x, int y);

        static void Main(string[] args)
        {
            Random r = new Random(unchecked((int)DateTime.Now.Ticks));

            int i = 1;

            do
            {
                int x = r.Next(0, 100);
                int y = r.Next(0, 100);

                SetCursorPos(x, y);

                i++;

                Thread.Sleep(300);
            }
            while (i < 10);

            Console.ReadKey();
        }
    }
}
