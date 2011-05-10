using System;

namespace nothinbutdotnetprep.utility
{
    public class MatchFactory<ItemToCreateCriteriaFor, PropertyType> :
        ICreateMatchers<ItemToCreateCriteriaFor, PropertyType>
    {
        PropertyAccessor<ItemToCreateCriteriaFor, PropertyType> accessor;
        private bool flipSense = false;

        public MatchFactory(PropertyAccessor<ItemToCreateCriteriaFor, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public MatchFactory<ItemToCreateCriteriaFor, PropertyType> not
        {
            get 
            { 
                flipSense = ! flipSense;
                return this;
            }
        }

        public IMatch<ItemToCreateCriteriaFor> equal_to(PropertyType value)
        {
            IMatch<ItemToCreateCriteriaFor> retval;
            if (flipSense)
            {
                flipSense = !flipSense;
                retval = not_equal_to(value);
                flipSense = !flipSense;
            }
            else
             retval = equal_to_any(value);
            return retval;
        }

        public IMatch<ItemToCreateCriteriaFor> equal_to_any(params PropertyType[] potential_values)
        {
            return create_matcher_for(new IsEqualToAny<PropertyType>(potential_values));
        }

        public IMatch<ItemToCreateCriteriaFor> not_equal_to(PropertyType value)
        {
            IMatch<ItemToCreateCriteriaFor> retval;
            if (flipSense)
            {
                flipSense = !flipSense;
                retval = equal_to(value);
                flipSense = !flipSense;
            }
            else
                retval = new NotCriteria<ItemToCreateCriteriaFor>(equal_to(value));
            return retval;
        }

        public IMatch<ItemToCreateCriteriaFor> create_matcher_for(IMatch<PropertyType> discrete_matcher)
        {
            return new PropertyCriteria<ItemToCreateCriteriaFor, PropertyType>(accessor, discrete_matcher);
        }
    }
}