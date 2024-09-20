using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace DataStructure
{
    public class MyLinearMap<TKey, TValue> : Dictionary<TKey, TValue>
    {
        private int[]? _buckets;
        private MyEntry[]? _entries;

        private int _count;

        private IEqualityComparer<TKey>? _comparer;
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
                ref TValue value = ref FindValue(key);
                if (!Unsafe.IsNullRef(ref value))
                {
                    return value;
                }

                return default;
            }

            set
            {
                bool modified = TryInsert(key, value);
            }
        }



        public void Add(TKey key, TValue value)
        {
            if (key == null)
            {
                new ArgumentException();
            }

            if (_buckets == null)
            {
                _buckets = new int[DefaultCapacity];
            }

            TryInsert(key, value);
        }

        private bool TryInsert(TKey key, TValue value)
        {
            IEqualityComparer<TKey>? comparer = _comparer;
            uint hashCode = (uint)((comparer == null) ? key.GetHashCode() : comparer.GetHashCode(key));

            uint collisionCount = 0;
            ref int bucket = ref GetBucket(hashCode);
            int i = bucket - 1; // Value in _buckets is 1-based

            if (_count == _entries.Length)
            {
                Array.Resize(ref _entries, _entries.Length * 2);
            }

            _entries[_count].key = key;
            _entries[_count].value = value;
            _keys.Append(key);
            _values.Append(value);
            _count++;

            return true;
        }

        internal ref TValue FindValue(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException();
            }

            ref MyEntry entry = ref Unsafe.NullRef<MyEntry>();
            if (_buckets != null)
            {
                Debug.Assert(_entries != null, "expected entries to be != null");
                IEqualityComparer<TKey> comparer = _comparer;
                if (comparer == null)
                {

                }
            }

            ref TValue value = ref entry.value;

            return ref value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ref int GetBucket(uint hashCode)
        {
            int[] buckets = _buckets!;
#if TARGET_64BIT
            return ref buckets[HashHelpers.FastMod(hashCode, (uint)buckets.Length, _fastModMultiplier)];
#else
            return ref buckets[hashCode % (uint)buckets.Length];
#endif
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
