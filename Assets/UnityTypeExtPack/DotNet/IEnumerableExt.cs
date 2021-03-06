using System;
using System.Collections.Generic;
using System.Linq;

namespace AillieoUtils.TypeExt
{
    public static class IEnumerableExt
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T element in source)
            {
                action(element);
            }
        }

        private static class HashSetForUniqueTest<T>
        {
            [ThreadStatic]
            public static readonly HashSet<T> hashSet = new HashSet<T>();
        }

        public static bool IsUnique<T>(this IEnumerable<T> source)
        {
            HashSet<T> hashSet = HashSetForUniqueTest<T>.hashSet;
            bool unique = source.All(t => hashSet.Add(t));
            hashSet.Clear();
            return unique;
        }

        public static IEnumerable<T> ReverseFast<T>(this IEnumerable<T> source)
        {
            if (source is IList<T> list && list.Count > 0)
            {
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    yield return list[i];
                }
            }
            else if (source is LinkedList<T> linked && linked.Count > 0)
            {
                LinkedListNode<T> node = linked.Last;
                while(node != null)
                {
                    yield return node.Value;
                    node = node.Previous;
                }
            }
            else
            {
                foreach (T item in source.Reverse())
                {
                    yield return item;
                }
            }
        }
    }
}
