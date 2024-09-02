using System.Collections;
using System.Diagnostics;

namespace DataStructure
{
    public class MyStack<T> : Stack<T>
    {
        private T[] _myStackArr;
        private int _size;

        private const int DefaultCapacity = 4;

        public MyStack()
        {
            _myStackArr = Array.Empty<T>();
            _size = 0;
        }

        private void Grow(int capacity)
        {
            Debug.Assert(_myStackArr.Length < capacity);

            int newcapacity = _myStackArr.Length == 0 ? DefaultCapacity : 2 * _myStackArr.Length;

            // Allow the list to grow to maximum possible capacity (~2G elements) before encountering overflow.
            // Note that this check works even when _items.Length overflowed thanks to the (uint) cast.
            if ((uint)newcapacity > Array.MaxLength) newcapacity = Array.MaxLength;

            // If computed capacity is still less than specified, set to the original argument.
            // Capacities exceeding Array.MaxLength will be surfaced as OutOfMemoryException by Array.Resize.
            if (newcapacity < capacity) newcapacity = capacity;

            Array.Resize(ref _myStackArr, newcapacity);
        }

        // Create a stack with a specific initial capacity.  The initial capacity
        // must be a non-negative number.
        public MyStack(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException("Capacity Argument less than Zero");
            }

            _myStackArr = new T[capacity];
            _size = 0;
        }

        public int Count
        {
            get { return _size; }
        }

        public void Clear()
        {
            _myStackArr = new T[0];
            _size = 0;
        }

        public bool Contains(T item)
        {
            if (_myStackArr == null || _myStackArr.Length <= 0)
            {
                return false;
            }

            for (int i = 0; i < _size; i++)
            {
                if (_myStackArr[i].Equals(item))
                {
                    return true;
                }
            }
            
            return false;
        }


        public void CopyTo(T[] array, int arrayIndex)
        {
        }


        // Returns an IEnumerator for this Stack.
        //public Enumerator GetEnumerator()
        //{
        //    return new Enumerator(this);
        //}


        public void TrimExcess()
        {

        }

        // Returns the top object on the stack without removing it.  If the stack
        // is empty, Peek throws an InvalidOperationException.
        public T Peek()
        {
            if (_myStackArr == null || _myStackArr.Length <= 0)
            {
                return default(T);
            }

            var peekItem = _myStackArr[_size - 1];

            if (peekItem != null)
            {
                return peekItem;
            }

            return default(T);
        }

        //public bool TryPeek([MaybeNullWhen(false)] out T result)
        //{
        //}

        // Pops an item from the top of the stack.  If the stack is empty, Pop
        // throws an InvalidOperationException.
        public T Pop()
        {
            if (_myStackArr == null)
            {
                throw new NullReferenceException();
            }

            if (_myStackArr.Length <= 0)
            {
                return default(T);
            }

            var popedItem = _myStackArr[_size - 1];
            _size--;

            return popedItem;
        }

        //public bool TryPop([MaybeNullWhen(false)] out T result)
        //{
        //}

        // Pushes an item to the top of the stack.
        public void Push(T item)
        {
            if (_myStackArr == null)
            {
                throw new NullReferenceException();
            }

            if (_myStackArr.Length == _size)
            {
                Grow(_size + 1);
            }

            _myStackArr[_size] = item;
            _size++;
        }


        /// <summary>
        /// Ensures that the capacity of this Stack is at least the specified <paramref name="capacity"/>.
        /// If the current capacity of the Stack is less than specified <paramref name="capacity"/>,
        /// the capacity is increased by continuously twice current capacity until it is at least the specified <paramref name="capacity"/>.
        /// </summary>
        /// <param name="capacity">The minimum capacity to ensure.</param>
        public int EnsureCapacity(int capacity)
        {
            return 1;
        }


        // Copies the Stack to an array, in the same order Pop would return the items.
        public T[] ToArray()
        {
            T[] newArr = new T[_size];
            
            for (int i = 0; i < _size; i++)
            {
                newArr[i] = _myStackArr[i];
            }

            return newArr;
        }
    }
}
