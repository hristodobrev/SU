namespace Exercise_02.Func
{
    using System;
    using System.Collections.Generic;

    public static class Extensions
    {
        public static List<T> TakeWhile<T>(this IEnumerable<T> collection, Func<T, bool> function)
        {
            List<T> newCollection = new List<T>();

            foreach (T element in collection)
            {
                if (function(element))
                {
                    newCollection.Add(element);
                }
                else
                {
                    return newCollection;
                }
            }

            return newCollection;
        }
    }
}
