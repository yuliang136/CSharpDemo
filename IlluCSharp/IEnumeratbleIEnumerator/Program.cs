using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumeratbleIEnumerator
{
    class ColorEnumerator : IEnumerator
    {
        string[] _colors;
        int _position = -1;

        // 构造函数.
        public ColorEnumerator(string[] theColors)
        {
            _colors = new string[theColors.Length];

            // 这里复制了一份内容
            for (int i = 0; i < theColors.Length; i++)
            {
                _colors[i] = theColors[i];
            }
        }

        public object Current
        {
            get 
            {
                if (-1 == _position)
                {
                    throw new InvalidOperationException();
                }

                if (_position >= _colors.Length)
                {
                    throw new InvalidOperationException();
                }

                return _colors[_position];
            }
        }

        public bool MoveNext()
        {
            if (_position < _colors.Length - 1)
            {
                _position++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            _position = -1;
        }
    }

    // 实现IEnumerable 就是实现GetEnumerator
    class Spectrum : IEnumerable
    {
        string[] Colors = { "violet", "blue", "cyan", "green", "yellow", "orange", "red" };

        //public IEnumerator GetEnumerator()
        //{
        //    // 传入需要迭代显示的内容.
        //    return new ColorEnumerator(Colors);
        //}

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public ColorEnumerator GetEnumerator()
        {
            return new ColorEnumerator(Colors);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Spectrum spectrum = new Spectrum();
            foreach (string color in spectrum)
            {
                Console.WriteLine(color);
            }
        }
    }
}
