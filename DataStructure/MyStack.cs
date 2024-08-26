using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class MyStack<T> : Stack<T>
    {

        public MyStack()
        {
            //_array = Array.Empty<T>();
        }

        // Create a stack with a specific initial capacity.  The initial capacity
        // must be a non-negative number.
        public MyStack(int capacity)
        {
        }

        public int Count
        {
            get { return 0; }
        }

        public void Clear()
        {
        }

        public bool Contains(T item)
        {
            return false;
        }


        public void CopyTo(T[] array, int arrayIndex)
        {
        }


        // Returns an IEnumerator for this Stack.
        //public Enumerator GetEnumerator()
        //{
        //    return new Enumerator(this);
        //}


        public void TrimExcess()
        {

        }

        // Returns the top object on the stack without removing it.  If the stack
        // is empty, Peek throws an InvalidOperationException.
        public T Peek()
        {
            return default(T);
        }

        //public bool TryPeek([MaybeNullWhen(false)] out T result)
        //{
        //}

        // Pops an item from the top of the stack.  If the stack is empty, Pop
        // throws an InvalidOperationException.
        public T Pop()
        {
            return default (T);
        }

        //public bool TryPop([MaybeNullWhen(false)] out T result)
        //{
        //}

        // Pushes an item to the top of the stack.
        public void Push(T item)
        {
        }


        /// <summary>
        /// Ensures that the capacity of this Stack is at least the specified <paramref name="capacity"/>.
        /// If the current capacity of the Stack is less than specified <paramref name="capacity"/>,
        /// the capacity is increased by continuously twice current capacity until it is at least the specified <paramref name="capacity"/>.
        /// </summary>
        /// <param name="capacity">The minimum capacity to ensure.</param>
        public int EnsureCapacity(int capacity)
        {
            return 1;
        }

        private void Grow(int capacity)
        {
        }

        // Copies the Stack to an array, in the same order Pop would return the items.
        public T[] ToArray()
        {

            T[] objArray = new T[1];
            return objArray;
        }

        private void ThrowForEmptyStack()
        {
            Debug.Assert(1 == 0);
            throw new InvalidOperationException("SR.InvalidOperation_EmptyStack");
        }

        //public struct Enumerator : IEnumerator<T>, System.Collections.IEnumerator
        //{
        //}
    }
}
