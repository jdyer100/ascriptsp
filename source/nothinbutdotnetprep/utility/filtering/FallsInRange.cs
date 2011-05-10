using System;
using nothinbutdotnetprep.utility.ranges;

namespace nothinbutdotnetprep.utility.filtering
{
    public class FallsInRange<T> : IMatch<T> where T : IComparable<T>
    {
        IContainARangeOfValues<T> range;

        public FallsInRange(IContainARangeOfValues<T> range)
        {
            this.range = range;
        }

        public bool matches(T item)
        {
            return range.contains(item);
        }
    }
}