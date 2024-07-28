namespace DataStructure
{
    public class MyLinkedList<T> : LinkedList<T>
    {


        public MyLinkedList()
        {
        }

        // 요약:
        //     Initializes a new instance of the System.Collections.Generic.LinkedList`1 class
        //     that contains elements copied from the specified System.Collections.IEnumerable
        //     and has sufficient capacity to accommodate the number of elements copied.
        //
        // 매개 변수:
        //   collection:
        //     The System.Collections.IEnumerable whose elements are copied to the new System.Collections.Generic.LinkedList`1.
        //
        //
        // 예외:
        //   T:System.ArgumentNullException:
        //     collection is null.
        public MyLinkedList(IEnumerable<T> collection)
        {
        }

        public void AddAll(LinkedList<T> list)
        {

        }

        //
        // 요약:
        //     Gets the last node of the System.Collections.Generic.LinkedList`1.
        //
        // 반환 값:
        //     The last System.Collections.Generic.LinkedListNode`1 of the System.Collections.Generic.LinkedList`1.
        public LinkedListNode<T>? Last { get; }
        //
        // 요약:
        //     Gets the first node of the System.Collections.Generic.LinkedList`1.
        //
        // 반환 값:
        //     The first System.Collections.Generic.LinkedListNode`1 of the System.Collections.Generic.LinkedList`1.
        public LinkedListNode<T>? First { get; }
        

        // 요약:
        //     Gets the number of nodes actually contained in the System.Collections.Generic.LinkedList`1.
        //
        //
        // 반환 값:
        //     The number of nodes actually contained in the System.Collections.Generic.LinkedList`1.
        public int Count { get; }

        //
        // 요약:
        //     Adds the specified new node after the specified existing node in the System.Collections.Generic.LinkedList`1.
        //
        //
        // 매개 변수:
        //   node:
        //     The System.Collections.Generic.LinkedListNode`1 after which to insert newNode.
        //
        //
        //   newNode:
        //     The new System.Collections.Generic.LinkedListNode`1 to add to the System.Collections.Generic.LinkedList`1.
        //
        //
        // 예외:
        //   T:System.ArgumentNullException:
        //     node is null. -or- newNode is null.
        //
        //   T:System.InvalidOperationException:
        //     node is not in the current System.Collections.Generic.LinkedList`1. -or- newNode
        //     belongs to another System.Collections.Generic.LinkedList`1.
        public void AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {

        }

        // 요약:
        //     Adds a new node containing the specified value after the specified existing node
        //     in the System.Collections.Generic.LinkedList`1.
        //
        // 매개 변수:
        //   node:
        //     The System.Collections.Generic.LinkedListNode`1 after which to insert a new System.Collections.Generic.LinkedListNode`1
        //     containing value.
        //
        //   value:
        //     The value to add to the System.Collections.Generic.LinkedList`1.
        //
        // 반환 값:
        //     The new System.Collections.Generic.LinkedListNode`1 containing value.
        //
        // 예외:
        //   T:System.ArgumentNullException:
        //     node is null.
        //
        //   T:System.InvalidOperationException:
        //     node is not in the current System.Collections.Generic.LinkedList`1.
        public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value)
        {
            return null;
        }

        // 요약:
        //     Adds the specified new node before the specified existing node in the System.Collections.Generic.LinkedList`1.
        //
        //
        // 매개 변수:
        //   node:
        //     The System.Collections.Generic.LinkedListNode`1 before which to insert newNode.
        //
        //
        //   newNode:
        //     The new System.Collections.Generic.LinkedListNode`1 to add to the System.Collections.Generic.LinkedList`1.
        //
        //
        // 예외:
        //   T:System.ArgumentNullException:
        //     node is null. -or- newNode is null.
        //
        //   T:System.InvalidOperationException:
        //     node is not in the current System.Collections.Generic.LinkedList`1. -or- newNode
        //     belongs to another System.Collections.Generic.LinkedList`1.
        public void AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {

        }

        // 요약:
        //     Adds a new node containing the specified value before the specified existing
        //     node in the System.Collections.Generic.LinkedList`1.
        //
        // 매개 변수:
        //   node:
        //     The System.Collections.Generic.LinkedListNode`1 before which to insert a new
        //     System.Collections.Generic.LinkedListNode`1 containing value.
        //
        //   value:
        //     The value to add to the System.Collections.Generic.LinkedList`1.
        //
        // 반환 값:
        //     The new System.Collections.Generic.LinkedListNode`1 containing value.
        //
        // 예외:
        //   T:System.ArgumentNullException:
        //     node is null.
        //
        //   T:System.InvalidOperationException:
        //     node is not in the current System.Collections.Generic.LinkedList`1.
        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
        {
            return null;
        }

        // 요약:
        //     Adds the specified new node at the start of the System.Collections.Generic.LinkedList`1.
        //
        //
        // 매개 변수:
        //   node:
        //     The new System.Collections.Generic.LinkedListNode`1 to add at the start of the
        //     System.Collections.Generic.LinkedList`1.
        //
        // 예외:
        //   T:System.ArgumentNullException:
        //     node is null.
        //
        //   T:System.InvalidOperationException:
        //     node belongs to another System.Collections.Generic.LinkedList`1.
        public void AddFirst(LinkedListNode<T> node)
        {

        }

        // 요약:
        //     Adds a new node containing the specified value at the start of the System.Collections.Generic.LinkedList`1.
        //
        //
        // 매개 변수:
        //   value:
        //     The value to add at the start of the System.Collections.Generic.LinkedList`1.
        //
        //
        // 반환 값:
        //     The new System.Collections.Generic.LinkedListNode`1 containing value.
        public LinkedListNode<T> AddFirst(T value)
        {
            return null;
        }

        // 요약:
        //     Adds the specified new node at the end of the System.Collections.Generic.LinkedList`1.
        //
        //
        // 매개 변수:
        //   node:
        //     The new System.Collections.Generic.LinkedListNode`1 to add at the end of the
        //     System.Collections.Generic.LinkedList`1.
        //
        // 예외:
        //   T:System.ArgumentNullException:
        //     node is null.
        //
        //   T:System.InvalidOperationException:
        //     node belongs to another System.Collections.Generic.LinkedList`1.
        public void AddLast(LinkedListNode<T> node)
        {

        }

        // 요약:
        //     Adds a new node containing the specified value at the end of the System.Collections.Generic.LinkedList`1.
        //
        //
        // 매개 변수:
        //   value:
        //     The value to add at the end of the System.Collections.Generic.LinkedList`1.
        //
        // 반환 값:
        //     The new System.Collections.Generic.LinkedListNode`1 containing value.
        public LinkedListNode<T> AddLast(T value)
        {
            return null;
        }

        // 요약:
        //     Removes all nodes from the System.Collections.Generic.LinkedList`1.
        public void Clear()
        {

        }

        // 요약:
        //     Determines whether a value is in the System.Collections.Generic.LinkedList`1.
        //
        //
        // 매개 변수:
        //   value:
        //     The value to locate in the System.Collections.Generic.LinkedList`1. The value
        //     can be null for reference types.
        //
        // 반환 값:
        //     true if value is found in the System.Collections.Generic.LinkedList`1; otherwise,
        //     false.
        public bool Contains(T value)
        {
            return true;
        }


        // 요약:
        //     Copies the entire System.Collections.Generic.LinkedList`1 to a compatible one-dimensional
        //     System.Array, starting at the specified index of the target array.
        //
        // 매개 변수:
        //   array:
        //     The one-dimensional System.Array that is the destination of the elements copied
        //     from System.Collections.Generic.LinkedList`1. The System.Array must have zero-based
        //     indexing.
        //
        //   index:
        //     The zero-based index in array at which copying begins.
        //
        // 예외:
        //   T:System.ArgumentNullException:
        //     array is null.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     index is less than zero.
        //
        //   T:System.ArgumentException:
        //     The number of elements in the source System.Collections.Generic.LinkedList`1
        //     is greater than the available space from index to the end of the destination
        //     array.
        public void CopyTo(T[] array, int index)
        {

        }


        // 요약:
        //     Finds the first node that contains the specified value.
        //
        // 매개 변수:
        //   value:
        //     The value to locate in the System.Collections.Generic.LinkedList`1.
        //
        // 반환 값:
        //     The first System.Collections.Generic.LinkedListNode`1 that contains the specified
        //     value, if found; otherwise, null.
        public LinkedListNode<T>? Find(T value)
        {
            return null;
        }


        // 요약:
        //     Finds the last node that contains the specified value.
        //
        // 매개 변수:
        //   value:
        //     The value to locate in the System.Collections.Generic.LinkedList`1.
        //
        // 반환 값:
        //     The last System.Collections.Generic.LinkedListNode`1 that contains the specified
        //     value, if found; otherwise, null.
        public LinkedListNode<T>? FindLast(T value)
        {
            return null;
        }

        // 요약:
        //     Returns an enumerator that iterates through the System.Collections.Generic.LinkedList`1.
        //
        //
        // 반환 값:
        //     An System.Collections.Generic.LinkedList`1.Enumerator for the System.Collections.Generic.LinkedList`1.
        public Enumerator GetEnumerator()
        {
            return new LinkedList<T>.Enumerator();
        }


        // 요약:
        //     Implements the System.Runtime.Serialization.ISerializable interface and raises
        //     the deserialization event when the deserialization is complete.
        //
        // 매개 변수:
        //   sender:
        //     The source of the deserialization event.
        //
        // 예외:
        //   T:System.Runtime.Serialization.SerializationException:
        //     The System.Runtime.Serialization.SerializationInfo object associated with the
        //     current System.Collections.Generic.LinkedList`1 instance is invalid.
        public virtual void OnDeserialization(object? sender)
        {

        }

        // 요약:
        //     Removes the specified node from the System.Collections.Generic.LinkedList`1.
        //
        //
        // 매개 변수:
        //   node:
        //     The System.Collections.Generic.LinkedListNode`1 to remove from the System.Collections.Generic.LinkedList`1.
        //
        //
        // 예외:
        //   T:System.ArgumentNullException:
        //     node is null.
        //
        //   T:System.InvalidOperationException:
        //     node is not in the current System.Collections.Generic.LinkedList`1.
        public void Remove(LinkedListNode<T> node)
        {

        }


        // 요약:
        //     Removes the first occurrence of the specified value from the System.Collections.Generic.LinkedList`1.
        //
        //
        // 매개 변수:
        //   value:
        //     The value to remove from the System.Collections.Generic.LinkedList`1.
        //
        // 반환 값:
        //     true if the element containing value is successfully removed; otherwise, false.
        //     This method also returns false if value was not found in the original System.Collections.Generic.LinkedList`1.
        public bool Remove(T value)
        {
            return true;
        }

        // 요약:
        //     Removes the node at the start of the System.Collections.Generic.LinkedList`1.
        //
        //
        // 예외:
        //   T:System.InvalidOperationException:
        //     The System.Collections.Generic.LinkedList`1 is empty.
        public void RemoveFirst()
        {

        }


        // 요약:
        //     Removes the node at the end of the System.Collections.Generic.LinkedList`1.
        //
        // 예외:
        //   T:System.InvalidOperationException:
        //     The System.Collections.Generic.LinkedList`1 is empty.
        public void RemoveLast()
        {

        }
    }
}
