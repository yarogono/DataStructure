using System.Collections;
using System.Diagnostics;

public class MyArrayList<T> : List<T>, IList<T>
{
    private T[] _arrList;

    private int _size;

    private const int DefaultCapacity = 4;

    public MyArrayList()
    {
        _arrList = new T[10];
        this._size = 0;
    }

    public T this[int index]
    { 
        get => _arrList[index]; 
        set => _arrList[index] = value; 
    }

    public int Count() => _size;

    public virtual bool IsReadOnly => false;


    private void Grow(int capacity)
    {
        Debug.Assert(_arrList.Length < capacity);

        // _myStackArr의 Length가 0이면 DefaultCapacity(4)로 세팅
        // _myStackArr의 Length가 0이 아니면 현재 _myStackArr의 Length에 * 2
        int newcapacity = _arrList.Length == 0 ? DefaultCapacity : 2 * _arrList.Length;

        // 최대 capacity를 overflow 하지 않도록 검증
        // Array의 MaxLength는 시스템 메모리 구조와 제한에 따라 달라집니다.
        if ((uint)newcapacity > Array.MaxLength) newcapacity = Array.MaxLength;

        if (newcapacity < capacity) newcapacity = capacity;

        // Array.MaxLength를 초과하는 용량은 Array.Resize에 의해 OutOfMemoryException으로 나타납니다.
        Array.Resize(ref _arrList, newcapacity);
    }

    // 시간 복잡도 : O(1)
    public void Add(T element)
    {
        if (_arrList.Length == 0 || _arrList == null)
            return;

        if (_arrList.Length <= _size)
        {
            Grow(_arrList.Length);
        }

        _arrList[_size] = element;
        _size++;
    }

    // 시간 복잡도 : O(n) + O(n) => Grow된 Length 길이 더하기
    public void AddRange(List<T> list)
    {
        if (_arrList.Length - (_arrList.Length + list.Count) <= 0)
        {
            Grow(_arrList.Length + list.Count);
        }


        int totalLength = _size + list.Count;

        for (int i = _size; i < totalLength; i++)
        {
            _arrList[i] = list[i - _size];
        }

        _size = totalLength;
    }

    public void Clear()
    {
        if (_arrList == null)
        {
            return;
        }

        if (_size <= 0)
        {
            return;
        }

        _arrList = new T[10];
        _size = 0;
    }

    // 시간 복잡도 : O(n)
    public bool Contains(T item)
    {
        if (_arrList.Length <= 0)
        {
            return false;
        }

        for (int i = 0; i < _size; i++)
        {
            if (_arrList[i].Equals(item))
            {
                return true;
            }
        }

        return false;
    }

    public IEnumerator GetEnumerator()
    {
        T[] copiedArr = new T[_size];
        Array.Copy(_arrList, copiedArr, _size);

        var enumerator = copiedArr.GetEnumerator();
        enumerator.MoveNext();
        return enumerator;
    }

    //  시간 복잡도 : O(n)
    public int IndexOf(T item)
    {
        if (_arrList.Length <= 0)
        {
            return -1;
        }

        for (int i = 0; i < _size; i++)
        {
            if (Compare<T>(_arrList[i], item))
            {
                return i;
            }
        }

        return -1;
    }

    // 시간 복잡도 : O(n)
    public int LastIndexOf(T item)
    {
        if (_arrList.Length <= 0)
        {
            return -1;
        }

        for (int i = _size; 0 < i; i--)
        {     
            if (Compare<T>(_arrList[i], item))
            {
                return i;
            }
        }

        return -1;
    }


    // https://stackoverflow.com/questions/390900/cant-operator-be-applied-to-generic-types-in-c 스택오버플로우 참고해서 해결
    private bool Compare<T>(T x, T y)
    {
        return EqualityComparer<T>.Default.Equals(x, y);
    }

    // 시간 복잡도 : O(n)
    public void Insert(int index, T item)
    {
        // 추가하려는 index의 값이 ArrayList의 범위를 벗어나는지 확인
        if (index < 0 || index > _size)
        {
            return;
        }

        if (_arrList.Length <= _size + 1)
        {
            Grow(_arrList.Length);
        }

        for (int i = index; i < _size; i++)
        {
            _arrList[i + 1] = _arrList[i];
        }

        // ArrayList의 index 위치에 element의 값을 할당한다.
        _arrList[index] = item;
        _size++;
    }

    // 시간 복잡도 : O(n)
    public bool Remove(T item)
    {
        if (_arrList == null || _arrList.Length <= 0)
        {
            return false;
        }

        int findInedex = -1;
        for (int i = 0; i < _arrList.Length; i++)
        {
            if (findInedex!= -1)
            {
                _arrList[i - 1]= _arrList[i];
                continue;
            }

            if (Compare<T>(_arrList[i], item))
            {
                _arrList[i] = default(T);
                findInedex = i;
            }
        }

        if (findInedex == -1)
        {
            return false;
        }

        _arrList[_size - 1] = default(T);
        _size--;

        return true;
    }

    // 시간 복잡도 : O(n)
    public T RemoveAt(int index)
    {
        if (_arrList.Length <= 0 || _arrList == null)
            return default(T);

        if (_arrList.Length < index)
        {
            throw new ArgumentOutOfRangeException();
        }

        T value = _arrList[index];
        bool isRemoved = Remove(_arrList[index]);

        if (isRemoved == false)
            return default(T);

        return value;
    }

    public void RemoveAll(List<int?> list)
    {
        if (_arrList.Length <= 0)
        {
            return;
        }

        _arrList = new T[10];
        _size = 0;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        // ToDo
        return null;
    }

    public bool IsEmpty()
    {
        bool isEmpty = false;

        if (_size == 0)
        {
            isEmpty = true;
        }

        return isEmpty;
    }

    // 시간 복잡도 : O(n)
    public T[] ToArray()
    {
        T[] newArray = new T[_size];
        Array.Copy(_arrList, newArray, _size);
        return _arrList;
    }

    public MyArrayList<T> SubList(int startIndex, int endIndex)
    {
        if (_size == 0)
        {
            return new MyArrayList<T> { };
        }

        if (_arrList == null)
        {
            throw new NullReferenceException("MyArrayList is Null");
        }

        if (_size <= endIndex)
        {
            throw new ArgumentOutOfRangeException();
        }

        MyArrayList<T> subMyArrayList = new();

        for (int i = startIndex; i <= endIndex; i++)
        {
            subMyArrayList.Add(_arrList[i]);
        }

        return subMyArrayList;
    }
}