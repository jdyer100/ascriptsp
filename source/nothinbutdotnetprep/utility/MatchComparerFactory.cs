using System;
using nothinbutdotnetprep.utility.ranges;

namespace nothinbutdotnetprep.utility
{
    public class MatchComparerFactory<ItemToCreateCriteriaFor, PropertyType>
        : ICreateMatchers<ItemToCreateCriteriaFor,PropertyType> where PropertyType : IComparable<PropertyType>
    {
        ICreateMatchers<ItemToCreateCriteriaFor, PropertyType> original;

        public MatchComparerFactory(ICreateMatchers<ItemToCreateCriteriaFor, PropertyType> original)
        {
            this.original = original;
        }

        public IMatch<ItemToCreateCriteriaFor> greater_than(PropertyType value)
        {
            return create_matcher_for(new IsGreaterThan<PropertyType>(value));
        }

        public IMatch<ItemToCreateCriteriaFor> between(PropertyType start, PropertyType end)
        {
            return create_matcher_for(new FallsInRange<PropertyType>(new InclusiveRange<PropertyType>(start,end)));
        }

        public IMatch<ItemToCreateCriteriaFor> equal_to(PropertyType value)
        {
            return original.equal_to(value);
        }

        public IMatch<ItemToCreateCriteriaFor> create_matcher_for(IMatch<PropertyType> discrete_matcher)
        {
            return original.create_matcher_for(discrete_matcher);
        }

        public IMatch<ItemToCreateCriteriaFor> equal_to_any(params PropertyType[] potential_values)
        {
            return original.equal_to_any(potential_values);
        }


    }
}