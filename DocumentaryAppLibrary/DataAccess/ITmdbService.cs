public interface ITmdbService
{
   MovieResponse FilterResults(MovieResponse movies);
   Task<Movie> GetMovie(string id);
   Task<MovieResponse> GetPopularMoviesAsync();
}