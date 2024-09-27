using Microsoft.Internal.VisualStudio.Shell;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static DataStructure.MyLinearMap<TKey, TValue>;

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

            if (key == null)
            {
                throw new Exception();
            }

            if (_buckets == null)
            {
                Initialize(0);
            }

            MyEntry[]? entries = _entries;

            IEqualityComparer<TKey>? comparer = _comparer;
            uint hashCode = (uint)((comparer == null) ? key.GetHashCode() : comparer.GetHashCode(key));

            uint collisionCount = 0;
            ref int bucket = ref GetBucket(hashCode);
            int i = bucket - 1; // Value in _buckets is 1-based

            if (comparer == null)
            {
                if (typeof(TKey).IsValueType)
                {
                    while (true)
                    {
                        if ((uint)i >= (uint)entries.Length)
                        {
                            break;
                        }

                        if (entries[i].hashCode == hashCode && EqualityComparer<TKey>.Default.Equals(entries[i].key, key))
                        {
                            entries[i].value = value;
                            return true;
                        }

                        i = entries[i].next;

                        collisionCount++;
                        if (collisionCount > (uint)entries.Length)
                        {
                            throw new Exception();
                        }
                    }
                }
                else
                {
                    EqualityComparer<TKey> defaultComparer = EqualityComparer<TKey>.Default;
                    while (true)
                    {
                        // Should be a while loop https://github.com/dotnet/runtime/issues/9422
                        // Test uint in if rather than loop condition to drop range check for following array access
                        if ((uint)i >= (uint)entries.Length)
                        {
                            break;
                        }

                        if (entries[i].hashCode == hashCode && defaultComparer.Equals(entries[i].key, key))
                        {
                            entries[i].value = value;
                            return true;
                        }

                        i = entries[i].next;

                        collisionCount++;
                        if (collisionCount > (uint)entries.Length)
                        {
                            // The chain of entries forms a loop; which means a concurrent update has happened.
                            // Break out of the loop and throw, rather than looping forever.
                            throw new Exception();
                        }
                    }
                }
            }
            else
            {
                while (true)
                {
                    // Should be a while loop https://github.com/dotnet/runtime/issues/9422
                    // Test uint in if rather than loop condition to drop range check for following array access
                    if ((uint)i >= (uint)entries.Length)
                    {
                        break;
                    }

                    if (entries[i].hashCode == hashCode && comparer.Equals(entries[i].key, key))
                    {
                        entries[i].value = value;
                        return true;
                    }

                    i = entries[i].next;

                    collisionCount++;
                    if (collisionCount > (uint)entries.Length)
                    {
                        // The chain of entries forms a loop; which means a concurrent update has happened.
                        // Break out of the loop and throw, rather than looping forever.
                        throw new Exception();
                    }
                }
            }

            int index;
            if (_freeCount > 0)
            {
                index = _freeList;
                Debug.Assert((StartOfFreeList - entries[_freeList].next) >= -1, "shouldn't overflow because `next` cannot underflow");
                _freeList = StartOfFreeList - entries[_freeList].next;
                _freeCount--;
            }
            else
            {
                int count = _count;
                if (count == entries.Length)
                {
                    Resize();
                    bucket = ref GetBucket(hashCode);
                }
                index = count;
                _count = count + 1;
                entries = _entries;
            }

            ref MyEntry entry = ref entries![index];
            entry.hashCode = hashCode;
            entry.next = bucket - 1; // Value in _buckets is 1-based
            entry.key = key;
            entry.value = value;
            bucket = index + 1; // Value in _buckets is 1-based

            // Value types never rehash
            if (!typeof(TKey).IsValueType && collisionCount > HashHelpers.HashCollisionThreshold && comparer is NonRandomizedStringEqualityComparer)
            {
                // If we hit the collision threshold we'll need to switch to the comparer which is using randomized string hashing
                // i.e. EqualityComparer<string>.Default.
                Array.Resize<MyEntry>(entries, entries.Length);
            }

            return true;
        }

        private int Initialize(int capacity)
        {
            int size = HashHelpers.GetStableHashCode(capacity);
            int[] buckets = new int[size];
            MyEntry[] entries = new MyEntry[size];

            // Assign member variables after both arrays allocated to guard against corruption from OOM if second fails
            _freeList = -1;
#if TARGET_64BIT
            _fastModMultiplier = HashHelpers.GetFastModMultiplier((uint)size);
#endif
            _buckets = buckets;
            _entries = entries;

            return size;
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
