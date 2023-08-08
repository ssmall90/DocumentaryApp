namespace DocumentaryAppLibrary.Models;
public class MovieResponse
{
   public List<Movie> Results { get; set; }


   public MovieResponse FilterResults(List<Movie> movies)
   {
      Random random = new Random();
      MovieResponse response = new MovieResponse();
      response.Results = movies.OrderBy(x => random.Next(1, movies.Count)).Take(3).ToList();
      return response;

   }
}