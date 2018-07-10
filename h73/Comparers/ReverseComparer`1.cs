using System.Collections.Generic;

namespace h73.Utils.Comparers
{
    public sealed class ReverseComparer<T> : IComparer<T>
    {
        public ReverseComparer(IComparer<T> original)
        {
            original.ThrowIfNull(nameof(original));
            OriginalComparer = original;
        }

        public IComparer<T> OriginalComparer { get; }

        public int Compare(T x, T y)
        {
            return OriginalComparer.Compare(y, x);
        }
    }
}
