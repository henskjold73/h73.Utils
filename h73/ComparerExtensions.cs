using System.Collections.Generic;
using h73.Utils.Comparers;

namespace h73.Utils
{
    public static class ComparerExtensions
    {
        public static IComparer<T> Reverse<T>(this IComparer<T> original)
        {
            ReverseComparer<T> originalAsReverse = original as ReverseComparer<T>;
            if (originalAsReverse != null)
            {
                return originalAsReverse.OriginalComparer;
            }

            return new ReverseComparer<T>(original);
        }
    }
}
