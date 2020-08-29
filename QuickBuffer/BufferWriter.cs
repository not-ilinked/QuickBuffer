using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuffer
{
    public class BufferWriter
    {
        protected List<byte> Buffer { get; set; }
        public Encoding TextEncoding { get; set; }

        public BufferWriter()
        {
            Buffer = new List<byte>();
            TextEncoding = Encoding.UTF8;
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

        public List<byte> ToList()
        {
            return Buffer;
        }

        public byte[] ToArray()
        {
            return Buffer.ToArray();
        }
    }
}
