//#define PremiumVersion

//#define DemoVersionWithoutTimeLimit

#define RightHanded
#define LeftHanded

//#if RightHanded && LeftHanded

//#error Can't build for both RightHanded and Lefthanded

//#endif


using System;



using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace defineUnDef
{
    class Program
    {
        static void Main(string[] args)
        {
//            const int intExpireLength = 30;
//            string strVersionDesc = null;
//            int intExpireCount = 0;

//#if DemoVersionWithTimeLimit
//            strVersionDesc = "This version of Supergame Plus will expire in 30 days";
//#else
//            strVersionDesc = "The original Supergame Plus!!";

//#endif
            //            Console.WriteLine(strVersionDesc);

//#pragma warning disable

#if RightHanded && LeftHanded

//#error Can't build for both RightHanded and LeftHanded

#endif

#warning Remember to come back and clean up this code!

        }
    }
}
