﻿using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuffer
{
    public class BufferReader : IDisposable
    {
        protected byte[] Buffer { get; set; }
        private List<int> _steps;
        private int _offset;

        public int Offset
        {
            get { return _offset; }
            protected set
            {
                _steps.Add(value - _offset);
                _offset = value;
            }
        }

        public Encoding TextEncoding { get; set; } = Encoding.UTF8;

        public BufferReader(byte[] buffer)
        {
            Buffer = buffer;
            _steps = new List<int>();
        }

        public void Revert(int steps = 1)
        {
            int count = _steps.Count;

            if (steps > count)
                throw new ArgumentOutOfRangeException("Not enough steps have been made");
            else if (steps < 0)
                throw new ArgumentOutOfRangeException("Cannot revert a negative amount of steps");

            for (int i = count - 1; i >= count - steps; i--)
            {
                _offset -= _steps[i]; // we have to use _offset so it doesn't add another step. yikes!
                _steps.RemoveAt(i);
            }
        }

        public byte ReadByte()
        {
            byte b = Buffer[Offset];
            Offset++;
            return b;
        }

        public byte[] ReadBytes(int count)
        {
            byte[] subBuffer = new byte[count];
            Array.Copy(Buffer, Offset, subBuffer, 0, count);
            Offset += count;
            return subBuffer;
        }

        public string ReadString(int count)
        {
            return TextEncoding.GetString(ReadBytes(count));
        }

        public int ReadInt()
        {
            return BitConverter.ToInt32(ReadBytes(sizeof(int)), 0);
        }

        public short ReadShort()
        {
            return BitConverter.ToInt16(ReadBytes(sizeof(short)), 0);
        }

        public long ReadLong()
        {
            return BitConverter.ToInt64(ReadBytes(sizeof(long)), 0);
        }

        public double ReadDouble()
        {
            return BitConverter.ToDouble(ReadBytes(sizeof(double)), 0);
        }

        public float ReadFloat()
        {
            return BitConverter.ToSingle(ReadBytes(sizeof(float)), 0);
        }

        public bool ReadBool()
        {
            return ReadByte() != 0;
        }


        public void Dispose()
        {
            Buffer = null;
            _steps.Clear();
            TextEncoding = null;
        }
    }
}
