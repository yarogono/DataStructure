using System.Collections;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace DataStructure
{
    [Serializable]
    public class MyQueue<T> : IEnumerable<T>,
        System.Collections.ICollection,
        IReadOnlyCollection<T>
    {
        private T?[] _array;
        private int _head;
        private int _tail;
        private int _size;
        private readonly int _growFactor; // 100 == 1.0, 130 == 1.3, 200 == 2.0. Do not rename (binary serialization)

        private const int MinimumGrow = 4;

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

            _array = new T[capacity];
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
            if (_size != 0)
            {
                if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
                {
                    if (_head < _tail)
                    {
                        Array.Clear(_array, _head, _size);
                    }
                    else
                    {
                        Array.Clear(_array, _head, _array.Length - _head);
                        Array.Clear(_array, 0, _tail);
                    }
                }

                _size = 0;
            }

            _head = 0;
            _tail = 0;
        }

        public bool Contains(T item)
        {
            if (_size == 0)
            {
                return false;
            }

            if (_head < _tail)
            {
                return Array.IndexOf(_array, item, _head, _size) >= 0;
            }

            return 
                Array.IndexOf(_array, item, _head, _array.Length - _head) >= 0 ||
                Array.IndexOf(_array, item, 0, _tail) >= 0;
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

            _array[_head] = default(T);
            _head++;
            _size--;

            return result;
        }

        public void Enqueue(T item)
        {

            if (_size == _array.Length)
            {
                Grow(_size + 1);
            }

            _array[_tail] = item;
            MoveNext(ref _tail);
            _size++;
        }

        private void Grow(int capacity)
        {
            Debug.Assert(_array.Length < capacity);

            const int GrowFactor = 2;

            int newcapacity = GrowFactor * _array.Length;

            if ((uint)newcapacity > Array.MaxLength) newcapacity = Array.MaxLength;

            newcapacity = Math.Max(newcapacity, _array.Length + MinimumGrow);

            if (newcapacity < capacity) newcapacity = capacity;

            SetCapacity(newcapacity);
        }

        // ArrayList는 Resize를 사용하지만 Queue의 _head 값은 인덱스가 가변적이기 때문에 Array.Copy를 사용
        private void SetCapacity(int capacity)
        {
            T[] newarray = new T[capacity];
            if (_size > 0)
            {
                if (_head < _tail)
                {
                    Array.Copy(_array, _head, newarray, 0, _size);
                }
                else
                {
                    Array.Copy(_array, _head, newarray, 0, _array.Length - _head);
                    Array.Copy(_array, 0, newarray, _array.Length - _head, _tail);
                }
            }

            _array = newarray;
            _head = 0;
            _tail = (_size == capacity) ? 0 : _size;
        }

        private void MoveNext(ref int index)
        {
            int tmp = index + 1;
            if (tmp == _array.Length)
            {
                tmp = 0;
            }
            index = tmp;
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
            Array.Copy(_array, _size, result, _head, _size);

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
