namespace nothinbutdotnetprep.utility
{
    public delegate PropertyType PropertyAccessor<ItemToTarget, PropertyType>(ItemToTarget item);


    public class Where<ItemToMatch>
    {
        public static something has_a<PropertyType>(
            PropertyAccessor<ItemToMatch, PropertyType> accessor)
        {
            return accessor;
        }
    }
}