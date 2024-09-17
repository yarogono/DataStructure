namespace DataStructure
{
    public class MyLinearMap<TKey, TValue> : Dictionary<TKey, TValue>
    {
        private int[]? _buckets;
        private MyEntry[]? _entries;

        private int _count;

        private KeyCollection? _keys;
        private ValueCollection? _values;

        public int Count { get { return _count; } }

        public KeyCollection Keys => _keys ??= new KeyCollection(this);
        public ValueCollection Values => _values ??= new ValueCollection(this);

        private const int DefaultCapacity = 10;

        public MyLinearMap()
        {
            _entries = new MyEntry[DefaultCapacity];
            _keys = new KeyCollection(this);
            _values = new ValueCollection(this);
        }

        public TValue this[TKey key]
        {
            get
            {
                return default;
            }

            set
            {

            }
        }



        public void Add(TKey key, TValue value)
        {
            if (_count == _entries.Length)
            {
                Array.Resize(ref _entries, _entries.Length * 2);
            }

            _entries[_count].key = key;
            _entries[_count].value = value;
            _keys.Append(key);
            _values.Append(value);
            _count++;
        }

        public void Clear()
        {

        }

        public void Remove(KeyValuePair<TKey, TValue> keyValuePair)
        {

        }

        public bool ContainsKey(TKey key)
        {
            return true;
        }

        public bool ContainsValue(TValue value)
        {
            return true;
        }


        public struct MyEntry
        {
            public uint hashCode;

            public int next;
            public TKey key;
            public TValue value;
        }
    }

}
