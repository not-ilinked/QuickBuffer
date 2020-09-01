using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuffer
{
    public class BufferWriter : IDisposable
    {
        protected List<byte> Buffer { get; set; }
        public Encoding TextEncoding { get; set; } = Encoding.UTF8;

        public BufferWriter()
        {
            Buffer = new List<byte>();
        }

        public void WriteByte(byte b)
        {
            Buffer.Add(b);
        }

        public void WriteBytes(IEnumerable<byte> bytes)
        {
            Buffer.AddRange(bytes);
        }

        public void WriteString(string str)
        {
            WriteBytes(TextEncoding.GetBytes(str));
        }

        public void WriteInt(int i)
        {
            WriteBytes(BitConverter.GetBytes(i));
        }

        public void WriteShort(short s)
        {
            WriteBytes(BitConverter.GetBytes(s));
        }

        public void WriteLong(long l)
        {
            WriteBytes(BitConverter.GetBytes(l));
        }

        public void WriteDouble(double d)
        {
            WriteBytes(BitConverter.GetBytes(d));
        }

        public void WriteFloat(float f)
        {
            WriteBytes(BitConverter.GetBytes(f));
        }

        public void WriteBool(bool b)
        {
            WriteByte((byte)(b ? 1 : 0));
        }

        public List<byte> ToList()
        {
            return Buffer;
        }

        public byte[] ToArray()
        {
            return Buffer.ToArray();
        }

        public void Dispose()
        {
            Buffer.Clear();
            Buffer = null;
            TextEncoding = null;
        }
    }
}
