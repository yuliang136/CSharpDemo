using System;


namespace FlagsAttributeTest
{
    [Flags]
    enum CardDeckSettings : uint
    {
        SingleDeck = 0x01,
        LargePictures = 0x02,
        FancyNumbers = 0x04,
        Animation = 0x08
    }

    class MyClass
    {
        bool UseSingleDeck = false,
            UseBigPics = false,
            UseFancyNumbers = false,
            UseAnimation = false,
            UseAnimationAndFancyNumbers = false;

        public void SetOptions(CardDeckSettings ops)
        {
            UseSingleDeck = ops.HasFlag(CardDeckSettings.SingleDeck);
            UseBigPics = ops.HasFlag(CardDeckSettings.LargePictures);
            UseFancyNumbers = ops.HasFlag(CardDeckSettings.FancyNumbers);
            UseAnimation = ops.HasFlag(CardDeckSettings.Animation);

            CardDeckSettings testFlags = CardDeckSettings.Animation | CardDeckSettings.FancyNumbers;

                UseAnimationAndFancyNumbers = ops.HasFlag(testFlags);
        }

        public void PrintOptions()
        {
            Console.WriteLine( "Option settings:" );
            Console.WriteLine( " Use Single Deck - {0}", UseSingleDeck );
            Console.WriteLine( " Use Large Pictures - {0}", UseBigPics );
            Console.WriteLine( " Use Fancy Numbers - {0}", UseFancyNumbers );
            Console.WriteLine( " Show Animation - {0}", UseAnimation );
            Console.WriteLine( " Show Animation and FancyNumbers - {0}",UseAnimationAndFancyNumbers );
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //CardDeckSettings ops;


            //ops = CardDeckSettings.FancyNumbers;
            //Console.WriteLine(ops.ToString());

            //ops = CardDeckSettings.FancyNumbers | CardDeckSettings.Animation;
            //Console.WriteLine(ops.ToString());

            MyClass mc = new MyClass();
            CardDeckSettings ops = CardDeckSettings.SingleDeck 
                                    | CardDeckSettings.FancyNumbers 
                                    | CardDeckSettings.Animation;

            mc.SetOptions(ops);
            mc.PrintOptions();

        }
    }


}
