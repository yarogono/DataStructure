namespace DataStructure.Test
{
    public class MyArrayListTest
    {
        protected List<int> list;
        protected List<int> myList;

        public MyArrayListTest()
        {
            list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            myList = new MyArrayList<int>();
            //myList.Add((list);
        }

        [Fact]
        public void testMyList()
        {
            //Assert(myList.size()), is(3));
        }
    }
}