namespace h73.Utils
{
    public static class RangeHelpers
    {
        public static Range<T> To<T>(this T start, T end)
        {
            return new Range<T>(start, end);
        }

        public static RangeIterator<char> StepChar(this Range<char> range, int step)
        {
            return range.Step(c => (char)(c + step));
        }
    }
}
