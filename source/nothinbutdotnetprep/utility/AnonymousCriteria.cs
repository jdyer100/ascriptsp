namespace nothinbutdotnetprep.utility
{
    public class AnonymousCriteria<ItemToMatch> : IMatch<ItemToMatch>
    {
        Condition<ItemToMatch> condition;

        public AnonymousCriteria(Condition<ItemToMatch> condition)
        {
            this.condition = condition;
        }

        public bool matches(ItemToMatch item)
        {
            return condition(item);
        }

    }
}