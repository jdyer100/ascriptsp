namespace nothinbutdotnetprep.utility.filtering
{
    public class PropertyCriteria<ItemToFilter, PropertyType> : IMatch<ItemToFilter>
    {
        PropertyAccessor<ItemToFilter, PropertyType> accessor;
        IMatch<PropertyType> property_condition;

        public PropertyCriteria(PropertyAccessor<ItemToFilter, PropertyType> accessor,
                                IMatch<PropertyType> property_condition)
        {
            this.accessor = accessor;
            this.property_condition = property_condition;
        }

        public bool matches(ItemToFilter item)
        {
            return property_condition.matches(accessor(item));
        }
    }
}