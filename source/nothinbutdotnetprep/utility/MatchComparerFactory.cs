using System;

namespace nothinbutdotnetprep.utility
{
    public class MatchComparerFactory<ItemToCreateCriteriaFor, PropertyType>
        : ICreateMatchers<ItemToCreateCriteriaFor,PropertyType> where PropertyType : IComparable<PropertyType>
    {
        PropertyAccessor<ItemToCreateCriteriaFor, PropertyType> accessor;
        ICreateMatchers<ItemToCreateCriteriaFor, PropertyType> original;

        public MatchComparerFactory(PropertyAccessor<ItemToCreateCriteriaFor, PropertyType> accessor, ICreateMatchers<ItemToCreateCriteriaFor, PropertyType> original)
        {
            this.accessor = accessor;
            this.original = original;
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

        public IMatch<ItemToCreateCriteriaFor> equal_to(PropertyType value)
        {
            return original.equal_to(value);
        }

        public IMatch<ItemToCreateCriteriaFor> equal_to_any(params PropertyType[] potential_values)
        {
            return original.equal_to_any(potential_values);
        }

        public IMatch<ItemToCreateCriteriaFor> not_equal_to(PropertyType value)
        {
            return original.not_equal_to(value);
        }
    }
}