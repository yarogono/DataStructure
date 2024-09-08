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
            string item1 = "Test1`";
            string item2 = "Test2`";
            string item3 = "Test3`";

            _myQueue.Enqueue(item1);
            _myQueue.Enqueue(item2);
            _myQueue.Enqueue(item3);

            // When
            int myQueueCount = _myQueue.Count();

            // Then
            Assert.Equal(myQueueCount, 3);
        }


        [Fact]
        public void Clear_test()
        {
            // Given
            string item1 = "Test1`";
            string item2 = "Test2`";
            string item3 = "Test3`";

            _myQueue.Enqueue(item1);
            _myQueue.Enqueue(item2);
            _myQueue.Enqueue(item3);

            // When
            _myQueue.Clear();

            // Then
            Assert.Equal(0, _myQueue.Count());
        }


        [Fact]
        public void Contains_test()
        {
            // Given
            string item1 = "Test1`";
            string item2 = "Test2`";
            string item3 = "Test3`";

            _myQueue.Enqueue(item1);
            _myQueue.Enqueue(item2);
            _myQueue.Enqueue(item3);

            // When
            bool isContain = _myQueue.Contains(item3);

            // Then
            Assert.True(isContain);
        }

        [Fact]
        public void Enqueue_test()
        {
            // Given
            string item1 = "Test1`";
            string item2 = "Test2`";
            string item3 = "Test3`";

            _myQueue.Enqueue(item1);
            _myQueue.Enqueue(item2);
            _myQueue.Enqueue(item3);

            // When
            string queueItem1 = _myQueue.Peek();

            // Then
            Assert.Equal(item1, queueItem1);
            Assert.Equal(3, _myQueue.Count());
        }

        [Fact]
        public void EnqueueGrow_test()
        {
            // Given
            string item = "Test`";


            // When, Then

            for (int i = 0; i < 1000; i++)
            {
                _myQueue.Enqueue(item + i);
            }
        }


        [Fact]
        public void Dequeue_test()
        {
            // Given
            string item1 = "Test1`";
            string item2 = "Test2`";
            string item3 = "Test3`";

            _myQueue.Enqueue(item1);
            _myQueue.Enqueue(item2);
            _myQueue.Enqueue(item3);

            // When
            string dequeueItem = _myQueue.Dequeue();

            // Then
            Assert.Equal(dequeueItem, item1);
            Assert.Equal(2, _myQueue.Count());
        }


        [Fact]
        public void Peek_test()
        {
            // Given
            string item1 = "Test1`";
            string item2 = "Test2`";
            string item3 = "Test3`";

            _myQueue.Enqueue(item1);
            _myQueue.Enqueue(item2);
            _myQueue.Enqueue(item3);

            // When
            string peekItem = _myQueue.Peek();

            // Then
            Assert.Equal(item1, peekItem);
        }


        [Fact]
        public void ToArray_test()
        {
            // Given
            string item1 = "Test1`";
            string item2 = "Test2`";
            string item3 = "Test3`";

            _myQueue.Enqueue(item1);
            _myQueue.Enqueue(item2);
            _myQueue.Enqueue(item3);

            // When
            string[] queueArray  = _myQueue.ToArray();

            // Then
            Assert.Equal(queueArray.Length , _myQueue.Count());

            int i = 0;
            foreach (string item in _myQueue)
            {
                Assert.Equal(queueArray[i], item);
                i++;
            }
        }

        [Fact]
        public void TryPeek_test()
        {
            // Given
            string item1 = "Test1`";
            string item2 = "Test2`";
            string item3 = "Test3`";

            _myQueue.Enqueue(item1);
            _myQueue.Enqueue(item2);
            _myQueue.Enqueue(item3);

            // When

            string result;
            bool isSuccess = _myQueue.TryPeek(out result);

            // Then
            Assert.Equal(result, item1);
            Assert.Equal(3, _myQueue.Count());
            Assert.True(isSuccess);
        }

        [Fact]
        public void TryDequeue_test()
        {
            // Given
            string item1 = "Test1`";
            string item2 = "Test2`";
            string item3 = "Test3`";

            _myQueue.Enqueue(item1);
            _myQueue.Enqueue(item2);
            _myQueue.Enqueue(item3);

            // When
            string result;
            bool isSuccess = _myQueue.TryDequeue(out result);

            // Then
            Assert.Equal(result, item1);
            Assert.Equal(2, _myQueue.Count());
            Assert.True(isSuccess);
        }
    }
}
