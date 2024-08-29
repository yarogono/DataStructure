using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Test
{
    public class MyStackTest
    {
        private MyStack<string> myStackString;
        private MyStack<int> myStackNumber;


        public MyStackTest()
        {
            this.myStackString = new();
            this.myStackNumber = new();
        }

        [Fact]
        public void MyStackPushTest()
        {
            // Given
            string myStack1 = "MyStack1";
            string myStack2 = "MyStack2";
            string myStack3 = "MyStack3";

            // When
            myStackString.Push(myStack1);
            myStackString.Push(myStack2);
            myStackString.Push(myStack3);


            // Then
            Assert.True(myStackString.Contains(myStack1));
            Assert.Equal(3, myStackString.Count());
            Assert.Equal(myStack3, myStackString.Peek());
        }


        [Fact]
        public void MyStackPopTest()
        {
            // Given
            string myStack1 = "MyStack1";
            string myStack2 = "MyStack2";
            string myStack3 = "MyStack3";
            myStackString.Push(myStack1);
            myStackString.Push(myStack2);
            myStackString.Push(myStack3);

            // When
            string popMyStack3 = myStackString.Pop();

            // Then
            Assert.Equal(myStack3, popMyStack3);
            Assert.Equal(2, myStackString.Count());
        }

        [Fact]
        public void MyStackClearTest()
        {
            // Given
            string myStack1 = "MyStack1";
            string myStack2 = "MyStack2";
            string myStack3 = "MyStack3";
            myStackString.Push(myStack1);
            myStackString.Push(myStack2);
            myStackString.Push(myStack3);

            // When
            myStackString.Clear();

            // Then
            Assert.Equal(0, myStackString.Count());
            Assert.False(myStackString.Contains(myStack3));
        }


        [Fact]
        public void MyStackToArrayTest()
        {
            // Given
            string myStack1 = "MyStack1";
            string myStack2 = "MyStack2";
            string myStack3 = "MyStack3";
            myStackString.Push(myStack1);
            myStackString.Push(myStack2);
            myStackString.Push(myStack3);

            // When
            string[] myStackArr = myStackString.ToArray();

            // Then
            Assert.Equal(myStackArr.Length, myStackString.Count());
        }


        [Fact]
        public void MyStackContainsTest()
        {
            // Given
            string myStack1 = "MyStack1";
            string myStack2 = "MyStack2";
            string myStack3 = "MyStack3";
            myStackString.Push(myStack1);
            myStackString.Push(myStack2);
            myStackString.Push(myStack3);

            bool[] isContainsArr = new bool[3];

            // When
            isContainsArr[0] = myStackString.Contains(myStack1);
            isContainsArr[1] = myStackString.Contains(myStack2);
            isContainsArr[3] = myStackString.Contains(myStack3);

            // Then
            foreach (bool item in isContainsArr)
            {
                Assert.True(item);
            }
        }

        [Fact]
        public void MyStackPeekTest()
        {
            // Given
            string myStack1 = "MyStack1";
            string myStack2 = "MyStack2";
            string myStack3 = "MyStack3";
            myStackString.Push(myStack1);
            myStackString.Push(myStack2);
            myStackString.Push(myStack3);


            // When
            var peekItem = myStackString.Peek();


            // Then
            Assert.Equal(3, myStackString.Count);
            Assert.Equal(myStack3, peekItem);
        }
    }
}
