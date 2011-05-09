namespace nothinbutdotnetprep.utility
{
    public interface IMatch<ItemToMatch>
    {
        bool matches(ItemToMatch item);
    }
}