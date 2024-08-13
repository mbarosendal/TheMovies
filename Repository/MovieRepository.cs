using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TheMovies.Models;

namespace TheMovies.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly List<Movie> _movies;

        public MovieRepository()
        {
            _movies = new List<Movie>
            {
                new Movie { Title = "Titanic", Duration = 120, Genre = "Drama" },
                new Movie { Title = "Inception", Duration = 148, Genre = "Sci-Fi" }
            };
        }

        public void AddMovie(Movie movie)
        {
            _movies.Add(movie);
        }

        public bool CanAddMovie()
        {
            // canAdd logic
            return true;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _movies;
        }
    }
}
