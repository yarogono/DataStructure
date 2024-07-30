namespace DataStructure
{
    public class MyLinkedListNode<T>
    {
        internal MyLinkedList<T>? list;
        internal MyLinkedListNode<T>? next;
        internal MyLinkedListNode<T>? prev;
        internal T item;

        public T Value { get; }

        public MyLinkedListNode()
        {
        }

        public MyLinkedListNode(T value)
        {
            Value = value;
        }

        internal MyLinkedListNode(MyLinkedList<T> list, T value)
        {
            this.list = list;
            item = value;
        }

        public MyLinkedList<T>? List
        {
            get { return list; }
        }

        public MyLinkedListNode<T>? Next
        {
            get { return next == null || next == list!.head ? null : next; }
        }

        public MyLinkedListNode<T>? Previous
        {
            get { return prev == null || this == list!.head ? null : prev; }
        }
    }

    public class MyLinkedList<T> : LinkedList<T>
    {
        public MyLinkedListNode<T>? head;
        private int count;

        public MyLinkedList()
        {
        }


        public MyLinkedList(IEnumerable<T> collection)
        {
        }

        public void AddAll(LinkedList<T> list)
        {

        }


        public MyLinkedListNode<T>? Last { get; }


        public MyLinkedListNode<T>? First { get; }
        

        public int Count { get; }


        public void AddAfter(LinkedListNode<T> node, MyLinkedListNode<T> newNode)
        {

        }

        public MyLinkedListNode<T> AddAfter(MyLinkedListNode<T> node, T value)
        {
            return null;
        }

        public void AddBefore(MyLinkedListNode<T> node, MyLinkedListNode<T> newNode)
        {

        }

        public MyLinkedListNode<T> AddBefore(MyLinkedListNode<T> node, T value)
        {
            return null;
        }

        public void AddFirst(MyLinkedListNode<T> node)
        {

        }

        public MyLinkedListNode<T> AddFirst(T value)
        {
            return null;
        }

        public void AddLast(MyLinkedListNode<T> node)
        {

        }

        public MyLinkedListNode<T> AddLast(T value)
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

        public MyLinkedListNode<T>? Find(T value)
        {
            return null;
        }

        public MyLinkedListNode<T>? FindLast(T value)
        {
            return null;
        }

        public Enumerator GetEnumerator()
        {
            return new MyLinkedList<T>.Enumerator();
        }

        public virtual void OnDeserialization(object? sender)
        {

        }

        public void Remove(MyLinkedListNode<T> node)
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
