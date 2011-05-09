namespace nothinbutdotnetprep.utility
{
    public delegate PropertyType PropertyAccessor<ItemToTarget, PropertyType>(ItemToTarget item);

    public static class FilteringExtensions
    {
        public static IMatch<ItemToMatch> equal_to<ItemToMatch, PropertyType>(
            this PropertyAccessor<ItemToMatch, PropertyType> accessor, PropertyType value_to_equal)
        {
            return new AnonymousCriteria<ItemToMatch>(x => accessor(x).Equals(value_to_equal));
        }
    }

    public class Where<ItemToMatch>
    {
        public static PropertyAccessor<ItemToMatch, PropertyType> has_a<PropertyType>(
            PropertyAccessor<ItemToMatch, PropertyType> accessor)
        {
            return accessor;
        }
    }
}