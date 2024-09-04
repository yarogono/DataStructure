using System.Collections;
using System.Diagnostics;

public class MyArrayList<T> : List<T>, IList<T>
{
    private T[] arrList;

    private int size;

    private const int DefaultCapacity = 4;

    public MyArrayList()
    {
        arrList = new T[10];
        this.size = 0;
    }

    public T this[int index]
    { 
        get => arrList[index]; 
        set => arrList[index] = value; 
    }

    public int Count()
    {
        return size;
    }

    public bool IsReadOnly => throw new NotImplementedException();


    private void Grow(int capacity)
    {
        Debug.Assert(arrList.Length < capacity);

        // _myStackArr의 Length가 0이면 DefaultCapacity(4)로 세팅
        // _myStackArr의 Length가 0이 아니면 현재 _myStackArr의 Length에 * 2
        int newcapacity = arrList.Length == 0 ? DefaultCapacity : 2 * arrList.Length;

        // 최대 capacity를 overflow 하지 않도록 검증
        // Array의 MaxLength는 시스템 메모리 구조와 제한에 따라 달라집니다.
        if ((uint)newcapacity > Array.MaxLength) newcapacity = Array.MaxLength;

        if (newcapacity < capacity) newcapacity = capacity;

        // Array.MaxLength를 초과하는 용량은 Array.Resize에 의해 OutOfMemoryException으로 나타납니다.
        Array.Resize(ref arrList, newcapacity);
    }

    public void Add(T element)
    {
        if (arrList.Length == 0 || arrList == null)
            return;

        if (arrList.Length <= size)
        {
            Grow(arrList.Length);
        }

        arrList[size] = element;
        size++;
    }

    public void AddRange(List<T> list)
    {
        if (arrList.Length - (arrList.Length + list.Count) <= 0)
        {
            Grow(arrList.Length + list.Count);
        }


        int totalLength = size + list.Count;

        for (int i = size; i < totalLength; i++)
        {
            arrList[i] = list[i - size];
        }

        size = totalLength;
    }

    public void Clear()
    {
        if (arrList == null)
        {
            return;
        }

        if (size <= 0)
        {
            return;
        }

        arrList = new T[10];
        size = 0;
    }

    public bool Contains(T item)
    {
        if (arrList.Length <= 0)
        {
            return false;
        }

        for (int i = 0; i < size; i++)
        {
            if (arrList[i].Equals(item))
            {
                return true;
            }
        }

        return false;
    }

    public IEnumerator GetEnumerator()
    {
        T[] copiedArr = new T[size];
        Array.Copy(arrList, copiedArr, size);

        var enumerator = copiedArr.GetEnumerator();
        enumerator.MoveNext();
        return enumerator;
    }

    public int IndexOf(T item)
    {
        if (arrList.Length <= 0)
        {
            return -1;
        }

        for (int i = 0; i < size; i++)
        {
            if (Compare<T>(arrList[i], item))
            {
                return i;
            }
        }

        return -1;
    }

    public int LastIndexOf(T item)
    {
        if (arrList.Length <= 0)
        {
            return -1;
        }

        for (int i = size; 0 < i; i--)
        {     
            if (Compare<T>(arrList[i], item))
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

    public void Insert(int index, T item)
    {
        // 추가하려는 index의 값이 ArrayList의 범위를 벗어나는지 확인
        if (index < 0 || index > size)
        {
            return;
        }

        if (arrList.Length <= size + 1)
        {
            Grow(arrList.Length);
        }

        for (int i = index; i < size; i++)
        {
            arrList[i + 1] = arrList[i];
        }

        // ArrayList의 index 위치에 element의 값을 할당한다.
        arrList[index] = item;
        size++;
    }

    public bool Remove(T item)
    {
        if (arrList == null || arrList.Length <= 0)
        {
            return false;
        }

        int findInedex = -1;
        for (int i = 0; i < arrList.Length; i++)
        {
            if (findInedex!= -1)
            {
                arrList[i - 1]= arrList[i];
                continue;
            }

            if (Compare<T>(arrList[i], item))
            {
                arrList[i] = default(T);
                findInedex = i;
            }
        }

        if (findInedex == -1)
        {
            return false;
        }

        arrList[size - 1] = default(T);
        size--;

        return true;
    }

    public T RemoveAt(int index)
    {
        if (arrList.Length <= 0 || arrList == null)
            return default(T);

        if (arrList.Length < index)
        {
            throw new ArgumentOutOfRangeException();
        }

        T value = arrList[index];
        bool isRemoved = Remove(arrList[index]);

        if (isRemoved == false)
            return default(T);

        return value;
    }

    public void RemoveAll(List<int?> list)
    {
        if (arrList.Length <= 0)
        {
            return;
        }

        arrList = new T[10];
        size = 0;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        // ToDo
        return null;
    }

    public bool IsEmpty()
    {
        bool isEmpty = false;

        if (size == 0)
        {
            isEmpty = true;
        }

        return isEmpty;
    }

    public T[] ToArray()
    {
        return arrList;
    }

    public MyArrayList<T> SubList(int startIndex, int endIndex)
    {
        if (size == 0)
        {
            return new MyArrayList<T> { };
        }

        if (arrList == null)
        {
            throw new NullReferenceException("MyArrayList is Null");
        }

        if (size <= endIndex)
        {
            throw new ArgumentOutOfRangeException();
        }

        MyArrayList<T> subMyArrayList = new();

        for (int i = startIndex; i <= endIndex; i++)
        {
            subMyArrayList.Add(arrList[i]);
        }

        return subMyArrayList;
    }
}