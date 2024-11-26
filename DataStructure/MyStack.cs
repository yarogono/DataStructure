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

            // _myStackArr의 Length가 0이면 DefaultCapacity(4)로 세팅
            // _myStackArr의 Length가 0이 아니면 현재 _myStackArr의 Length에 * 2
            int newcapacity = _myStackArr.Length == 0 ? DefaultCapacity : 2 * _myStackArr.Length;

            // 최대 capacity를 overflow 하지 않도록 검증
            // Array의 MaxLength는 시스템 메모리 구조와 제한에 따라 달라집니다.
            if ((uint)newcapacity > Array.MaxLength) newcapacity = Array.MaxLength;

            if (newcapacity < capacity) newcapacity = capacity;

            // Array.MaxLength를 초과하는 용량은 Array.Resize에 의해 OutOfMemoryException으로 나타납니다.
            Array.Resize(ref _myStackArr, newcapacity);
        }

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

        // 시간 복잡도 : O(n)
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

        public void TrimExcess()
        {

        }

        // 시간 복잡도 : O(1)
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


        // 시간 복잡도 : O(1)
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

        // 시간 복잡도 : O(1)
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


        public int EnsureCapacity(int capacity)
        {
            return 1;
        }


        // 시간 복잡도 : O(n)
        public T[] ToArray()
        {
            T[] newArr = new T[_size];

            Array.Copy(_myStackArr, newArr, _size);

            return newArr;
        }
    }
}
