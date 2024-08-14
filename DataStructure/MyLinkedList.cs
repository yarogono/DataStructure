using System;
using System.Diagnostics;
using System.Drawing;
using System.Xml.Linq;

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

        public void AddAll(MyLinkedList<T> list)
        {
            if (head == null)
            {
                head = new MyLinkedListNode<T>(list.head.Value);
                head.prev = head;
                head.next = head;
                count++;

                list.head.next.prev = list.head.prev;
                list.head = list.head.next;
            }

            var tempNode = list.head;
            while (tempNode != null)
            {
                head.prev.next = tempNode;
                head.prev = head.prev.next;
                count++;

                tempNode = tempNode.next;
            }
        }

        public void AddAll(LinkedList<T> list)
        {
        }


        public MyLinkedListNode<T>? Last { get { return head == null ? null : head.prev; } }
        
        public MyLinkedListNode<T>? First { get; }
        

        public int Count
        {
            get { return count; }
        }


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

        public MyLinkedListNode<T> AddFirst(T value)
        {

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
            count++;

            return head;
        }

        public MyLinkedListNode<T> AddLast(T value)
        {
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

        public void CopyTo(T[] array, int index)
        {

        }

        public MyLinkedListNode<T>? Find(T value)
        {
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

        public MyLinkedListNode<T>? FindLast(T value)
        {
            return null;
        }

        public Enumerator GetEnumerator()
        {
            return new MyLinkedList<T>.Enumerator();
        }


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
