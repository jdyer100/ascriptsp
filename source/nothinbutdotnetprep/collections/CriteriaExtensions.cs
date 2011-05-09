using nothinbutdotnetprep.utility;

namespace nothinbutdotnetprep.collections
{
    public static class CriteriaExtensions
    {
        public static IMatch<ItemToMatch> or<ItemToMatch>(this IMatch<ItemToMatch> left_side,
                                                          IMatch<ItemToMatch> right_side)
        {
            return new OrCriteria<ItemToMatch>(left_side, right_side);
        }
    }
}