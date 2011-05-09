using nothinbutdotnetprep.utility;

namespace nothinbutdotnetprep.collections
{
    public class IsPublishedBy : IMatch<Movie>
    {
        ProductionStudio studio;

        public IsPublishedBy(ProductionStudio studio)
        {
            this.studio = studio;
        }

        public bool matches(Movie item)
        {
            return item.production_studio == studio;
        }
    }
}