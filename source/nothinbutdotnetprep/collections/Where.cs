namespace nothinbutdotnetprep.collections
{
    public delegate PropertyType PropertyAccessor<ItemToTarget, PropertyType>(ItemToTarget item);


    public class Where<ItemToMatch>
    {
        public static MatchFactory has_a<PropertyType>(
            PropertyAccessor<ItemToMatch, PropertyType> accessor)
        {
            // return accessor;
            return new MatchFactory();
        }
    }
}