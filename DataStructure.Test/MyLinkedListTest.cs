using System.Collections.Generic;

namespace DataStructure.Test
{
    public class MyLinkedListTest : MyArrayListTest
    {
        LinkedList<int> linkedList;
        MyLinkedList<int> myList;

        [Fact]
        public void testLinkedList()
        {
            linkedList = new LinkedList<int>();
            linkedList.Append(1);
            linkedList.Append(2);
            linkedList.Append(3);

            myList = new MyLinkedList<int>();
            myList.AddAll(linkedList);
        }
    }
}
