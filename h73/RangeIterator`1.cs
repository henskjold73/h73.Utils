using System;
using System.Collections;
using System.Collections.Generic;

namespace h73.Utils
{
    /// <summary>
    /// Iterates over a range. Despite its name, this implements IEnumerable{T} rather than
    /// IEnumerator{T} - it just sounds better, frankly.
    /// </summary>
    /// <typeparam name="T">Type of T</typeparam>
    public class RangeIterator<T> : IEnumerable<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RangeIterator{T}"/> class.
        /// Creates an ascending iterator over the given range with the given step function
        /// </summary>
        /// <param name="range">Range object to iterate</param>
        /// <param name="step">Step function</param>
        public RangeIterator(Range<T> range, Func<T, T> step)
            : this(range, step, true)
        {
            Range = range;
            Step = step;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RangeIterator{T}"/> class.
        /// Creates an iterator over the given range with the given step function,
        /// with the specified direction.
        /// </summary>
        /// <param name="range">Range object to iterate</param>
        /// <param name="step">Step function</param>
        /// <param name="ascending">Direction</param>
        public RangeIterator(Range<T> range, Func<T, T> step, bool ascending)
        {
            step.ThrowIfNull("step");

            if ((ascending && range.Comparer.Compare(range.Start, step(range.Start)) >= 0) ||
                (!ascending && range.Comparer.Compare(range.End, step(range.End)) <= 0))
            {
                throw new ArgumentException("step does nothing, or progresses the wrong way");
            }

            Ascending = ascending;
            Range = range;
            Step = step;
        }

        public Range<T> Range { get; }

        public Func<T, T> Step { get; }

        public bool Ascending { get; }

        /// <summary>
        /// Returns an IEnumerator{T} running over the range.
        /// </summary>
        /// <returns>IEnumerator{T}</returns>
        public IEnumerator<T> GetEnumerator()
        {
            var includesStart = Ascending ? Range.IncludeStart : Range.IncludeEnd;
            var includesEnd = Ascending ? Range.IncludeEnd : Range.IncludeStart;
            var start = Ascending ? Range.Start : Range.End;
            var end = Ascending ? Range.End : Range.Start;
            var comparer = Ascending ? Range.Comparer : Range.Comparer.Reverse();

            var value = start;

            if (includesStart)
            {
                if (includesEnd || comparer.Compare(value, end) < 0)
                {
                    yield return value;
                }
            }

            value = Step(value);

            while (comparer.Compare(value, end) < 0)
            {
                yield return value;
                value = Step(value);
            }

            if (includesEnd && comparer.Compare(value, end) == 0)
            {
                yield return value;
            }
        }

        /// <summary>
        /// Returns an IEnumerator running over the range.
        /// </summary>
        /// <returns>IEnumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
