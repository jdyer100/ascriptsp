using nothinbutdotnetprep.utility;

namespace nothinbutdotnetprep.collections
{
    public class OrCriteria<ItemToMatch> : IMatch<ItemToMatch>
    {
        IMatch<ItemToMatch> left_side;
        IMatch<ItemToMatch> right_side;

        public OrCriteria(IMatch<ItemToMatch> left_side, IMatch<ItemToMatch> right_side)
        {
            this.left_side = left_side;
            this.right_side = right_side;
        }

        public bool matches(ItemToMatch item)
        {
            return left_side.matches(item) || right_side.matches(item);
        }
    }
}