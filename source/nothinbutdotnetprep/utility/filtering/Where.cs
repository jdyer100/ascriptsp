namespace nothinbutdotnetprep.utility.filtering
{
    public class Where<ItemToMatch>
    {
        public static BasicFilteringExtensionPoint<ItemToMatch, PropertyType> has_a<PropertyType>(
            PropertyAccessor<ItemToMatch, PropertyType> accessor)
        {
            return new BasicFilteringExtensionPoint<ItemToMatch, PropertyType>(accessor);
        }
    }
}