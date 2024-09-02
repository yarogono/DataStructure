namespace DataStructure.Test
{
    public class MyLinkedListTest
    {
        MyLinkedList<string> myList;

        public MyLinkedListTest()
        {
            myList = new MyLinkedList<string>();
            myList.AddLast("테스트1");
            myList.AddLast("테스트2");
            myList.AddLast("테스트3");
        }

        [Fact]
        public void AddMyLinkedList_test()
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
        public void Length_test()
        {
            myList.AddLast("김김김");
            myList.AddLast("박박박");
            myList.AddLast("이이이");

            Assert.Equal(myList.Count, 6);
        }

        [Fact]
        public void 맨앞에삽입_test()
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
        public void 맨끝에삽입_test()
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
        public void AddBeforeNode_test()
        {
            //given
            myList.AddFirst("김수현");
            myList.AddFirst("박해진");

            var myListNode = myList.Find("김수현");

            //when
            var newNode = new MyLinkedListNode<string>("전지현");
            myList.AddBefore(myListNode, newNode);

            //then
            Assert.Equal("김수현", myList.Find("김수현").Value);
            Assert.Equal("전지현", myList.Find("전지현").Value);
            Assert.Equal("박해진", myList.Find("박해진").Value);
        }

        [Fact]
        public void AddAfterNode_test()
        {
            //given
            myList.AddFirst("김수현");
            myList.AddFirst("박해진");

            var myListNode = myList.Find("김수현");

            //when
            myList.AddAfter(myListNode, new MyLinkedListNode<string>("전지현"));

            //then
            Assert.Equal("김수현", myList.Find("김수현").Value);
            Assert.Equal("전지현", myList.Find("전지현").Value);
            Assert.Equal("박해진", myList.Find("박해진").Value);
        }

        [Fact]
        public void AddBefore_test()
        {
            //given
            myList.AddFirst("김수현");
            myList.AddFirst("박해진");

            var myListNode = myList.Find("김수현");

            //when
            myList.AddBefore(myListNode, "전지현");

            //then
            Assert.Equal("김수현", myList.Find("김수현").Value);
            Assert.Equal("전지현", myList.Find("전지현").Value);
            Assert.Equal("박해진", myList.Find("박해진").Value);
        }

        [Fact]
        public void AddAfter_test()
        {
            //given
            myList.AddFirst("김수현");
            myList.AddFirst("박해진");

            var myListNode = myList.Find("김수현");

            //when
            var addedNode = myList.AddAfter(myListNode, "전지현");

            //then
            Assert.Equal("김수현", myList.Find("김수현").Value);
            Assert.Equal("전지현", myList.Find("전지현").Value);
            Assert.Equal("박해진", myList.Find("박해진").Value);
            Assert.Equal(addedNode.Value, "전지현");
        }

        [Fact]
        public void 빈노드삭제_test()
        {
            //given 빈 연결리스트 생성
            myList.Clear();

            //when 첫번째 노드 삭제
            Assert.Throws<InvalidOperationException>(() => myList.RemoveFirst());
        }

        [Fact]
        public void 첫노드삭제_test()
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
        public void 마지막노드삭제_test()
        {
            //given 빈 연결리스트 생성 후 김수현, 전지현 add
            myList.Clear();
            myList.AddFirst("김수현");
            myList.AddFirst("전지현");

            //when 마지막 노드 삭제
            myList.RemoveLast();

            //then 연결리스트에 김수현만 남는다.
            Assert.Equal("전지현", myList.Find("전지현").Value);
            Assert.Equal(null, myList.Find("김수현"));
        }

        [Fact]
        public void 중간노드삭제_test()
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
        public void 노드Contains_test()
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

        [Fact]
        public void FindLast_test()
        {
            //given
            myList.AddFirst("김수현");
            myList.AddFirst("전지현");
            myList.AddFirst("박해진");

            //when
            var findNode = myList.FindLast("박해진");
            var findNode2 = myList.FindLast("없는값");

            //then
            Assert.Equal(findNode.Value, "박해진");
            Assert.Null(findNode2);
        }

        [Fact]
        public void AddFirst_Number()
        {
            // Given
            MyLinkedList<int> myNumLinkedList = new();

            // When
            myNumLinkedList.AddFirst(1);
            myNumLinkedList.AddFirst(2);


            // Then
            Assert.Equal(myNumLinkedList.Count, 2);
            Assert.Equal(myNumLinkedList.First.Value, 2);
        }
    }
}
