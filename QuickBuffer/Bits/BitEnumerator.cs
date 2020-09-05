using System.Collections;
using System.Collections.Generic;

namespace QuickBuffer
{
    public class BitEnumerator : IEnumerator<bool>
    {
        private int _position = -1;
        private readonly BitArray _arr;

        public bool Current
        {
            get { return _arr[_position]; }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }


        public BitEnumerator(BitArray underlying)
        {
            _arr = underlying;
        }


        public void Dispose() { }

        public bool MoveNext()
        {
            _position++;
            return _position < _arr.Length;
        }

        public void Reset()
        {
            _position = -1;
        }
    }
}
