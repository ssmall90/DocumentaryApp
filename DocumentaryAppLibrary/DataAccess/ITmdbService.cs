public interface ITmdbService
{
   Task<MovieResponse> GetPopularMoviesAsync();
}