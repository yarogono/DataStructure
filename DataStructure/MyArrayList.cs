
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
        get => throw new NotImplementedException(); 
        set => throw new NotImplementedException(); 
    }

    public int Count => size;

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
        return;
    }

    public void Add(int index, T element)
    {
        // ToDo
    }

    public void AddRange()
    {
        // ToDo
    }

    public void Clear()
    {
        // ToDo
        return;
    }

    public bool Contains(T item)
    {
        // ToDo
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        // ToDo
        return;
    }

    public IEnumerator<T> GetEnumerator()
    {
        // ToDo
        return null;
    }

    public int IndexOf(T item)
    {
        // ToDo
        return 0;
    }

    public void Insert(int index, T item)
    {
        // ToDo
        return;
    }

    public bool Remove(T item)
    {
        // ToDo
        return false;
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