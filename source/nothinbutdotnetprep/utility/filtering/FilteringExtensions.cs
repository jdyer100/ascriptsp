using System;
using nothinbutdotnetprep.utility.ranges;

namespace nothinbutdotnetprep.utility.filtering
{
    public static class FilteringExtensions
    {
        public static IMatch<ItemToCreateCriteriaFor> equal_to<ItemToCreateCriteriaFor,PropertyType>(this IProvideAccessToFilteringBehaviours<ItemToCreateCriteriaFor,PropertyType> extension_point,PropertyType value)
        {
            return equal_to_any<ItemToCreateCriteriaFor,PropertyType>(extension_point,value);
        }

        public static IMatch<ItemToCreateCriteriaFor> equal_to_any<ItemToCreateCriteriaFor,PropertyType>(this IProvideAccessToFilteringBehaviours<ItemToCreateCriteriaFor,PropertyType> extension_point,params PropertyType[] potential_values)
        {
            return create_matcher_for<ItemToCreateCriteriaFor,PropertyType>(extension_point,new IsEqualToAny<PropertyType>(potential_values));
        }

        public static IMatch<ItemToCreateCriteriaFor> greater_than_year<ItemToCreateCriteriaFor>(this IProvideAccessToFilteringBehaviours<ItemToCreateCriteriaFor,DateTime> extension_point,int value) 
        {
            return create_matcher_for(extension_point,new IsGreaterThanYear(value));
        }

        public static IMatch<ItemToCreateCriteriaFor> greater_than<ItemToCreateCriteriaFor,PropertyType>(this IProvideAccessToFilteringBehaviours<ItemToCreateCriteriaFor,PropertyType> extension_point,PropertyType value) where PropertyType : IComparable<PropertyType>
        {
            return create_matcher_for(extension_point,new IsGreaterThan<PropertyType>(value));
        }

        public static IMatch<ItemToCreateCriteriaFor> between<ItemToCreateCriteriaFor,PropertyType>(this IProvideAccessToFilteringBehaviours<ItemToCreateCriteriaFor,PropertyType> extension_point,PropertyType start, PropertyType end) where PropertyType : IComparable<PropertyType>
        {
            return create_matcher_for(extension_point,new FallsInRange<PropertyType>(new InclusiveRange<PropertyType>(start,end)));
        }

        public static IMatch<ItemToCreateCriteriaFor> create_matcher_for<ItemToCreateCriteriaFor,PropertyType>(this IProvideAccessToFilteringBehaviours<ItemToCreateCriteriaFor,PropertyType> extension_point,IMatch<PropertyType> discrete_matcher)
        {
            return extension_point.create_using(discrete_matcher);
        }

    }
}