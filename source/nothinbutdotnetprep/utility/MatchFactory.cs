using System.Collections.Generic;

namespace nothinbutdotnetprep.utility
{
    public class MatchFactory<ItemToCreateCriteriaFor, PropertyType> : ICreateMatchers<ItemToCreateCriteriaFor, PropertyType>
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