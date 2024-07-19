
using System.Collections;

public class MyArrayList<T> : List<T>, IList<T>
{
    private T[] arrList;

    private int size;

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

    public void Add(T element)
    {
        if (arrList.Length == arrList.Length - 1)
        {
            T[] newArr = new T[arrList.Length];
            Array.Copy(arrList, newArr, arrList.Length);
            arrList = new T[arrList.Length + arrList.Length];

            Array.Copy(newArr, arrList, newArr.Length);
        }

        arrList[size] = element;
        size++;
    }

    public void Add(int index, T element)
    {
        // 추가하려는 index의 값이 ArrayList의 범위를 벗어나는지 확인
        if (index < 0 || index > size)
        {
            throw new ArgumentOutOfRangeException();
        }

        // ArrayList의 index 위치에 값을 추가하기 위해 공간을 만든다.
        // ArrayList index 위치 뒤에 있는 모든 값의 위치를 변경한다.
        for (int i = size - 1; i > index; i--)
        {
            arrList[i] = arrList[i - 1];
        }

        // ArrayList의 index 위치에 element의 값을 할당한다.
        arrList[index] = element;
    }

    public void AddRange(List<T> list)
    {
        arrList = new T[list.Count];

        for (int i = 0; i < list.Count; i++)
        {
            arrList[i] = list[i];
        }

        size = arrList.Length;
    }

    public void Clear()
    {
        if (arrList == null)
        {
            throw new NullReferenceException();
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
        for (int i = 0; i < arrList.Length;i++)
        {
            if (arrList[i].Equals(item))
            {
                return true;
            }
        }

        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        // ToDo
    }

    public IEnumerator<T> GetEnumerator()
    {
        // ToDo
        return null;
    }

    public int IndexOf(T item)
    {
        if (arrList.Length <= 0)
        {
            return -1;
        }

        for (int i = 0; i < arrList.Length; i++)
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
        // ToDo
        return;
    }

    public bool Remove(T item)
    {
        if (arrList == null || arrList.Length == 0)
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
                size--;
            }
        }

        if (findInedex == -1)
        {
            return false;
        }

        return true;
    }

    public void RemoveAt(int index)
    {
        // ToDo
        return;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        // ToDo
        return null;
    }
}