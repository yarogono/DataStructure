﻿namespace DataStructure.Test
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
        public void AddThousand_test()
        {
            // Given
            int index1 = 1;
            string test1 = "test1";

            // When
            for (int i = 0; i < 1000; i++)
            {
                myLinearMap.Add(index1, test1);
            }

            // Then
            Assert.Equal(1000, myLinearMap.Count);
        }

        [Fact]
        public void Remove_test()
        {
            Assert.Fail("미구현");
            // Given


            // When


            // Then

        }


        [Fact]
        public void Get_test()
        {
            Assert.Fail("미구현");
            // Given


            // When


            // Then

        }


        [Fact]
        public void Set_test()
        {
            Assert.Fail("미구현");
            // Given


            // When


            // Then

        }

        [Fact]
        public void Size_test()
        {
            Assert.Fail("미구현");
            // Given


            // When


            // Then

        }

        [Fact]
        public void GetKeys_test()
        {
            Assert.Fail("미구현");
            // Given


            // When


            // Then

        }

        [Fact]
        public void GetValues_test()
        {
            Assert.Fail("미구현");
            // Given


            // When


            // Then

        }

        [Fact]
        public void ContainsKey_test()
        {
            Assert.Fail("미구현");
            // Given


            // When


            // Then

        }

        [Fact]
        public void ContainsValue_test()
        {
            Assert.Fail("미구현");
            // Given


            // When


            // Then

        }

        [Fact]
        public void Clear_test()
        {
            Assert.Fail("미구현");
            // Given

            
            // When


            // Then


        }
    }
}
