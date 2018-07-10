using System;
using System.Collections.Generic;

namespace h73.Utils.Range
{
    public class Range<T>
    {
        public Range(T start, T end)
            : this(start, end, Comparer<T>.Default, true, true)
        {
        }

        public Range(T start, T end, IComparer<T> comparer)
            : this(start, end, comparer, true, true)
        {
        }

        public Range(T start, T end, IComparer<T> comparer, bool includeStart, bool includeEnd)
        {
            Start = start;
            End = end;
            Comparer = comparer;
            IncludeStart = includeStart;
            IncludeEnd = includeEnd;
        }

        public T Start { get; }

        public T End { get; }

        public IComparer<T> Comparer { get; }

        public bool IncludeStart { get; }

        public bool IncludeEnd { get; }

        public RangeIterator<T> FromStart(Func<T, T> step)
        {
            return new RangeIterator<T>(this, step);
        }

        public RangeIterator<T> FromEnd(Func<T, T> step)
        {
            return new RangeIterator<T>(this, step, false);
        }

        public RangeIterator<T> Step(Func<T, T> step)
        {
            step.ThrowIfNull(nameof(step));
            var ascending = Comparer.Compare(Start, step(Start)) < 0;
            return ascending ? FromStart(step) : FromEnd(step);
        }
    }
}
