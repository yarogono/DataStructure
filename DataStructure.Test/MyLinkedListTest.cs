using System.Collections.Generic;
using System.Linq;

namespace DataStructure.Test
{
    public class MyLinkedListTest
    {
        LinkedList<int> linkedList;
        MyLinkedList<int> myList;

        [Fact]
        public void linkedList_생성()
        {
            linkedList = new LinkedList<int>();
            linkedList.Append(1);
            linkedList.Append(2);
            linkedList.Append(3);

            myList = new MyLinkedList<int>();
            myList.AddAll(linkedList);
        }

        [Fact]
        public void lonkedList_Length()
        {
            Assert.Equal(myList.Count(), 3);
        }

        [Fact]
        public void linkedList_맨앞에삽입()
        {
            ////given 빈 연결리스트 생성 후 김수현 add
            //ll = new LinkedList<String>();
            //ll.add("김수현");

            ////when 연결리스트 가장 처음에 전지현 add
            //ll.addFirst("전지현");

            ////then 연결리스트에 전지현, 김수현 순서로 들어간다.
            //assertEquals("전지현", ll.get(0));
            //assertEquals("김수현", ll.get(1));

            //System.out.println("linkedList_맨앞에삽입 : " + ll.toString());
        }

        [Fact]
        public void linkedList_맨끝에삽입()
        {
            ////given 빈 연결리스트 생성 후 김수현 add
            //ll = new LinkedList<String>();
            //ll.add("김수현");

            ////when 연결리스트 가장 끝에 전지현 add
            //ll.addLast("전지현");

            ////then 연결리스트에 김수현, 전지현 순서로 들어간다.
            //assertEquals("김수현", ll.get(0));
            //assertEquals("전지현", ll.get(1));

            //System.out.println("linkedList_맨끝에삽입 : " + ll.toString());
        }


        [Fact]
        public void linkedList_중간에삽입()
        {
            ////given 빈 연결리스트 생성 후 김수현, 박해진 add
            //ll = new LinkedList<String>();
            //ll.add("김수현");
            //ll.add("박해진");

            ////when 1번 index에 전지현 add
            //ll.add(1, "전지현");

            ////then 연결리스트에 김수현, 전지현 순서로 들어간다.
            //assertEquals("김수현", ll.get(0));
            //assertEquals("전지현", ll.get(1));
            //assertEquals("박해진", ll.get(2));

            //System.out.println("linkedList_중간에삽입 : " + ll.toString());
        }

        [Fact]
        public void linkedList_빈노드삭제()
        {
            ////given 빈 연결리스트 생성
            //ll = new LinkedList<String>();

            ////when 첫번째 노드 삭제
            //ll.removeFirst();

            ////then 삭제되지 않는다. (에러뜸)
            //System.out.println("linkedList_빈노드삭제 : " + ll.toString());
        }

        [Fact]
        public void linkedList_첫노드삭제()
        {
            ////given 빈 연결리스트 생성 후 김수현, 전지현 add
            //ll = new LinkedList<String>();
            //ll.add("김수현");
            //ll.add("전지현");

            ////when 첫번째 노드 삭제
            //ll.removeFirst();

            ////then 연결리스트에 전지현만 남는다.
            //assertEquals("전지현", ll.get(0));

            //System.out.println("linkedList_첫노드삭제 : " + ll.toString());
        }

        [Fact]
        public void linkedList_마지막노드삭제()
        {
            ////given 빈 연결리스트 생성 후 김수현, 전지현 add
            //ll = new LinkedList<String>();
            //ll.add("김수현");
            //ll.add("전지현");

            ////when 마지막 노드 삭제
            //ll.removeLast();

            ////then 연결리스트에 김수현만 남는다.
            //assertEquals("김수현", ll.get(0));

            //System.out.println("linkedList_마지막노드삭제 : " + ll.toString());
        }

        [Fact]
        public void linkedList_중간노드삭제()
        {
            ////given 빈 연결리스트 생성 후 김수현, 전지현, 박해진 add
            //ll = new LinkedList<String>();
            //ll.add("김수현");
            //ll.add("전지현");
            //ll.add("박해진");

            ////when 전지현 삭제
            //ll.remove("전지현");

            ////then 연결리스트에 김수현, 박해진 순서로 남는다.
            //assertEquals("김수현", ll.get(0));
            //assertEquals("박해진", ll.get(1));

            //System.out.println("linkedList_중간노드삭제 : " + ll.toString());
        }
    }
}
