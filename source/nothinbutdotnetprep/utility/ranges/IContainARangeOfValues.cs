using System;

namespace nothinbutdotnetprep.utility.ranges
{
    public interface IContainARangeOfValues<T> where T: IComparable<T>
    {
        bool contains(T item);
    }
}