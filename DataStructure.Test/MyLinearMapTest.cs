namespace DataStructure.Test
{
    public class MyLinearMapTest
    {
        MyLinearMap<int, string> myLinearMap;

        public MyLinearMapTest()
        {
            this.myLinearMap = new();
        }

        [Fact]
        public void Add_test()
        {
            // Given
            int index1 = 1;
            string test1 = "test1";

            // When
            myLinearMap.Add(index1, test1);

            // Then
            Assert.Equal(1, myLinearMap.Count);
            Assert.Equal(test1, myLinearMap[index1]);
        }

        [Fact]
        public void AddThousandElements_test()
        {
            // Given
            string test1 = "test1";

            // When
            for (int i = 1; i <= 1000; i++)
            {
                myLinearMap.Add(i, test1);
            }

            // Then
            Assert.Equal(1000, myLinearMap.Count);
        }

        [Fact]
        public void Remove_test()
        {
            // Given
            int index1 = 1;
            string test1 = "test1";
            myLinearMap.Add(index1, test1);

            // When
            bool isRemoved = myLinearMap.Remove(index1);

            // Then
            Assert.True(isRemoved);
            Assert.Null(myLinearMap[index1]);
        }


        [Fact]
        public void Get_test()
        {
            // Given
            int index1 = 1;
            string test1 = "test1";
            myLinearMap.Add(index1, test1);

            // When
            var value = myLinearMap[index1];

            // Then
            Assert.Equal(value, test1);
        }


        [Fact]
        public void Set_test()
        {
            // Given
            int index1 = 1;
            string test1 = "test1";
            myLinearMap.Add(index1, test1);

            // When
            myLinearMap[2] = "test2";

            // Then
            Assert.Equal(myLinearMap.Count, 2);
            Assert.Equal(myLinearMap[2], "test2");
            Assert.Equal(myLinearMap[1], "test1");
        }

        [Fact]
        public void Count_test()
        {
            // Given
            int index1 = 1;
            string test1 = "test1";
            myLinearMap.Add(index1, test1);

            // When
            int myLinearMapCount = myLinearMap.Count;
            int myLinearMapCount2 = myLinearMap.Count();

            // Then
            Assert.Equal(myLinearMapCount, 1);
            Assert.Equal(myLinearMapCount2, 1);
        }

        [Fact]
        public void GetKeys_test()
        {
            // Given
            int index1 = 1;
            string test1 = "test1";
            myLinearMap.Add(index1, test1);

            // When
            var keys = myLinearMap.Keys;

            // Then
            Assert.Equal(keys.Count, 1);

            foreach (var key in keys)
            {
                Assert.Equal(key, index1);
            }
        }

        [Fact]
        public void GetValues_test()
        {
            // Given
            int index1 = 1;
            string test1 = "test1";
            myLinearMap.Add(index1, test1);

            // When
            var values = myLinearMap.Values;

            // Then
            Assert.Equal(values.Count, 1);

            foreach (var value in values)
            {
                Assert.Equal(value, test1);
            }

        }

        [Fact]
        public void ContainsKey_test()
        {
            // Given
            int index1 = 1;
            string test1 = "test1";
            myLinearMap.Add(index1, test1);

            // When
            bool isContainIndex1 = myLinearMap.ContainsKey(index1);
            bool isContainIndex2 = myLinearMap.ContainsKey(2);

            // Then
            Assert.True(isContainIndex1);
            Assert.False(isContainIndex2);
        }

        [Fact]
        public void ContainsValue_test()
        {
            // Given
            int index1 = 1;
            string test1 = "test1";
            myLinearMap.Add(index1, test1);

            // When
            bool isContainValue = myLinearMap.ContainsValue(test1);
            bool isContainValue2 = myLinearMap.ContainsValue("test2");

            // Then
            Assert.True(isContainValue);
            Assert.False(isContainValue2);
        }

        [Fact]
        public void Clear_test()
        {
            // Given
            int index1 = 1;
            string test1 = "test1";

            for (int i = 0; i < 10; i++)
            {
                myLinearMap.Add(index1, test1);
            }

            // When
            myLinearMap.Clear();


            // Then
            Assert.Equal(0, myLinearMap.Count);
        }

        [Fact]
        public void KeyCollectionCopyToTKey_test()
        {
            // Given
            string test1 = "test1";

            for (int i = 0; i < 10; i++)
            {
                myLinearMap.Add(i, test1);
            }

            // When
            var keys = myLinearMap.Keys;

            int startIndex = 0;
            int[] keyNums = new int[myLinearMap.Count];
            keys.CopyTo(keyNums, startIndex);


            // Then
            foreach (int key in keys)
            {
                Assert.Equal(keyNums[startIndex], key);
                startIndex++;
            }
        }

        [Fact]
        public void KeyCollectionCopyToArray_test()
        {
            // Given
            string test1 = "test1";

            for (int i = 0; i < 10; i++)
            {
                myLinearMap.Add(i, test1);
            }

            // When
            var keys = myLinearMap.Keys;

            int startIndex = 0;
            Array[] keyArray = new Array[myLinearMap.Count];
            keys.CopyTo(keyArray, startIndex);


            // Then
            foreach (int key in keys)
            {
                Assert.Equal(keyArray.GetValue(startIndex), key);
                startIndex++;
            }
        }
    }
}
