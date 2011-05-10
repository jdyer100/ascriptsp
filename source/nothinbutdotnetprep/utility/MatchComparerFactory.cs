using System;

namespace nothinbutdotnetprep.utility
{
    public class MatchComparerFactory<ItemToCreateCriteriaFor, PropertyType>
        where PropertyType : IComparable<PropertyType>
    {
        PropertyAccessor<ItemToCreateCriteriaFor, PropertyType> accessor;

        public MatchComparerFactory(PropertyAccessor<ItemToCreateCriteriaFor, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public IMatch<ItemToCreateCriteriaFor> greater_than(PropertyType value)
        {
            return new AnonymousCriteria<ItemToCreateCriteriaFor>(x => accessor(x).CompareTo(value) > 0);
        }

        public IMatch<ItemToCreateCriteriaFor> less_than(PropertyType value)
        {
            return new AnonymousCriteria<ItemToCreateCriteriaFor>(x => accessor(x).CompareTo(value) < 0);
        }

        public IMatch<ItemToCreateCriteriaFor> between(PropertyType start, PropertyType end)
        {
            return new AnonymousCriteria<ItemToCreateCriteriaFor>(x =>
            {
                var value = accessor(x);
                return value.CompareTo(start) >= 0 && value.CompareTo(end) <= 0;
            });
        }
    }
}