using System;
using System.Collections.Generic;
using nothinbutdotnetprep.utility;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        IList<Movie> movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            this.movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            return movies.one_at_a_time();
        }


        public void add(Movie movie)
        {
            if (already_contains(movie)) return;
            movies.Add(movie);
        }

        bool already_contains(Movie movie)
        {
            return movies.Contains(movie);
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            IList<Movie> pixarMovies = new List<Movie>();
            foreach (Movie movie in movies)
            {
                if (movie.production_studio==ProductionStudio.Pixar)
                {
                    pixarMovies.Add(movie);
                }
            }

            return pixarMovies;
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            IList<Movie> afterMovies = new List<Movie>();
            foreach (Movie movie in movies)
            {
                if (movie.date_published.Year > year)
                {
                    afterMovies.Add(movie);
                }
            }

            return afterMovies;
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            IList<Movie> betweenMovies = new List<Movie>();
            foreach (Movie movie in movies)
            {
                if (movie.date_published.Year >= startingYear && movie.date_published.Year<=endingYear)
                {
                    betweenMovies.Add(movie);
                }
            }

            return betweenMovies;
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            IList<Movie> pixarDisneyMovies = new List<Movie>();
            foreach (Movie movie in movies)
            {
                if (movie.production_studio == ProductionStudio.Pixar || movie.production_studio==ProductionStudio.Disney)
                {
                    pixarDisneyMovies.Add(movie);
                }
            }

            return pixarDisneyMovies;
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            IList<Movie> kidMovies = new List<Movie>();
            foreach (Movie movie in movies)
            {
                if (movie.genre==Genre.kids)
                {
                    kidMovies.Add(movie);
                }
            }

            return kidMovies;
        }

        public IEnumerable<Movie> all_action_movies()
        {
            IList<Movie> actionMovies = new List<Movie>();
            foreach (Movie movie in movies)
            {
                if (movie.genre == Genre.action)
                {
                    actionMovies.Add(movie);
                }
            }

            return actionMovies;
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            IList<Movie> notpixarMovies = new List<Movie>();
            foreach (Movie movie in movies)
            {
                if (movie.production_studio != ProductionStudio.Pixar)
                {
                    notpixarMovies.Add(movie);
                }
            }

            return notpixarMovies;
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            throw new NotImplementedException();
        }
    }
}