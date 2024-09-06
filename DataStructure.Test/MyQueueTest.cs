namespace DataStructure.Test
{
    public class MyQueueTest
    {
        private MyQueue<string> _myQueue;

        public MyQueueTest()
        {
            _myQueue = new MyQueue<string>();
        }

        [Fact]
        public void Count_test()
        {
            // Given
            _myQueue.Enqueue("Test1");
            _myQueue.Enqueue("Test2");
            _myQueue.Enqueue("Test3");

            // When
            int myQueueCount = _myQueue.Count();

            // Then
            Assert.Equal(myQueueCount, 3);
        }


        [Fact]
        public void Clear_test()
        {
            Assert.Fail("ToDo");
            // Given


            // When


            // Then

        }


        [Fact]
        public void Contains_test()
        {
            Assert.Fail("ToDo");
            // Given


            // When


            // Then

        }

        [Fact]
        public void Enqueue_test()
        {
            Assert.Fail("ToDo");
            // Given


            // When


            // Then

        }


        [Fact]
        public void Dequeue_test()
        {
            Assert.Fail("ToDo");
            // Given


            // When


            // Then

        }


        [Fact]
        public void Peek_test()
        {
            Assert.Fail("ToDo");
            // Given


            // When


            // Then

        }


        [Fact]
        public void ToArray_test()
        {
            Assert.Fail("ToDo");
            // Given


            // When


            // Then

        }

        [Fact]
        public void TryPeek_test()
        {
            Assert.Fail("ToDo");

            // Given


            // When


            // Then

        }

        [Fact]
        public void TryDequeue_test()
        {
            Assert.Fail("ToDo");

            // Given


            // When


            // Then

        }
    }
}
