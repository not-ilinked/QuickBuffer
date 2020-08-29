using System;
using System.Collections;

namespace QuickBuffer
{
    public static class BitArrayUtils
    {
        public static BitArray CopyBits(this BitArray source, int offset, int count)
        {
            BitArray copied = new BitArray(count);

            for (int i = 0; i < count; i++)
                copied[i] = source[offset + i];

            return copied;
        }

        public static byte[] ToArray(this BitArray source)
        {
            byte[] buffer = new byte[(int)Math.Ceiling((decimal)source.Count / 8)];
            source.CopyTo(buffer, 0);
            return buffer;
        }

        public static void Reverse(this BitArray source)
        {
            int length = source.Length;
            int mid = length / 2;

            for (int i = 0; i < mid; i++)
            {
                bool bit = source[i];
                source[i] = source[length - i - 1];
                source[length - i - 1] = bit;
            }
        }
    }
}
