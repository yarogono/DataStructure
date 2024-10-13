using System.Collections;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace DataStructure
{
    [Serializable]
    public class MyLinearMap<TKey, TValue> : IDictionary<TKey, TValue>, IDictionary, IReadOnlyDictionary<TKey, TValue>, ISerializable, IDeserializationCallback where TKey : notnull
    {
        private int[]? _buckets;
        private MyEntry[]? _entries;

        private int _count;
        private int _freeList;
        private int _freeCount;
        private IEqualityComparer<TKey>? _comparer;
        private KeyCollection? _keys;
        private ValueCollection? _values;
        private const int StartOfFreeList = -3;

        public int Count => _count - _freeCount;

        public KeyCollection Keys => _keys ??= new KeyCollection(this);
        public ValueCollection Values => _values ??= new ValueCollection(this);

        ICollection IDictionary.Keys => Keys;
        ICollection<TKey> IDictionary<TKey, TValue>.Keys => Keys;
        IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys => Keys;

        ICollection IDictionary.Values => Values;
        ICollection<TValue> IDictionary<TKey, TValue>.Values => Values;
        IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values => Values;

        bool IDictionary.IsFixedSize => false;

        bool IDictionary.IsReadOnly => false;
        bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => false;

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();



        public object? this[object key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private const int DefaultCapacity = 10;

        public MyLinearMap() : this(0, null) { }

        public MyLinearMap(int capacity, IEqualityComparer<TKey>? comparer)
        {
            if (capacity > 0)
            {
                Initialize(capacity);
            }
            else
            {
                Initialize(DefaultCapacity);
            }

            if (comparer != null)
            {
                _comparer = comparer;
            }
            else
            {
                _comparer  = EqualityComparer<TKey>.Default;
            }
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
                    //Resize();
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
            if (!typeof(TKey).IsValueType && collisionCount > HashHelpers.HashCollisionThreshold)
            {
                // If we hit the collision threshold we'll need to switch to the comparer which is using randomized string hashing
                // i.e. EqualityComparer<string>.Default.
                Array.Resize(ref entries, entries.Length);
            }

            return true;
        }

        private int Initialize(int capacity)
        {
            int size = HashHelpers.GetPrime(capacity);
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

        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            throw new NotImplementedException();
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Add(object key, object? value)
        {
            throw new NotImplementedException();
        }

        public bool Contains(object key)
        {
            throw new NotImplementedException();
        }

        IDictionaryEnumerator IDictionary.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Remove(object key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        public void OnDeserialization(object? sender)
        {
            throw new NotImplementedException();
        }

        public struct MyEntry
        {
            public uint hashCode;

            public int next;
            public TKey key;
            public TValue value;
        }

        public sealed class KeyCollection : ICollection<TKey>, ICollection, IReadOnlyCollection<TKey>
        {
            private readonly MyLinearMap<TKey, TValue> _myLinearMap;

            public KeyCollection(MyLinearMap<TKey, TValue> myLinearMap)
            {
                if (myLinearMap == null)
                {
                    throw new ArgumentException();
                }

                _myLinearMap = myLinearMap;
            }

            public int Count => _myLinearMap.Count;

            bool ICollection<TKey>.IsReadOnly => true;

            bool ICollection.IsSynchronized => false;

            object ICollection.SyncRoot => ((ICollection)_myLinearMap).SyncRoot;
            public void CopyTo(TKey[] array, int arrayIndex)
            {
                throw new NotImplementedException();
            }
            public void CopyTo(Array array, int index)
            {
                throw new NotImplementedException();
            }

            void ICollection<TKey>.Add(TKey item) => throw new NotSupportedException();

            void ICollection<TKey>.Clear() => throw new NotSupportedException();

            bool ICollection<TKey>.Contains(TKey item) => _myLinearMap.ContainsKey(item);

            public IEnumerator<TKey> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            bool ICollection<TKey>.Remove(TKey item) => throw new NotSupportedException();

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }

            public struct Enumerator : IEnumerator<TKey>, IEnumerator
            {
                public TKey Current => throw new NotImplementedException();

                object IEnumerator.Current => throw new NotImplementedException();

                public void Dispose()
                {
                    throw new NotImplementedException();
                }

                public bool MoveNext()
                {
                    throw new NotImplementedException();
                }

                public void Reset()
                {
                    throw new NotImplementedException();
                }
            }
        }

        public sealed class ValueCollection : ICollection<TValue>, ICollection, IReadOnlyCollection<TValue>
        {
            private readonly MyLinearMap<TKey, TValue> _myLinearMap;

            public ValueCollection(MyLinearMap<TKey, TValue> myLinearMap)
            {
                if (myLinearMap == null)
                {
                    throw new ArgumentException();
                }

                _myLinearMap = myLinearMap;
            }

            bool ICollection<TValue>.IsReadOnly => true;

            public int Count => _myLinearMap.Count;

            public bool IsSynchronized => _myLinearMap.IsSynchronized;

            public object SyncRoot => _myLinearMap.SyncRoot;
            public void CopyTo(TValue[] array, int index)
            {
                int count = _myLinearMap._count;
                MyEntry[]? entries = _myLinearMap._entries;
                for (int i = 0; i < count; i++)
                {
                    if (entries![i].next >= -1) array[index++] = entries[i].value;
                }
            }

            public void CopyTo(Array array, int index)
            {
                throw new NotImplementedException();
            }

            public void Add(TValue item) => throw new NotSupportedException();

            public void Clear() => throw new NotSupportedException();

            public bool Contains(TValue item) => _myLinearMap.ContainsValue(item);


            public IEnumerator<TValue> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            public bool Remove(TValue item) => throw new NotSupportedException();

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }

            public struct Enumerator : IEnumerator<TKey>, IEnumerator
            {
                private readonly MyLinearMap<TKey, TValue> _myLinearMap;
                private int _index;
                private TKey? _currentKey;

                internal Enumerator(MyLinearMap<TKey, TValue> dictionary)
                {
                    _myLinearMap = dictionary;
                    _index = 0;
                    _currentKey = default;
                }

                public TKey Current => _currentKey!;

                object IEnumerator.Current => throw new NotImplementedException();

                public void Dispose() { }

                public bool MoveNext()
                {
                    throw new NotImplementedException();
                }

                public void Reset()
                {
                    throw new NotImplementedException();
                }
            }
        }
    }


    public static class HashHelpers
    {
        public const uint HashCollisionThreshold = 100;

        // This is the maximum prime smaller than Array.MaxLength.
        public const int MaxPrimeArrayLength = 0x7FFFFFC3;

        public const int HashPrime = 101;

        // Table of prime numbers to use as hash table sizes.
        // A typical resize algorithm would pick the smallest prime number in this array
        // that is larger than twice the previous capacity.
        // Suppose our Hashtable currently has capacity x and enough elements are added
        // such that a resize needs to occur. Resizing first computes 2x then finds the
        // first prime in the table greater than 2x, i.e. if primes are ordered
        // p_1, p_2, ..., p_i, ..., it finds p_n such that p_n-1 < 2x < p_n.
        // Doubling is important for preserving the asymptotic complexity of the
        // hashtable operations such as add.  Having a prime guarantees that double
        // hashing does not lead to infinite loops.  IE, your hash function will be
        // h1(key) + i*h2(key), 0 <= i < size.  h2 and the size must be relatively prime.
        // We prefer the low computation costs of higher prime numbers over the increased
        // memory allocation of a fixed prime number i.e. when right sizing a HashSet.
        internal static ReadOnlySpan<int> Primes => new int[]
        {
            3, 7, 11, 17, 23, 29, 37, 47, 59, 71, 89, 107, 131, 163, 197, 239, 293, 353, 431, 521, 631, 761, 919,
            1103, 1327, 1597, 1931, 2333, 2801, 3371, 4049, 4861, 5839, 7013, 8419, 10103, 12143, 14591,
            17519, 21023, 25229, 30293, 36353, 43627, 52361, 62851, 75431, 90523, 108631, 130363, 156437,
            187751, 225307, 270371, 324449, 389357, 467237, 560689, 672827, 807403, 968897, 1162687, 1395263,
            1674319, 2009191, 2411033, 2893249, 3471899, 4166287, 4999559, 5999471, 7199369
        };

        public static bool IsPrime(int candidate)
        {
            if ((candidate & 1) != 0)
            {
                int limit = (int)Math.Sqrt(candidate);
                for (int divisor = 3; divisor <= limit; divisor += 2)
                {
                    if ((candidate % divisor) == 0)
                        return false;
                }
                return true;
            }
            return candidate == 2;
        }

        public static int GetPrime(int min)
        {
            if (min < 0)
                throw new ArgumentException();

            foreach (int prime in Primes)
            {
                if (prime >= min)
                    return prime;
            }

            // Outside of our predefined table. Compute the hard way.
            for (int i = (min | 1); i < int.MaxValue; i += 2)
            {
                if (IsPrime(i) && ((i - 1) % HashPrime != 0))
                    return i;
            }
            return min;
        }

        // Returns size of hashtable to grow to.
        public static int ExpandPrime(int oldSize)
        {
            int newSize = 2 * oldSize;

            // Allow the hashtables to grow to maximum possible size (~2G elements) before encountering capacity overflow.
            // Note that this check works even when _items.Length overflowed thanks to the (uint) cast
            if ((uint)newSize > MaxPrimeArrayLength && MaxPrimeArrayLength > oldSize)
            {
                Debug.Assert(MaxPrimeArrayLength == GetPrime(MaxPrimeArrayLength), "Invalid MaxPrimeArrayLength");
                return MaxPrimeArrayLength;
            }

            return GetPrime(newSize);
        }

        /// <summary>Returns approximate reciprocal of the divisor: ceil(2**64 / divisor).</summary>
        /// <remarks>This should only be used on 64-bit.</remarks>
        public static ulong GetFastModMultiplier(uint divisor) =>
            ulong.MaxValue / divisor + 1;

        /// <summary>Performs a mod operation using the multiplier pre-computed with <see cref="GetFastModMultiplier"/>.</summary>
        /// <remarks>This should only be used on 64-bit.</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint FastMod(uint value, uint divisor, ulong multiplier)
        {
            // We use modified Daniel Lemire's fastmod algorithm (https://github.com/dotnet/runtime/pull/406),
            // which allows to avoid the long multiplication if the divisor is less than 2**31.
            Debug.Assert(divisor <= int.MaxValue);

            // This is equivalent of (uint)Math.BigMul(multiplier * value, divisor, out _). This version
            // is faster than BigMul currently because we only need the high bits.
            uint highbits = (uint)(((((multiplier * value) >> 32) + 1) * divisor) >> 32);

            Debug.Assert(highbits == value % divisor);
            return highbits;
        }
    }

}
