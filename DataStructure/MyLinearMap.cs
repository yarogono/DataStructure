using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace DataStructure
{
    [Serializable]
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
            _buckets = new int[DefaultCapacity];
            _entries = new MyEntry[DefaultCapacity];
            _keys = new KeyCollection(this);
            _values = new ValueCollection(this);
        }

        public TValue this[TKey key]
        {
            get
            {
                ref TValue value = ref FindValue(key);
                if (Unsafe.IsNullRef(ref value) == false)
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
            // ToDo : Dictionary<T> TryInsert 코드 분석

            IEqualityComparer<TKey>? comparer = _comparer;
            uint hashCode = (uint)((comparer == null) ? key.GetHashCode() : comparer.GetHashCode(key));

            uint collisionCount = 0;
            ref int bucket = ref GetBucket(hashCode);
            int i = bucket - 1; // Value in _buckets is 1-based

            if (_count == _entries.Length - 1)
            {
                Array.Resize(ref _entries, _entries.Length * 2);
            }

            _entries[_count].key = key;
            _entries[_count].value = value;
            _keys.Append(key);
            _values.Append(value);
            _count++;

            ref MyEntry entry = ref _entries![_count];
            entry.hashCode = hashCode;
            entry.next = bucket - 1; // Value in _buckets is 1-based
            entry.key = key;
            entry.value = value;
            bucket = _count + 1; // Value in _buckets is 1-based

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
                IEqualityComparer<TKey>? comparer = _comparer;
                if (comparer == null)
                {
                    // key의 HashCode를 가져온다. => C#의 GetHashCode()를 사용
                    uint hashCode = (uint)key.GetHashCode();
                    int i = GetBucket(hashCode);
                    MyEntry[]? entries = _entries;
                    uint collisionCount = 0;
                    if (typeof(TKey).IsValueType)
                    {
                        i--;
                        do
                        {
                            if ((uint)i >= (uint)entries.Length)
                            {
                                goto ReturnNotFound;
                            }

                            entry = ref entries[i];
                            if (entry.hashCode == hashCode && EqualityComparer<TKey>.Default.Equals(key, entry.key))
                            {
                                goto ReturnFound;
                            }
                            i = entry.next;

                            collisionCount++;
                        } while (collisionCount <= (uint)entries.Length);
                    }
                    else
                    {
                        EqualityComparer<TKey> defaultComparer = EqualityComparer<TKey>.Default;

                        i--;
                        do
                        {
                            if ((uint)i >= (uint)entries.Length)
                            {
                                goto ReturnNotFound;
                            }

                            entry = ref entries[i];
                            if (entry.hashCode == hashCode && defaultComparer.Equals(entry.key, key))
                            {
                                goto ReturnFound;
                            }

                            i = entry.next;

                            collisionCount++;
                        } while (collisionCount <= (uint)entries.Length);

                        goto ConcurrentOperation;
                    }
                }
                else
                {
                    uint hashCode = (uint)comparer.GetHashCode(key);
                    int i = GetBucket(hashCode);
                    MyEntry[]? entries = _entries;
                    uint collisionCount = 0;
                    i--;
                    do
                    {
                        if ((uint)i >= (uint)entries.Length)
                        {
                            goto ReturnNotFound;
                        }

                        entry = ref entries[i];
                        if (entry.hashCode == hashCode && comparer.Equals(entry.key, key))
                        {
                            goto ReturnFound;
                        }

                        i = entry.next;

                        collisionCount++;
                    } while (collisionCount <= (uint)entries.Length);

                    goto ConcurrentOperation;
                }

                // The chain of entries forms a loop; which means a concurrent update has happened.
                // Break out of the loop and throw, rather than looping forever.
                goto ConcurrentOperation;
            }

            goto ReturnNotFound;

        ConcurrentOperation:
            throw new Exception();
        ReturnFound:
            ref TValue value = ref entry.value;
        Return:
            return ref value;
        ReturnNotFound:
            value = ref Unsafe.NullRef<TValue>();
            goto Return;
        }

        // ToDo : GetBucket 코드 작성
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
            _buckets = new int[DefaultCapacity];
            _entries = new MyEntry[DefaultCapacity];
            _keys = new KeyCollection(this);
            _values = new ValueCollection(this);
            _count = 0;
        }

        public void Remove(KeyValuePair<TKey, TValue> keyValuePair)
        {

        }

        public bool ContainsKey(TKey key)
        {
            if (_keys == null)
            {
                return false;
            }

            bool isContains = _keys.Contains(key);


            return isContains;
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
