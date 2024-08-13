using System.Collections.Generic;
using System.Linq;

namespace DataStructure.Test
{
    public class MyLinkedListTest
    {
        LinkedList<string> linkedList;
        MyLinkedList<string> myList;

        public MyLinkedListTest()
        {
            linkedList = new LinkedList<string>();
            linkedList.Append("테스트1");
            linkedList.Append("테스트2");
            linkedList.Append("테스트3");

            myList = new MyLinkedList<string>();
            myList.AddAll(linkedList);
        }

        [Fact]
        public void linkedList_AddMyLinkedList()
        {
            var myLinkedList = new MyLinkedList<string>();
            myLinkedList.AddLast("테스트1");
            myLinkedList.AddLast("테스트2");
            myLinkedList.AddLast("테스트3");

            myList = new MyLinkedList<string>();
            myList.AddAll(myLinkedList);

            Assert.Equal(myList.Count, myLinkedList.Count);
        }

        [Fact]
        public void linkedList_Length()
        {
            myList.AddLast("김김김");
            myList.AddLast("박박박");
            myList.AddLast("이이이");

            Assert.Equal(myList.Count, 3);
        }

        [Fact]
        public void linkedList_맨앞에삽입()
        {
            //given 빈 연결리스트 생성 후 김수현 add
            myList.AddLast("김수현");

            // when 연결리스트 가장 처음에 전지현 add
            myList.AddLast("전지현");

            //then 연결리스트에 전지현, 김수현 순서로 들어간다.
            Assert.Equal("전지현", myList.Find("전지현").Value);
            Assert.Equal("김수현", myList.Find("김수현").Value);
        }

        [Fact]
        public void linkedList_맨끝에삽입()
        {
            //given 빈 연결리스트 생성 후 김수현 add
            myList.AddLast("김수현");

            //when 연결리스트 가장 끝에 전지현 add
            myList.AddLast("전지현");

            //then 연결리스트에 김수현, 전지현 순서로 들어간다.
            Assert.Equal("김수현", myList.Find("김수현").Value);
            Assert.Equal("전지현", myList.Find("전지현").Value);
        }


        [Fact]
        public void linkedList_중간에삽입()
        {
            ////given 빈 연결리스트 생성 후 김수현, 박해진 add
            //myList.AddFirst("김수현");
            //myList.AddFirst("박해진");

            //var myListNode = myList.Find("김수현");

            ////when 1번 index에 전지현 add
            //myList.AddBefore(myListNode, new MyLinkedListNode<string>("전지현"));

            ////then 연결리스트에 김수현, 전지현 순서로 들어간다.
            //Assert.Equal("김수현", myList.Find("김수현").Value);
            //Assert.Equal("전지현", myList.Find("전지현").Value);
            //Assert.Equal("박해진", myList.Find("박해진").Value);
        }

        [Fact]
        public void linkedList_빈노드삭제()
        {
            //given 빈 연결리스트 생성
            myList.Clear();

            //when 첫번째 노드 삭제
            Assert.Throws<InvalidOperationException>(() => myList.RemoveFirst());
        }

        [Fact]
        public void linkedList_첫노드삭제()
        {
            //given 빈 연결리스트 생성 후 김수현, 전지현 add
            myList.AddFirst("전지현");
            myList.AddFirst("김수현");

            //when 첫번째 노드 삭제
            myList.RemoveFirst();

            //then 연결리스트에 전지현만 남는다.
            Assert.Equal("전지현", myList.Find("전지현").Value);
            Assert.Equal(null, myList.Find("김수현"));
        }

        [Fact]
        public void linkedList_마지막노드삭제()
        {
            //given 빈 연결리스트 생성 후 김수현, 전지현 add
            myList.AddFirst("김수현");
            myList.AddFirst("전지현");

            //when 마지막 노드 삭제
            myList.RemoveLast();

            //then 연결리스트에 김수현만 남는다.
            Assert.Equal("전지현", myList.Find("전지현").Value);
            Assert.Equal(null, myList.Find("김수현"));
        }

        [Fact]
        public void linkedList_중간노드삭제()
        {
            //given 빈 연결리스트 생성 후 김수현, 전지현, 박해진 add
            myList.AddFirst("김수현");
            myList.AddFirst("전지현");
            myList.AddFirst("박해진");

            //when 전지현 삭제
            myList.Remove("전지현");

            //then 연결리스트에 김수현, 박해진 순서로 남는다.
            Assert.Equal("김수현", myList.Find("김수현").Value);
            Assert.Equal("박해진", myList.Find("박해진").Value);
            Assert.Equal(null, myList.Find("전지현"));
        }


        [Fact]
        public void linkedList_노드Contains()
        {
            //given 빈 연결리스트 생성 후 김수현, 전지현, 박해진 add
            myList.AddFirst("김수현");
            myList.AddFirst("전지현");
            myList.AddFirst("박해진");

            //when 전지현 삭제
            bool isContains = myList.Contains("전지현");

            //then 연결리스트에 김수현, 박해진 순서로 남는다.
            Assert.True(isContains);
        }
    }
}
