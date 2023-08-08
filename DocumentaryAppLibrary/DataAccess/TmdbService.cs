using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class TmdbService : ITmdbService
{
   private readonly HttpClient _httpClient;
   private const string ApiKey = "8ad7b69946f794a837063ddaca7740d1";
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
         MovieResponse returnedValues = JsonConvert.DeserializeObject<MovieResponse>(jsonResponse);
         return returnedValues.FilterResults(returnedValues.Results);

      }
      else
      {
         throw new Exception($"API request failed with status code: {response.StatusCode}");
      }
   }
}



