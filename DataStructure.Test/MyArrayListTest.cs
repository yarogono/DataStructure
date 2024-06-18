using System;

namespace DataStructure.Test
{
    public class MyArrayListTest
    {
        protected List<int?> list;
        protected List<int?> myList;

        public MyArrayListTest()
        {
            list = new List<int?>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            myList = new MyArrayList<int?>();
            //myList.Add((list);
        }

        [Fact]
        public void testmyList()
        {
            //Assert(myList.size()), is(3));
        }

        // 
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
            Assert.Equal(myList.Count, 4);

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


        //  /**
        //* Test method for {@link MyArrayList#addAll(java.util.Collection)}.
        //*/
        [Fact]
        public void testAddAllCollectionOfQextendsT()
        {
            myList.AddRange(list);
            myList.AddRange(list);
            myList.AddRange(list);
            Assert.Equal(myList.Count, 12);
            Assert.Equal(myList[5], 3);
        }

        //  /**
        //   * Test method for {@link MyArrayList#clear()}.
        //   */
        [Fact]
        public void testClear()
        {
            myList.Clear();
            Assert.Equal(myList.Count, 0);
        }

        //  /**
        //   * Test method for {@link MyArrayList#Contains(Object)}.
        //   */
        [Fact]
        public void testContains()
        {
            Assert.Equal(myList.Contains(1), true);
            Assert.Equal(myList.Contains(4), false);
            Assert.Equal(myList.Contains(null), false);
            myList.Add(null);   
            Assert.Equal(myList.Contains(null), true);
        }

        //  /**
        //   * Test method for {@link MyArrayList#ContainsAll(java.util.Collection)}.
        //   */
        [Fact]
        public void testContainsAll()
        {
            Assert.Equal(myList.All(myList.Contains), true);
        }

        //  /**
        //   * Test method for {@link MyArrayList#get(int)}.
        //   */
        //  [Fact]
        //  public void testGet()
        //  {
        //      Assert.Equal(myList.get(1), is (new Integer(2)));
        //  }

        //  /**
        //   * Test method for {@link MyArrayList#indexOf(Object)}.
        //   */
        //  [Fact]
        //  public void testIndexOf()
        //  {
        //      Assert.Equal(myList.indexOf(1), is (0));
        //      Assert.Equal(myList.indexOf(2), is (1));
        //      Assert.Equal(myList.indexOf(3), is (2));
        //      Assert.Equal(myList.indexOf(4), is (-1));
        //  }

        //  /**
        //   * Test method for {@link MyArrayList#indexOf(Object)}.
        //   */
        //  [Fact]
        //  public void testIndexOfNull()
        //  {
        //      Assert.Equal(myList.indexOf(null), is (-1));
        //      myList.add(null);
        //      Assert.Equal(myList.indexOf(null), is (3));
        //  }

        //  /**
        //   * Test method for {@link MyArrayList#isEmpty()}.
        //   */
        //  [Fact]
        //  public void testIsEmpty()
        //  {
        //      Assert.Equal(myList.isEmpty(), equalTo(false));
        //      myList.clear();
        //      Assert.Equal(myList.isEmpty(), equalTo(true));
        //  }

        //  /**
        //   * Test method for {@link MyArrayList#iterator()}.
        //   */
        //  [Fact]
        //  public void testIterator()
        //  {
        //      Iterator<Integer> iter = myList.iterator();
        //      Assert.Equal(iter.next(), is (new Integer(1)));
        //      Assert.Equal(iter.next(), is (new Integer(2)));
        //      Assert.Equal(iter.next(), is (new Integer(3)));
        //      Assert.Equal(iter.hasNext(), equalTo(false));
        //  }

        //  /**
        //   * Test method for {@link MyArrayList#lastIndexOf(Object)}.
        //   */
        //  [Fact]
        //  public void testLastIndexOf()
        //  {
        //      myList.add(2);
        //      Assert.Equal(myList.lastIndexOf(new Integer(2)), is (3));
        //  }

        //  /**
        //   * Test method for {@link MyArrayList#remove(Object)}.
        //   */
        //  [Fact]
        //  public void testRemoveObject()
        //  {
        //      boolean flag = myList.remove(new Integer(2));
        //      Assert.Equal(flag, equalTo(true));
        //      Assert.Equal(myList.size(), is (2));
        //      Assert.Equal(myList.get(1), is (new Integer(3)));
        //      //System.out.println(Arrays.toString(mal.toArray()));

        //      flag = myList.remove(new Integer(1));
        //      Assert.Equal(flag, equalTo(true));
        //      Assert.Equal(myList.size(), is (1));
        //      Assert.Equal(myList.get(0), is (new Integer(3)));
        //      //System.out.println(Arrays.toString(mal.toArray()));

        //      flag = myList.remove(new Integer(5));
        //      Assert.Equal(flag, equalTo(false));
        //      Assert.Equal(myList.size(), is (1));
        //      Assert.Equal(myList.get(0), is (new Integer(3)));
        //      //System.out.println(Arrays.toString(mal.toArray()));

        //      flag = myList.remove(new Integer(3));
        //      Assert.Equal(flag, equalTo(true));
        //      Assert.Equal(myList.size(), is (0));
        //      //System.out.println(Arrays.toString(mal.toArray()));
        //  }

        //  /**
        //   * Test method for {@link MyArrayList#remove(int)}.
        //   */
        //  [Fact]
        //  public void testRemoveInt()
        //  {
        //      Integer val = myList.remove(1);
        //      Assert.Equal(val, is (new Integer(2)));
        //      Assert.Equal(myList.size(), is (2));
        //      Assert.Equal(myList.get(1), is (new Integer(3)));
        //  }

        //  /**
        //   * Test method for {@link MyArrayList#removeAll(java.util.Collection)}.
        //   */
        //  [Fact]
        //  public void testRemoveAll()
        //  {
        //      myList.removeAll(list);
        //      Assert.Equal(myList.size(), is (0));
        //  }

        //  /**
        //   * Test method for {@link MyArrayList#set(int, Object)}.
        //   */
        //  [Fact]
        //  public void testSet()
        //  {
        //      Integer val = myList.set(1, 5);
        //      Assert.Equal(val, is (new Integer(2)));

        //      val = myList.set(0, 6);
        //      Assert.Equal(val, is (new Integer(1)));

        //      val = myList.set(2, 7);
        //      Assert.Equal(val, is (new Integer(3)));

        //      // return value should be 2
        //      // list should be [6, 5, 7]
        //      Assert.Equal(myList.get(0), is (new Integer(6)));
        //      Assert.Equal(myList.get(1), is (new Integer(5)));
        //      Assert.Equal(myList.get(2), is (new Integer(7)));
        //      //System.out.println(Arrays.toString(mal.toArray()));

        //      try
        //      {
        //          myList.set(-1, 0);
        //          fail();
        //      }
        //      catch (IndexOutOfBoundsException e) { } // good

        //      try
        //      {
        //          myList.set(4, 0);
        //          fail();
        //      }
        //      catch (IndexOutOfBoundsException e) { } // good
        //  }

        //  /**
        //   * Test method for {@link MyArrayList#size()}.
        //   */
        //  [Fact]
        //  public void testSize()
        //  {
        //      Assert.Equal(myList.size(), is (3));
        //  }

        //  /**
        //   * Test method for {@link MyArrayList#subList(int, int)}.
        //   */
        //  [Fact]
        //  public void testSubList()
        //  {
        //      myList.addAll(list);
        //      List<Integer> sub = myList.subList(1, 4);
        //      Assert.Equal(sub.get(1), is (new Integer(3)));
        //  }

        //  /**
        //   * Test method for {@link MyArrayList#toArray()}.
        //   */
        //  [Fact]
        //  public void testToArray()
        //  {
        //      Object[] array = myList.toArray();
        //      Assert.Equal((Integer)array[0], is (new Integer(1)));
        //  }

    }
}