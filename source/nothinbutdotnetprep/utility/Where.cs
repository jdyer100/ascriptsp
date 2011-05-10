using System;
namespace nothinbutdotnetprep.utility
{
    public class Where<ItemToMatch>
    {
        public static MatchComparerFactory<ItemToMatch, TPropertyType> has_an<TPropertyType>(
     PropertyAccessor<ItemToMatch, TPropertyType> accessor) where TPropertyType : IComparable<TPropertyType>
        {
            return new MatchComparerFactory<ItemToMatch, TPropertyType>(accessor,has_a(accessor));
        }

        public static MatchFactory<ItemToMatch, PropertyType> has_a<PropertyType>(
            PropertyAccessor<ItemToMatch, PropertyType> accessor) 
        {
            return new MatchFactory<ItemToMatch, PropertyType>(accessor);
        }
    }
}