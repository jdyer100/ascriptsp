namespace nothinbutdotnetprep.utility.filtering
{
    public interface IMatch<ItemToMatch>
    {
        bool matches(ItemToMatch item);
    }
}