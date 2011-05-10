namespace nothinbutdotnetprep.utility
{
    public interface ICreateMatchers<ItemToCreateCriteriaFor, PropertyType>
    {
        IMatch<ItemToCreateCriteriaFor> equal_to(PropertyType value);
        IMatch<ItemToCreateCriteriaFor> equal_to_any(params PropertyType[] potential_values);
        IMatch<ItemToCreateCriteriaFor> not_equal_to(PropertyType value);
    }
}