using System;
using System.Collections;
using System.Collections.Generic;

namespace QuickBuffer
{
    public class BitList : List<bool>, IDisposable
    {
        public int ByteCount
        {
            get { return (int)Math.Ceiling((decimal)Count / 8); }
        }

        private static bool[] GetBits(BitBuffer source)
        {
            bool[] bits = new bool[source.BitLength];
            for (int i = 0; i < bits.Length; i++)
                bits[i] = bits[i];

            return bits;
        }

        public BitList(BitBuffer source) : base(GetBits(source))
        { }

        public BitList(byte[] bytes) : this(new BitBuffer(bytes))
        { }

        public BitList(byte b) : this(new byte[] { b })
        { }

        ~BitList() => Dispose();


        public void AddRange(BitBuffer bits)
        {
            base.AddRange(GetBits(bits));
        }

        public void AddRange(byte[] bytes)
        {
            this.AddRange(new BitBuffer(bytes));
        }

        public void AddRange(byte b)
        {
            this.AddRange(new byte[] { b });
        }


        public void InsertRange(int i, BitBuffer arr)
        {
            base.InsertRange(i, GetBits(arr));
        }

        public void InsertRange(int i, byte[] bytes)
        {
            this.InsertRange(i, new BitBuffer(bytes));
        }

        public void InsertRange(int i, byte b)
        {
            this.InsertRange(i, new byte[] { b });
        }


        private void Set(IEnumerable<bool> bits)
        {
            this.Clear();
            this.AddRange(bits);
        }


        public void And(BitArray other)
        {
            BitBuffer buffer = ToBitBuffer();
            buffer.And(other);
            Set(buffer);
        }

        public void And(byte[] other)
        {
            And(new BitArray(other));
        }


        public void Or(BitArray other)
        {
            BitBuffer buffer = ToBitBuffer();
            buffer.Or(other);
            Set(buffer);
        }

        public void Or(byte[] other)
        {
            Or(new BitArray(other));
        }


        public void Xor(BitArray other)
        {
            BitBuffer buffer = ToBitBuffer();
            buffer.Xor(other);
            Set(buffer);
        }

        public void Xor(byte[] other)
        {
            Xor(new BitArray(other));
        }


        public BitBuffer ToBitBuffer()
        {
            return new BitBuffer(this.ToArray());
        }

        public byte[] ToBytes()
        {
            return ToBitBuffer().ToBytes();
        }


        public void Dispose()
        {
            this.Clear();
        }
    }
}
