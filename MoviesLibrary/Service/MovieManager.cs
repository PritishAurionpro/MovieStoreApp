using MovieApp3._0.Exceptions;
//using MovieApp3._0.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesLibrary
{
    public class MovieManager
    {
        private const int MaxMovies = 5;
        public static List<Movie> movies = new List<Movie>();
        static string filePath = @"D:\Projects\Simple Movies App\MoviesApp4.0\MoviesData";
        public MovieManager()
        {
            movies = DataSerializer.BinaryDeserialize(filePath);
        }
        public static void AddMovie(int movieId, string name, string genre, int year)
        {
            if (movies.Count < MaxMovies)
            {
                movies.Add(new Movie()
                {
                    MovieId = movieId,
                    Name = name,
                    Genre = genre,
                    Year = year
                });
                DataSerializer.BinarySerializer(filePath, movies);
            }
            else
            {
                throw new MaxLimitReachedException("Max Movie limit reached"); //exception
            }
        }
        public static string DisplayMovies()
        {
            foreach (var movie in movies)
            {
                if (movie != null)
                {
                    return $"ID: {movie.MovieId}, Name: {movie.Name}, Genre: {movie.Genre}, Year: {movie.Year}";
                }
            }
            throw new NoMovieFoundException("No movies found");
        }
        public static void ClearAllMovies()
        {
            if(movies.Count == 0)
            {
                throw new NoMovieFoundException("No movies found");
            }
            movies.Clear();
            DataSerializer.BinarySerializer(filePath, movies);
        }
        public static bool RemoveMovieByName(string name)
        {
            List<Movie> existingMovies = DataSerializer.BinaryDeserialize(filePath);

            bool found = false;
            foreach (Movie movie in existingMovies)
            {
                if (movie.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    existingMovies.Remove(movie);
                    found = true;
                    break;
                }
            }
            if (found)
            {
                DataSerializer.BinarySerializer(filePath, existingMovies);
                movies.Clear();
                movies.AddRange(existingMovies);
                return found;
            }
            else
            {
                return found;
            }
        }
        public static List<Movie> ShowMoviesByYear(int yearSorting)
        {
            var moviesByYear = movies.FindAll(movie => movie.Year == yearSorting);
            if (movies.Count == 0)
            {
                throw new NoMovieFoundException("No movie found");
            }
            if (moviesByYear == null)
            {
                throw new NoMovieFoundException("No movie found in that year");
            }
            return moviesByYear;
        }
        public static int CountMovies()
        {
            return movies.Count;
        }
    }
}
