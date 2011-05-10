using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public class IsGreaterThanYear : IMatch<DateTime>
    {
        int year;

        public IsGreaterThanYear(int year)
        {
            this.year = year;
        }

        public bool matches(DateTime item)
        {
            return item.Year > year;
        }
    }
}