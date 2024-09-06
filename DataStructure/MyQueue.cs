using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace DataStructure
{
    public class MyQueue<T> : IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>, ICollection
    {
        private int _size;

        public int Count { get { return _size; } }

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public MyQueue()
        {
        }

        public void Clear()
        {

        }

        public bool Contains(T item)
        {
            return true;
        }
 
        public void CopyTo(T[] array, int arrayIndex)
        {

        }

        public T Dequeue()
        {
            return default(T);
        }

        public void Enqueue(T item)
        {

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
            return default(T);
        }

        public T[] ToArray()
        {
            return default (T[]);
        }

        public void TrimExcess()
        {

        }

        public bool TryDequeue([MaybeNullWhen(false)] out T result)
        {
            result = default;
            return true;
        }

        public bool TryPeek([MaybeNullWhen(false)] out T result)
        {
            result = default;
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
