using System;
using System.Collections.Generic;

namespace AillieoUtils.TypeExt
{

    public static class IDictionaryExt
    {
        public static U GetOrDefault<T, U>(this IDictionary<T, U> dictionary, T key)
        {
            if (dictionary.TryGetValue(key, out U value))
            {
                return value;
            }
            return default;
        }

        public static U GetOrDefault<T, U>(this IDictionary<T, U> dictionary, T key, U defaultValue)
        {
            if (dictionary.TryGetValue(key, out U value))
            {
                return value;
            }
            return defaultValue;
        }

        public static U GetOrAdd<T, U>(this IDictionary<T, U> dictionary, T key, Func<T, U> provider)
        {
            U value = default;
            if (!dictionary.TryGetValue(key, out value))
            {
                value = provider(key);
                dictionary.Add(key, value);
            }

            return value;
        }

        private static class KeysToRemove<T>
        {
            [ThreadStatic]
            public readonly static List<T> toRemove = new List<T>();
        }
        public static int RemoveAll<T, U>(this IDictionary<T, U> dictionary, Func<T, U, bool> predicate)
        {
            List<T> toRemove = KeysToRemove<T>.toRemove;
            toRemove.Clear();
            foreach (var pair in dictionary)
            {
                if (predicate(pair.Key, pair.Value))
                {
                    toRemove.Add(pair.Key);
                }
            }

            int removeCount = toRemove.Count;
            for (int i = 0; i < removeCount; ++i)
            {
                dictionary.Remove(toRemove[i]);
            }

            toRemove.Clear();
            return removeCount;
        }
    }
}
