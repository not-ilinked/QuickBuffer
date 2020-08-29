using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickBuffer;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] meme = new byte[] { 1 };

            BitArray arr = new BitArray(meme);
            arr.Reverse();
        }
    }
}
