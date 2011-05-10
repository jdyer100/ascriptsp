using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility
{
    public class MatchComparerFactory<ItemToCreateCriteriaFor, PropertyType> where PropertyType : IComparable<PropertyType>
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


     }

    public class MatchFactory<ItemToCreateCriteriaFor, PropertyType>
    {
        PropertyAccessor<ItemToCreateCriteriaFor, PropertyType> accessor;

        public MatchFactory(PropertyAccessor<ItemToCreateCriteriaFor, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public IMatch<ItemToCreateCriteriaFor> equal_to(PropertyType value)
        {
            return equal_to_any(value);
        }

        public IMatch<ItemToCreateCriteriaFor> equal_to_any(params PropertyType[] potential_values)
        {
            return
                new AnonymousCriteria<ItemToCreateCriteriaFor>(
                    x => new List<PropertyType>(potential_values).Contains(accessor(x)));
        }

        public IMatch<ItemToCreateCriteriaFor> not_equal_to(PropertyType value)
        {
            return new NotCriteria<ItemToCreateCriteriaFor>(equal_to(value));
        }
    }
}