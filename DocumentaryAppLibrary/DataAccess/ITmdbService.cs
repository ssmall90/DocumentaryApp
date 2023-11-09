using DocumentaryAppLibrary.Models;

public interface ITmdbService
{
   MovieResponse FilterResults(MovieResponse movies);
   Task<Movie> GetMovie(string id);
   Task<Movie> GetMovieFromSimilarResponse(string id);
   Task<MovieResponse> GetPopularMoviesAsync();
   Task<List<Movie>> GetSimilarMovies(string movieId);
}