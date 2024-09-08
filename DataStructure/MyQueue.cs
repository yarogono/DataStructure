using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace DataStructure
{
    [Serializable]
    public class MyQueue<T> : IEnumerable<T>,
        System.Collections.ICollection,
        IReadOnlyCollection<T>
    {
        private object?[] _array;
        private int _head;
        private int _tail;
        private int _size;
        private readonly int _growFactor; // 100 == 1.0, 130 == 1.3, 200 == 2.0. Do not rename (binary serialization)

        public MyQueue()
            : this(32, (float)2.0)
        {

        }

        public MyQueue(int capacity)
            : this(capacity, (float)2.0)
        {

        }

        public MyQueue(int capacity, float growFactor)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException();
            if (!(growFactor >= 1.0 && growFactor <= 10.0))
                throw new ArgumentOutOfRangeException();

            _array = new object[capacity];
            _head = 0;
            _tail = 0;
            _size = 0;
            _growFactor = (int)(growFactor * 100);
        }

        public int Count 
        { 
            get { return _size; } 
        }

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public void Clear()
        {
            _array = new object[32];
            _head = 0;
            _tail = 0;
            _size = 0;
        }

        public bool Contains(T item)
        {
            if (_size == 0)
            {
                return false;
            }

            for (int i = _head; i < _size; i++)
            {
                if (_array[i].Equals(item))
                {
                    return true;
                }
            }

            return true;
        }
 
        public void CopyTo(T[] array, int arrayIndex)
        {

        }

        public T Dequeue()
        {
            if (_array[_head] == null)
            {
                return default(T);
            }

            T result = (T)_array[_head];

            if (result == null)
            {
                return default(T);
            }

            _array[_head] = null;
            _head++;
            _size--;

            return result;
        }

        public void Enqueue(T item)
        {
            if (_array[_head] == null)
            {
                _array[_head] = item;
                _size++;
                return;
            }

            if (_array.Count() <= _tail)
            {
                // ToDo : Grow
            }

            _tail++;
            _array[_tail] = item;
            _size++;
        }
 
        public int EnsureCapacity(int capacity)
        {
            return default(int);
        }

        public Enumerator GetEnumerator()
        {
            return new Enumerator();
        }

        public T Peek()
        {
            if (_array[_head] == null)
            {
                return default(T);
            }

            T result = (T)_array[_head];

            return result;
        }

        public T[] ToArray()
        {
            if (_size == 0)
            {
                return new T[0];
            }

            T[] result = new T[_size];
            for (int i = 0; i < _size; i++)
            {
                result[i] = (T)_array[i];
            }

            return result;
        }

        public void TrimExcess()
        {

        }

        public bool TryDequeue([MaybeNullWhen(false)] out T result)
        {
            if (_size == 0 || _array[_head] == null)
            {
                result = default;
                return false;
            }

            result = (T)_array[_head];
            _array[_head] = default(T);
            _head++;
            _size--;

            return true;
        }

        public bool TryPeek([MaybeNullWhen(false)] out T result)
        {
            if (_size == 0 || _array[_head] == null)
            {
                result = default;
                return false;
            }

            result = (T)_array[_head];
            return true;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
        {

            public T Current { get; }

            object IEnumerator.Current => throw new NotImplementedException();

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                return false;
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
}
