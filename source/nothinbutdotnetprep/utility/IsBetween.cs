using System;

namespace nothinbutdotnetprep.utility
{
    public class IsBetween<T> : IMatch<T> where T : IComparable<T>
    {
        T start;
        T end;

        public IsBetween(T start, T end)
        {
            this.start = start;
            this.end = end;
        }

        public bool matches(T item)
        {
            return item.CompareTo(start) >= 0 && item.CompareTo(end) <= 0;
        }
    }
}