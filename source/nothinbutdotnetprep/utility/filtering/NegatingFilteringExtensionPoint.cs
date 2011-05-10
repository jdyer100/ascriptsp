namespace nothinbutdotnetprep.utility.filtering
{
    public class NegatingFilteringExtensionPoint<ItemToFilter, PropertyType> :
        IProvideAccessToFilteringBehaviours<ItemToFilter, PropertyType>
    {
        IProvideAccessToFilteringBehaviours<ItemToFilter, PropertyType> original;

        public NegatingFilteringExtensionPoint(IProvideAccessToFilteringBehaviours<ItemToFilter, PropertyType> original)
        {
            this.original = original;
        }

        public IMatch<ItemToFilter> create_using(IMatch<PropertyType> matcher)
        {
            return new NotCriteria<ItemToFilter>(original.create_using(matcher));
        }
    }
}