using DocumentaryAppLibrary.Models;

namespace DocumentaryAppLibrary.DataAccess;

public interface IMovieData
{
   List<Movie> Results { get; }

   MovieResponse GetMovies();
   List<Movie> GetSimilarMovies();
   Movie ReturnMovie(Movie movie);
   MovieResponse SetMovies(MovieResponse movies);
   List<Movie> SetSimilarMovies(List<Movie> similarMovies);
}