using System;

namespace nothinbutdotnetprep.utility
{
    public class MatchFactory<ItemToCreateCriteriaFor, PropertyType> :
        ICreateMatchers<ItemToCreateCriteriaFor, PropertyType>
    {
        PropertyAccessor<ItemToCreateCriteriaFor, PropertyType> accessor;

        public MatchFactory(PropertyAccessor<ItemToCreateCriteriaFor, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public object not
        {
            get { throw new NotImplementedException(); }
        }

        public IMatch<ItemToCreateCriteriaFor> equal_to(PropertyType value)
        {
            return equal_to_any(value);
        }

        public IMatch<ItemToCreateCriteriaFor> equal_to_any(params PropertyType[] potential_values)
        {
            return create_matcher_for(new IsEqualToAny<PropertyType>(potential_values));
        }

        public IMatch<ItemToCreateCriteriaFor> not_equal_to(PropertyType value)
        {
            return new NotCriteria<ItemToCreateCriteriaFor>(equal_to(value));
        }

        public IMatch<ItemToCreateCriteriaFor> create_matcher_for(IMatch<PropertyType> discrete_matcher)
        {
            return new PropertyCriteria<ItemToCreateCriteriaFor, PropertyType>(accessor, discrete_matcher);
        }
    }
}