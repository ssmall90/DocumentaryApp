using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

public class TmdbService : ITmdbService
{
   private readonly HttpClient _httpClient;
   private const string ApiKey = "dad135b3b5dc9dfd559cd41968764a30";
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

   public async Task<Movie> GetMovieFromSimilarResponse(string id)
   {
      string apiUrl = $"https://api.themoviedb.org/3/movie/{id}?api_key={ApiKey}";

      HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

      if (response.IsSuccessStatusCode)
      {
         string jsonResponse = await response.Content.ReadAsStringAsync();
         Movie movie = JsonConvert.DeserializeObject<Movie>(jsonResponse);
         return movie;
      }
      else
      {
         throw new Exception($"API request failed with status code: {response.StatusCode}");
      }
      //return await Task.FromResult(similarMovieResponse.Results.FirstOrDefault(m => m.id == id));
   }


   public async Task<List<Movie>> GetSimilarMovies(string movieId)
   {
      string movie_id = movieId;
      int pageNumber = randomizer.Next(1, 500);
      string apiUrl = $"https://api.themoviedb.org/3/discover/movie?api_key={ApiKey}&with_genres=99&page={pageNumber}";

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




