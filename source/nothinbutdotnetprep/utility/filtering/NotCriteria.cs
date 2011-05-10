namespace nothinbutdotnetprep.utility.filtering
{
    public class NotCriteria<ItemToMatch> : IMatch<ItemToMatch>
    {
        IMatch<ItemToMatch> to_negate;

        public NotCriteria(IMatch<ItemToMatch> to_negate)
        {
            this.to_negate = to_negate;
        }

        public bool matches(ItemToMatch item)
        {
            return ! to_negate.matches(item);
        }
    }
}