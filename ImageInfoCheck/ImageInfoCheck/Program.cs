using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageInfoCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Check");

            string strText1 = @"AllIconsAtlas.png";
            string strText2 = @"loading00.png";

            using (FileStream fs = new FileStream(strText2, FileMode.Open, FileAccess.Read))
            {
                Image image = Image.FromStream(fs);

                PixelFormat check = image.PixelFormat;

                Console.WriteLine(check.ToString());
            }
        }
    }
}
