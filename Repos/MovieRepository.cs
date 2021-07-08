using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos
{
    public class MovieRepository
    {
        private readonly List<Movie> _movies = new List<Movie>();
        private int _idCounter = default;

        public bool Create(Movie movie)
        {
            if (movie is null)
            {
                return false;
            }

            movie.Id = ++_idCounter;
            _movies.Add(movie);

            return true;
        }

        public List<Movie> GetAll()
        {
            return _movies;
        }

        public Movie GetById(int id)
        {
            foreach (var movie in _movies)
            {
                if (movie.Id == id)
                {
                    return movie;
                }
            }

            return null;
        }

        public bool UpdateMovie(int id, Movie movie)
        {
            Movie existingMovie = this.GetById(id);

            if (existingMovie is null)
            {
                return false;
            }

            existingMovie.ReleaseDate = movie.ReleaseDate;
            existingMovie.Title = movie.Title;

            return true;
        }

        public bool Delete(int id)
        {
            Movie existingMovie = this.GetById(id);

            if (existingMovie is null)
            {
                return false;
            }

            int initialCount = _movies.Count;
            _movies.Remove(existingMovie);

            return initialCount > _movies.Count;
        }
    }
}
