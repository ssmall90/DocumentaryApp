namespace DocumentaryAppLibrary.Models;
public class BasicDocumentaryMovieModel
{
   [BsonRepresentation(BsonType.ObjectId)]
   public string Id { get; set; }
   public string MovieName { get; set; }

   public BasicDocumentaryMovieModel()
   {
      
   }

   public BasicDocumentaryMovieModel(DocumentaryMovieModel movie)
   {
      Id = movie.Id;
      MovieName = movie.MovieName;
   }
}
