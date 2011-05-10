using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public interface IProvideAccessToFilteringBehaviours<ItemToFilter, PropertyType>
    {
        IMatch<ItemToFilter> create_using(IMatch<PropertyType> matcher);

    }

    public class BasicFilteringExtensionPoint<ItemToFilter, PropertyType> : IProvideAccessToFilteringBehaviours<ItemToFilter, PropertyType>
    {
        PropertyAccessor<ItemToFilter, PropertyType> accessor;

        public BasicFilteringExtensionPoint(PropertyAccessor<ItemToFilter, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public IProvideAccessToFilteringBehaviours<ItemToFilter, PropertyType> not
        {
            get
            {
                return new NegatingFilteringExtensionPoint<ItemToFilter, PropertyType>(this);
            }
        }

        public IMatch<ItemToFilter> create_using(IMatch<PropertyType> matcher)
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(accessor,matcher);
        }
    }
}