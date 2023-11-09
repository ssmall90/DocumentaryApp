using DocumentaryAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentaryAppLibrary.DataAccess;
public class MovieData : IMovieData
{
   private MovieResponse _movies;
   private List<Movie> _similarMovies;
   private Movie _loadedMovie;

   public MovieResponse SetMovies(MovieResponse movies)
   {
      return _movies = movies;
   }

   public Movie ReturnMovie(Movie movie)
   {
      return _loadedMovie = movie;
   }

   public MovieResponse GetMovies()
   {
      return _movies;
   }

   public List<Movie> SetSimilarMovies(List<Movie> similarMovies)
   {
      return _similarMovies = similarMovies;
   }

   public List<Movie> GetSimilarMovies()
   {
      return _similarMovies;
   }

   public List<Movie> Results { get { return _movies.Results; } }

}
