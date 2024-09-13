namespace DataStructure.Test
{
    public class MyLinkedListTest
    {
        MyLinkedList<string> myList;

        public MyLinkedListTest()
        {
            myList = new MyLinkedList<string>();
        }

        [Fact]
        public void AddMyLinkedList_test()
        {
            // Given
            var myLinkedList = new MyLinkedList<string>();
            myLinkedList.AddLast("테스트1");
            myLinkedList.AddLast("테스트2");
            myLinkedList.AddLast("테스트3");
            myList = new MyLinkedList<string>();

            // When
            myList.AddAll(myLinkedList);

            // Then
            Assert.Equal(myList.Count, myLinkedList.Count);
        }

        [Fact]
        public void Length_test()
        {
            // Given, When
            myList.AddLast("김김김");
            myList.AddLast("박박박");
            myList.AddLast("이이이");

            // Then
            Assert.Equal(myList.Count, 3);
        }

        [Fact]
        public void 맨앞에삽입_test()
        {
            // Given
            myList.AddLast("김수현");

            // When
            myList.AddLast("전지현");

            // Then
            Assert.Equal("전지현", myList.Find("전지현").Value);
            Assert.Equal("김수현", myList.Find("김수현").Value);
        }

        [Fact]
        public void 맨끝에삽입_test()
        {
            // Given
            myList.AddLast("김수현");

            // When
            myList.AddLast("전지현");

            // Then
            Assert.Equal("김수현", myList.Find("김수현").Value);
            Assert.Equal("전지현", myList.Find("전지현").Value);
        }


        [Fact]
        public void AddBeforeNode_test()
        {
            // Given
            myList.AddFirst("김수현");
            myList.AddFirst("박해진");

            var myListNode = myList.Find("김수현");

            // When
            var newNode = new MyLinkedListNode<string>("전지현");
            myList.AddBefore(myListNode, newNode);

            // Then
            Assert.Equal("김수현", myList.Find("김수현").Value);
            Assert.Equal("전지현", myList.Find("전지현").Value);
            Assert.Equal("박해진", myList.Find("박해진").Value);
        }

        [Fact]
        public void AddAfterNode_test()
        {
            // Given
            myList.AddFirst("김수현");
            myList.AddFirst("박해진");

            var myListNode = myList.Find("김수현");

            // When
            myList.AddAfter(myListNode, new MyLinkedListNode<string>("전지현"));

            // Then
            Assert.Equal("김수현", myList.Find("김수현").Value);
            Assert.Equal("전지현", myList.Find("전지현").Value);
            Assert.Equal("박해진", myList.Find("박해진").Value);
        }

        [Fact]
        public void AddBefore_test()
        {
            // Given
            myList.AddFirst("김수현");
            myList.AddFirst("박해진");

            var myListNode = myList.Find("김수현");

            // When
            myList.AddBefore(myListNode, "전지현");

            // Then
            Assert.Equal("김수현", myList.Find("김수현").Value);
            Assert.Equal("전지현", myList.Find("전지현").Value);
            Assert.Equal("박해진", myList.Find("박해진").Value);
        }

        [Fact]
        public void AddAfter_test()
        {
            // Given
            myList.AddFirst("김수현");
            myList.AddFirst("박해진");

            var myListNode = myList.Find("김수현");

            // When
            var addedNode = myList.AddAfter(myListNode, "전지현");

            // Then
            Assert.Equal("김수현", myList.Find("김수현").Value);
            Assert.Equal("전지현", myList.Find("전지현").Value);
            Assert.Equal("박해진", myList.Find("박해진").Value);
            Assert.Equal(addedNode.Value, "전지현");
        }

        [Fact]
        public void 빈노드삭제_test()
        {
            // Given
            myList.Clear();

            // when, Then
            Assert.Throws<InvalidOperationException>(() => myList.RemoveFirst());
        }

        [Fact]
        public void 첫노드삭제_test()
        {
            // Given
            myList.AddFirst("전지현");
            myList.AddFirst("김수현");

            // When
            myList.RemoveFirst();

            // Then
            Assert.Equal("전지현", myList.Find("전지현").Value);
            Assert.Equal(null, myList.Find("김수현"));
        }

        [Fact]
        public void 마지막노드삭제_test()
        {
            // Given
            myList.Clear();
            myList.AddFirst("김수현");
            myList.AddFirst("전지현");

            // When
            myList.RemoveLast();

            // Then
            Assert.Equal("전지현", myList.Find("전지현").Value);
            Assert.Equal(null, myList.Find("김수현"));
        }

        [Fact]
        public void 중간노드삭제_test()
        {
            // Given
            myList.AddFirst("김수현");
            myList.AddFirst("전지현");
            myList.AddFirst("박해진");

            // When
            myList.Remove("전지현");

            // Then
            Assert.Equal("김수현", myList.Find("김수현").Value);
            Assert.Equal("박해진", myList.Find("박해진").Value);
            Assert.Equal(null, myList.Find("전지현"));
        }


        [Fact]
        public void 노드Contains_test()
        {
            // Given
            myList.AddFirst("김수현");
            myList.AddFirst("전지현");
            myList.AddFirst("박해진");

            // When
            bool isContains = myList.Contains("전지현");

            // Then
            Assert.True(isContains);
        }

        [Fact]
        public void FindLast_test()
        {
            // Given
            myList.AddFirst("김수현");
            myList.AddFirst("전지현");
            myList.AddFirst("박해진");

            // When
            var findNode = myList.FindLast("박해진");
            var findNode2 = myList.FindLast("없는값");

            // Then
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
