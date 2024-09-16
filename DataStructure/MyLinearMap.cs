namespace DataStructure
{
    public class MyLinearMap<TKey, TValue> : Dictionary<TKey, TValue>
    {

        private KeyCollection? keys;
        private ValueCollection? values;
    }
}
