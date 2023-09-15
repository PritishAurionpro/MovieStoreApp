//using MovieApp3._0.Model;
//using MovieApp3._0.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MoviesLibrary;

namespace MoviesApp4._0
{
    internal class MovieController
    {
        public MovieController() 
        {
            MainMenu();
        }
        private static void MainMenu()
        {

            while (true)
            {
                new MovieManager();
                Console.WriteLine("========== Menu ==========");
                Console.WriteLine($"Movie Store Status: {MovieManager.movies.Count} ");
                Console.WriteLine("1. Display movies");
                Console.WriteLine("2. Display by year");
                Console.WriteLine("3. Add movie");
                Console.WriteLine("4. Remove movie");
                Console.WriteLine("5. Clear all movies");
                Console.WriteLine("6. Exit");

                Console.Write("What would you like to do: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Display();
                        break;
                    case "2":
                        DisplayByYear();
                        break;
                    case "3":
                        Add();
                        break;
                    case "4":
                        Remove();
                        break;
                    case "5":
                        RemoveAll();
                        break;
                    case "6":
                        Console.WriteLine("Exiting the app.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }
        public static void Display()
        {
            if (MovieManager.movies.Count == 0)
            {
                Console.WriteLine("No movies available."); //exception
            }
            else
            {
                Console.WriteLine("List of movies:");
                try
                {
                    Console.WriteLine(MovieManager.DisplayMovies());
                }catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static void DisplayByYear()
        {
            Console.WriteLine("Enter the year you want to see movies of");
            int yearSorting = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Movies in year " + yearSorting + " are:");
            try
            {
                var moviesInYear = MovieManager.ShowMoviesByYear(yearSorting);
                foreach(var movie in moviesInYear) 
                {
                    Console.WriteLine($"ID: {movie.MovieId}, Name: {movie.Name}, Genre: {movie.Genre}, Year: {movie.Year}");
                }
            }catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void Add()
        {
            Console.Write("Enter movie ID: ");
            int movieId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter movie name: ");
            string name = Console.ReadLine();
            Console.Write("Enter movie genre: ");
            string genre = Console.ReadLine();
            Console.Write("Enter movie year: ");
            int year = Convert.ToInt32(Console.ReadLine());
            try 
            {
                MovieManager.AddMovie(movieId, name, genre, year);
            }catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Movie added successfully.");
        }
        public static void Remove()
        {
            Console.WriteLine("Enter the movie you want to remove");
            string removeMovie = Console.ReadLine();
            if (MovieManager.RemoveMovieByName(removeMovie))
            {
                Console.WriteLine("Movie Removed");
            }
            else
            {
                Console.WriteLine("Movie not found");
            }
        }
        public static void RemoveAll()
        {
            try
            {
                MovieManager.ClearAllMovies();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("All movies cleared.");
        }    
    }
}
