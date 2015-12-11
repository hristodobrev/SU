namespace Exercise_03.Action
{
    using System;
    using System.Collections.Generic;

    public static class Extensions
    {
        public static void ForEach<T>(IEnumerable<T> collection, Action<T> action)
        {
            foreach (T element in collection)
            {
                action(element);
            }
        }
    }
}
