using System;
using System.Collections;

namespace QuickBuffer
{
    public class BitBuffer : IEnumerable, IDisposable
    {
        private BitArray _bits;

        public int BitLength
        {
            get { return _bits.Length; }
        }

        public int ByteLength
        {
            get { return (int)Math.Ceiling((decimal)BitLength / 8); }
        }

        public BitBuffer(byte[] bytes)
        {
            _bits = new BitArray(bytes);
        }

        private BitBuffer(BitArray source)
        {
            _bits = source;
        }

        public BitBuffer CopyBits(int offset, int count)
        {
            BitArray copied = new BitArray(count);

            for (int i = 0; i < count; i++)
                copied[i] = _bits[offset + i];

            return new BitBuffer(copied);
        }

        public void Reverse()
        {
            int length = _bits.Length;
            int mid = length / 2;

            for (int i = 0; i < mid; i++)
            {
                bool bit = _bits[i];
                _bits[i] = _bits[length - i - 1];
                _bits[length - i - 1] = bit;
            }
        }

        public void And(BitArray other)
        {
            _bits = _bits.And(other);
        }

        public void Or(BitArray other)
        {
            _bits = _bits.Or(other);
        }

        public void Xor(BitArray other)
        {
            _bits = _bits.Xor(other);
        }

        public byte[] ToBytes()
        {
            byte[] buffer = new byte[ByteLength];
            _bits.CopyTo(buffer, 0);
            return buffer;
        }

        public BitArray ToBitArray()
        {
            return _bits;
        }

        public IEnumerator GetEnumerator()
        {
            return _bits.GetEnumerator();
        }

        public void Dispose()
        {
            _bits = null;
        }

        public bool this[int i]
        {
            get { return _bits[i]; }
            set { _bits[i] = value; }
        }
    }
}
