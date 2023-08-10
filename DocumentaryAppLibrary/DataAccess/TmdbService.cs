using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class TmdbService : ITmdbService
{
   private readonly HttpClient _httpClient;
   private const string ApiKey = "8ad7b69946f794a837063ddaca7740d1";
   MovieResponse movieResponse;
   MovieResponse similarMovieResponse;
   Random randomizer = new Random();

   public TmdbService(HttpClient httpClient)
   {
      _httpClient = httpClient;
   }

   public async Task<MovieResponse> GetPopularMoviesAsync()
   {
      int pageNumber = randomizer.Next(1, 500);
      string apiUrl = $"https://api.themoviedb.org/3/discover/movie?api_key={ApiKey}&with_genres=99&page={pageNumber}";

      HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

      if (response.IsSuccessStatusCode)
      {

         string jsonResponse = await response.Content.ReadAsStringAsync();

         Console.WriteLine(jsonResponse);

         movieResponse = JsonConvert.DeserializeObject<MovieResponse>(jsonResponse);
         movieResponse = FilterResults(movieResponse);
         return movieResponse;

      }
      else
      {
         throw new Exception($"API request failed with status code: {response.StatusCode}");
      }
   }

   public MovieResponse FilterResults(MovieResponse movies)
   {
      movies.Results = movies.Results.OrderBy(x => randomizer.Next(1, movies.Results.Count)).Take(3).ToList();
      return movies;
   }

   public async Task<Movie> GetMovie(string id)
   {
      return await Task.FromResult(movieResponse.Results.FirstOrDefault(m => m.id == id));
   }



   public async Task<List<Movie>> GetSimilarMovies(string movieId)
   {
      int pageNumber = randomizer.Next(1, 5);
      string movie_id = movieId;
      string apiUrl = $"https://api.themoviedb.org/3/movie/{movie_id}/similar?api_key={ApiKey}";

      HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

      if (response.IsSuccessStatusCode)
      {

         string jsonResponse = await response.Content.ReadAsStringAsync();

         Console.WriteLine(jsonResponse);

         similarMovieResponse = JsonConvert.DeserializeObject<MovieResponse>(jsonResponse);
         similarMovieResponse = FilterResults(similarMovieResponse);
         return similarMovieResponse.Results;

      }
      else
      {
         throw new Exception($"API request failed with status code: {response.StatusCode}");
      }
   }

}




