
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

    public void Add(T item)
    {
        return;
    }

    public void Clear()
    {
        return;
    }

    public bool Contains(T item)
    {
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        return;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return null;
    }

    public int IndexOf(T item)
    {
        return 0;
    }

    public void Insert(int index, T item)
    {
        return;
    }

    public bool Remove(T item)
    {
        return false;
    }

    public void RemoveAt(int index)
    {
        return;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return null;
    }
}