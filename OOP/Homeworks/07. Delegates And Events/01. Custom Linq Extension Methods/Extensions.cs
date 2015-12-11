namespace _01.Custom_Linq_Extension_Methods
{
    using System;
    using System.Collections.Generic;

    public static class Extensions
    {
        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            List<T> newCollection = new List<T>();

            foreach (T element in collection)
            {
                if (!predicate(element))
                {
                    newCollection.Add(element);
                }
            }

            return newCollection;
        }

        public static TSelector Max<TSource, TSelector>(this IEnumerable<TSource> collection, Func<TSource, TSelector> function)
            where TSelector : IComparable
        {
            TSelector max = default(TSelector);

            foreach (var element in collection)
            {
                if (function(element).CompareTo(max) > 0)
                {
                    max = function(element);
                }
            }

            return max;
        }
    }
}
