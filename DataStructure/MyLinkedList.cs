namespace DataStructure
{
    public class MyLinkedList<T> : LinkedList<T>
    {


        public MyLinkedList()
        {
        }


        public MyLinkedList(IEnumerable<T> collection)
        {
        }

        public void AddAll(LinkedList<T> list)
        {

        }


        public LinkedListNode<T>? Last { get; }


        public LinkedListNode<T>? First { get; }
        

        public int Count { get; }


        public void AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {

        }

        public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value)
        {
            return null;
        }

        public void AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {

        }

        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
        {
            return null;
        }

        public void AddFirst(LinkedListNode<T> node)
        {

        }

        public LinkedListNode<T> AddFirst(T value)
        {
            return null;
        }

        public void AddLast(LinkedListNode<T> node)
        {

        }

        public LinkedListNode<T> AddLast(T value)
        {
            return null;
        }

        public void Clear()
        {

        }

        public bool Contains(T value)
        {
            return true;
        }

        public void CopyTo(T[] array, int index)
        {

        }

        public LinkedListNode<T>? Find(T value)
        {
            return null;
        }

        public LinkedListNode<T>? FindLast(T value)
        {
            return null;
        }

        public Enumerator GetEnumerator()
        {
            return new LinkedList<T>.Enumerator();
        }

        public virtual void OnDeserialization(object? sender)
        {

        }

        public void Remove(LinkedListNode<T> node)
        {

        }

        public bool Remove(T value)
        {
            return true;
        }

        public void RemoveFirst()
        {

        }

        public void RemoveLast()
        {

        }
    }
}
