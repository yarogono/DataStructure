using System;

namespace DataStructure.Test
{
    public class MyArrayListTest
    {
        protected List<int?> list;
        protected MyArrayList<int?> myList;

        public MyArrayListTest()
        {
            list = new List<int?>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            myList = new MyArrayList<int?>();
            myList.AddRange(list);
        }

        [Fact]
        public void testmyList()
        {
            Assert.Equal(myList.Count(), 3);
        }

        [Fact]
        public void testAddT()
        {
            for (int i = 4; i < 20; i++)
            {
                myList.Add(i);
            }

            Assert.Equal(myList[18], 19);
        }

        [Fact]
        public void testAddIntT()
        {
            myList.Insert(1, 5);
            Assert.Equal(myList[1], 5);
            Assert.Equal(myList.Count(), 4);

            try
            {
                myList[-1] = 0;
                //fail();
            }
            catch (IndexOutOfRangeException e)
            {
            }

            try
            {
                myList[4] = 0;
                //fail();
            }
            catch (IndexOutOfRangeException e)
            {
            }

            myList.Insert(0, 6);
            Assert.Equal(myList[0], 6);

            myList.Insert(5, 7);
            Assert.Equal(myList[5], 7);
        }

        [Fact]
        public void testAddAllCollectionOfQextendsT()
        {
            myList.AddRange(list);
            myList.AddRange(list);
            myList.AddRange(list);
            Assert.Equal(myList.Count(), 12);
            Assert.Equal(myList[5], 3);
        }

        [Fact]
        public void testClear()
        {
            myList.Clear();
            Assert.Equal(myList.Count(), 0);
        }

        [Fact]
        public void testContains()
        {
            Assert.Equal(myList.Contains(1), true);
            Assert.Equal(myList.Contains(4), false);
            Assert.Equal(myList.Contains(null), false);
            myList.Add(null);   
            Assert.Equal(myList.Contains(null), true);
        }

        [Fact]
        public void testContainsAll()
        {
            Assert.Equal(myList.All(myList.Contains), true);
        }

        [Fact]
        public void testGet()
        {
            Assert.Equal(myList[1], 2);
        }

        [Fact]
        public void testIndexOf()
        {
            Assert.Equal(myList.IndexOf(1), 0);
            Assert.Equal(myList.IndexOf(2), 1);
            Assert.Equal(myList.IndexOf(3), 2);
            Assert.Equal(myList.IndexOf(4), -1);
        }

        [Fact]
        public void testIndexOfNull()
        {
            Assert.Equal(myList.IndexOf(null), -1);
            myList.Add(null);
            Assert.Equal(myList.IndexOf(null), 3);
        }

        [Fact]
        public void testIsEmpty()
        {
            Assert.Equal(myList.IsEmpty(), false);
            myList.Clear();
            Assert.Equal(myList.IsEmpty(), true);
        }

        [Fact]
        public void testIterator()
        {
            var iter = myList.GetEnumerator();
            Assert.Equal(iter.Current, 1);
            iter.MoveNext();

            Assert.Equal(iter.Current, 2);
            iter.MoveNext();

            Assert.Equal(iter.Current, 3);
            iter.MoveNext();

            Assert.Equal(iter.MoveNext(), false);
        }

        [Fact]
        public void testLastIndexOf()
        {
            myList.Add(2);
            Assert.Equal(myList.LastIndexOf(2), 3);
        }

        [Fact]
        public void testRemoveObject()
        {
            bool flag = myList.Remove(2);
            Assert.Equal(flag, true);
            Assert.Equal(myList.Count(), 2);
            Assert.Equal(myList[1], 3);

            flag = myList.Remove(1);
            Assert.Equal(flag, true);
            Assert.Equal(myList.Count(), 1);
            Assert.Equal(myList[0], 3);

            flag = myList.Remove(5);
            Assert.Equal(flag, false);
            Assert.Equal(myList.Count(), 1);
            Assert.Equal(myList[0], 3);

            flag = myList.Remove(3);
            Assert.Equal(flag, true);
            Assert.Equal(myList.Count(), 0);
        }

        [Fact]
        public void testRemoveInt()
        {
            int? val = myList.RemoveAt(1);
            Assert.Equal(val, 2);
            Assert.Equal(myList.Count(), 2);
            Assert.Equal(myList[1], 3);
        }

        [Fact]
        public void testRemoveAll()
        {
            myList.RemoveAll(list);
            Assert.Equal(myList.Count(), 0);
        }

        [Fact]
        public void testSet()
        {
            int? val = myList[1];
            myList[1] = 5;
            Assert.Equal(val, 2);

            val = myList[0];
            myList[0] = 6;
            Assert.Equal(val, 1);

            val = myList[2];
            myList[2] = 7;
            Assert.Equal(val, 3);

            // return value should be 2
            // list should be [6, 5, 7]
            Assert.Equal(myList[0], 6);
            Assert.Equal(myList[1], 5);
            Assert.Equal(myList[2], 7);

            try
            {
                myList[-1] = 0;
            }
            catch (IndexOutOfRangeException e) { } // good

            try
            {
                myList[4] = 0;
            }
            catch (IndexOutOfRangeException e) { } // good
        }

        [Fact]
        public void testSize()
        {
            Assert.Equal(myList.Count(), 3);
        }

        [Fact]
        public void testSubList()
        {
            myList.AddRange(list);
            MyArrayList<int?> sub = myList.SubList(1, 3);
            Assert.Equal(sub[1], 3);
        }

        [Fact]
        public void testToArray()
        {
            int?[] array = myList.ToArray();
            Assert.Equal((int)array[0], 1);
        }

    }
}