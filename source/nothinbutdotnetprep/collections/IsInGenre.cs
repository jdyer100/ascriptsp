using nothinbutdotnetprep.utility;

namespace nothinbutdotnetprep.collections
{
    public class IsInGenre : IMatch<Movie>
    {
        Genre genre;

        public IsInGenre(Genre genre)
        {
            this.genre = genre;
        }

        public bool matches(Movie item)
        {
            return item.genre == genre;
        }
    }
}