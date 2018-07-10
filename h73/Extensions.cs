using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace h73.Utils
{
    public static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            var items = sequence.ToList();
            if (items.IsNull() || action.IsNull())
            {
                return;
            }

            foreach (T item in items)
            {
                action(item);
            }
        }

        public static bool IsNull<T>(this T obj)
        {
            if (obj is string str)
            {
                return string.IsNullOrEmpty(str);
            }

            if (obj is int integer)
            {
                return integer == 0;
            }

            return obj == null;
        }

        public static bool IsNotNull<T>(this T obj)
        {
            return !obj.IsNull();
        }

        /// <summary>
        /// Throws an ArgumentNullException if the given data item is null.
        /// </summary>
        /// <typeparam name="T">Type of T</typeparam>
        /// <param name="data">The item to check for nullity.</param>
        /// <param name="name">The <paramref name="name"/> to use when throwing an exception, if necessary</param>
        public static void ThrowIfNull<T>(this T data, string name)
            where T : class
        {
            if (data == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        /// <summary>
        /// Throws an ArgumentNullException if the given data item is null.
        /// No parameter name is specified.
        /// </summary>
        /// <typeparam name="T">Type of T</typeparam>
        /// <param name="data">The item to check for nullity.</param>
        public static void ThrowIfNull<T>(this T data)
            where T : class
        {
            if (data == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
