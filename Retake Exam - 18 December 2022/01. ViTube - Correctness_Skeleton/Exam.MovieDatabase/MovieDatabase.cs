namespace Exam.MovieDatabase
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class MovieDatabase : IMovieDatabase
    {
        private List<Actor> actors;
        private List<Movie> movies;

        public MovieDatabase()
        {
            this.actors = new List<Actor>();
            this.movies = new List<Movie>();
        }

        public void AddActor(Actor actor)
        {
            this.actors.Add(actor);
        }

        public void AddMovie(Actor actor, Movie movie)
        {
            if (!this.actors.Contains(actor))
            {
                throw new ArgumentException();
            }

            actor.Movies.Add(movie);
            this.movies.Add(movie);
        }

        public bool Contains(Actor actor)
        {
            return this.actors.Contains(actor);
        }

        public bool Contains(Movie movie)
        {
            return this.movies.Contains(movie);
        }

        public IEnumerable<Actor> GetActorsOrderedByMaxMovieBudgetThenByMoviesCount()
        {
            Dictionary<Actor, double> actorsAndMovie = new Dictionary<Actor, double>();

            foreach (var actor in this.actors)
            {
                double maxBudgetMovie = actor.Movies.Max(m => m.Budget);
                actorsAndMovie.Add(actor, maxBudgetMovie);
            }

            return actorsAndMovie.OrderByDescending(x => x.Value)
                                 .ThenByDescending(x => x.Key.Movies.Count)
                                 .Select(x => x.Key);
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return this.movies;
        }

        public IEnumerable<Movie> GetMoviesInRangeOfBudget(double lower, double upper)
        {
            return this.movies.Where(m => m.Budget >= lower && m.Budget <= upper)
                              .OrderByDescending(m => m.Rating);
        }

        public IEnumerable<Movie> GetMoviesOrderedByBudgetThenByRating()
        {
            return this.movies.OrderByDescending(m => m.Budget).ThenByDescending(m => m.Rating);
        }

        public IEnumerable<Actor> GetNewbieActors()
        {
            return this.actors.Where(a => !a.Movies.Any());
        }
    }
}
