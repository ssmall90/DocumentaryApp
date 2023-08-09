using System.Globalization;
using System.Text.Json.Serialization;

namespace DocumentaryAppLibrary.Models;
public class Movie
{
   public string id { get; set; }
   public string title { get; set; }
   public string release_date { get; set; }
   public string overview { get; set; }
   public float vote_average { get; set; }
   public string poster_path { get; set; }
   public string FullPosterPath
   {
      get
      {
         const string baseUrl = "https://image.tmdb.org/t/p/w500"; // You can choose different sizes (w92, w185, w500, etc.)
         if(poster_path is not null)
         {
            return $"{baseUrl}{poster_path}";
         }
         else
         {
            return "/Images/ImageComingSoon.png";
         }

      }
   }

}