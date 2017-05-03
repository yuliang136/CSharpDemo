using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptNeiCun
{
    class Program
    {
        static void Main(string[] args)
        {
            int nKey = 123456777;

            int ValueA = 999888;

            int nAfterEncrypted = ValueA ^ nKey;

            Console.WriteLine(nAfterEncrypted);

            int nDeEncrypted = nAfterEncrypted ^ nKey;

            Console.WriteLine(nDeEncrypted);
        }
    }
}
