namespace DataStructure
{
    public class MyLinkedListNode<T>
    {
        internal MyLinkedList<T>? list;
        internal MyLinkedListNode<T>? next;
        internal MyLinkedListNode<T>? prev;
        internal T item;

        public T Value
        {
            get { return item; }
        }

        public MyLinkedListNode()
        {
        }

        public MyLinkedListNode(T value)
        {
            item = value;
        }

        internal MyLinkedListNode(MyLinkedList<T> list, T value)
        {
            this.list = list;
            item = value;
        }

        public MyLinkedListNode<T>? Next
        {
            get { return next == null || next == list!.head ? null : next; }
        }

        public MyLinkedListNode<T>? Previous
        {
            get { return prev == null || this == list!.head ? null : prev; }
        }

        internal void Invalidate()
        {
            list = null;
            next = null;
            prev = null;
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

        // 시간 복잡도 : O(n)
        public void AddAll(MyLinkedList<T> list)
        {
            if (head == null)
            {
                head = new MyLinkedListNode<T>(list.head.Value);
                head.prev = head;
                head.next = head;
                head.list = this;
                count++;

                list.head.next.prev = list.head.prev;
                list.head = list.head.next;
            }

            var tempNode = list.head;
            while (tempNode != null)
            {
                head.prev.next = tempNode;
                head.prev = head.prev.next;
                tempNode.list = this;
                count++;

                tempNode = tempNode.next;
            }
        }


        public MyLinkedListNode<T>? Last { get { return head == null ? null : head.prev; } }
        
        public MyLinkedListNode<T>? First { get { return head; } }
        

        public int Count
        {
            get { return count; }
        }


        public void AddAfter(MyLinkedListNode<T> node, MyLinkedListNode<T> newNode)
        {
            if (head == null)
            {
                return;
            }

            if (Contains(node) == false)
            {
                return;
            }

            AddAfterNode(newNode, node);
        }

        // 시간 복잡도 : O(1)
        public MyLinkedListNode<T> AddAfter(MyLinkedListNode<T> node, T value)
        {
            if (node == null || value == null)
            {
                throw new NullReferenceException();
            }

            if (head == null)
            {
                throw new NullReferenceException();
            }

            if (Contains(node) == false)
            {
                throw null;
            }

            MyLinkedListNode<T> newNode = new(value);
            AddAfterNode(newNode, node);

            return newNode;
        }

        // 시간 복잡도 : O(1)
        private void AddAfterNode(MyLinkedListNode<T> newNode, MyLinkedListNode<T> node)
        {
            newNode.next = node.next;
            newNode.prev = node;
            node.next = newNode;
            newNode.list = this;
            count++;
        }

        // 시간 복잡도 : O(1)
        public void AddBefore(MyLinkedListNode<T> node, MyLinkedListNode<T> newNode)
        {
            if (head == null)
            {
                return;
            }

            if (Contains(node) == false)
            {
                return;
            }

            AddBeforeNode(newNode, node);
        }

        // 시간 복잡도 : O(1)
        public MyLinkedListNode<T> AddBefore(MyLinkedListNode<T> node, T value)
        {
            if (node == null || value == null)
            {
                throw new NullReferenceException();
            }

            if (head == null)
            {
                throw new NullReferenceException();
            }

            if (Contains(node) == false)
            {
                return null;
            }

            var newNode = new MyLinkedListNode<T>(value);
            AddBeforeNode(newNode, node);

            return newNode;
        }

        // 시간 복잡도 : O(1)
        private void AddBeforeNode(MyLinkedListNode<T> newNode, MyLinkedListNode<T> node)
        {
            newNode.prev = node.prev;
            newNode.next = node;
            node.prev.next = newNode;
            node.prev = newNode;
            newNode.list = this;
            count++;
        }

        // 시간 복잡도 : O(1)
        public MyLinkedListNode<T> AddFirst(T value)
        {
            if (value == null)
            {
                throw new NullReferenceException();
            }


            if (head == null)
            {
                MyLinkedListNode<T> node = new(this, value);
                head = node;
                head.prev = head;
                count++;
                return head;
            }

            MyLinkedListNode<T> newNode = new(this, value);
            newNode.next = head;
            newNode.prev = head.prev;
            head.prev!.next = newNode;
            head.prev = newNode;
            head = newNode;
            newNode.list = this;
            count++;

            return head;
        }

        // 시간 복잡도 : O(1)
        public MyLinkedListNode<T> AddLast(T value)
        {
            if (value == null)
            {
                throw new NullReferenceException();
            }

            if (head == null)
            {
                MyLinkedListNode<T> node = new(this, value);
                head = node;
                head.prev = head;
                count++;
                return node;
            }


            MyLinkedListNode<T> newNode = new(this, value);

            if (head.prev != null)
            {
                newNode.prev = head.prev;
                newNode.prev!.next = newNode;
                head.prev = newNode;
            }
         
            else
            {
                head.next = newNode;
                head.prev = newNode;
            }

            count++;

            return newNode;
        }

        public void Clear()
        {
            head = null;
            count = 0;
        }

        // 시간 복잡도 : O(n)
        public bool Contains(T value)
        {
            if (head == null)
            {
                return false;
            }

            if (head.Value.Equals(value))
            {
                return true;
            }

            var tempNode = head.next;

            while (head.next != null)
            {
                if (tempNode.Value.Equals(value))
                {
                    return true;
                }

                tempNode = tempNode.next;
            }

            return true;
        }

        // 시간 복잡도 : O(n)
        public bool Contains(MyLinkedListNode<T> node)
        {
            bool isContains = false;

            if (node == null)
            {
                return isContains = false;
            }

            if (head == null)
            {
                return isContains = false;
            }

            if (head == node)
            {
                return isContains = true;
            }

            var tempNode = head.next;

            while (head.next != null)
            {
                if (tempNode == node)
                {
                    return true;
                }

                tempNode = tempNode.next;
            }

            return true;
        }

        public void CopyTo(T[] array, int index)
        {

        }

        // 시간 복잡도 : O(n)
        public MyLinkedListNode<T>? Find(T value)
        {
            if (value == null)
            {
                throw new NullReferenceException();
            }

            if (head.Value.Equals(value))
            {
                return head;
            }

            MyLinkedListNode<T> tempNode= head.Next;
            while (tempNode != null)
            {
                if (tempNode.Value.Equals(value))
                {
                    break;
                }
                else
                {
                    tempNode = tempNode.Next;
                }
            }
            return tempNode;
        }
        
        // 시간 복잡도 : O(n)
        public MyLinkedListNode<T>? FindLast(T value)
        {
            if (head == null)
            {
                return null;
            }

            var tempNode = head.prev;

            while (tempNode != null)
            {
                if (tempNode == head && tempNode.Value.Equals(value) == false)
                {
                    break;
                }

                if (tempNode.Value.Equals(value))
                {
                    return tempNode;
                }

                tempNode = tempNode.Previous;
            }


            return null;
        }

        public Enumerator GetEnumerator()
        {
            return new MyLinkedList<T>.Enumerator();
        }

        // 시간 복잡도 : O(n)
        public bool Remove(T value)
        {
            if (head == null)
            {
                return false;
            }

            if (head.next == null)
            {
                head.Invalidate();
                head = null;
                return true;
            }

            var tempNode = head;

            while (tempNode != null)
            {
                if (tempNode.Value.Equals(value))
                {
                    tempNode.prev.next = tempNode.next;
                    tempNode.next.prev = tempNode.prev;
                    tempNode.Invalidate();
                    tempNode = null;
                    break;
                }

                if (tempNode.next == null)
                {
                    break;
                }
                tempNode = tempNode.Next;
            }

            count--;

            return true;
        }

        // 시간 복잡도 : O(1)
        public void RemoveFirst()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }

            if(head.next == null)
            {
                head.Invalidate();
                head = null;
                return;
            }

            head.next!.prev = head.prev;
            head.prev!.next = head.next;
            head = head.next;
            head.Invalidate();
            count--;
        }

        // 시간 복잡도 : O(1)
        public void RemoveLast()
        {
            if (head == null)
            {
                return;
            }

            if (head.prev == null)
            {
                head = null;
                return;
            }

            var lastNode = head.prev;
            if (lastNode.next == lastNode)
            {
                head = null;
            }
            else
            {
                lastNode.next!.prev = lastNode.prev;
                lastNode.prev!.next = lastNode.next;
                if (head == lastNode)
                {
                    head = lastNode.next;
                }
            }
            lastNode.Invalidate();

            count--;
        }
    }
}
