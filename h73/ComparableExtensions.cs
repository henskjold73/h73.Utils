using System;
using System.Collections;

namespace h73.Utils
{
    public static class ComparableExtensions
    {
        public static bool In<T>(this T source, params T[] list)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return ((IList)list).Contains(source);
        }

        public static bool Between<T>(this T actual, T lower, T upper)
            where T : IComparable<T>
        {
            return actual.CompareTo(lower) >= 0 && actual.CompareTo(upper) < 0;
        }
    }
}
