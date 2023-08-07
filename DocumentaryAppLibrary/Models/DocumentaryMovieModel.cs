namespace DocumentaryAppLibrary.Models;

 public class DocumentaryMovieModel
 {
   [BsonId]
   [BsonRepresentation(BsonType.ObjectId)]
   public string Id { get; set; }
   public string MovieName { get; set; }
   public string MovieYear { get; set; }
   public  string MovieRunTime { get; set; }
   public int MovieRating { get; set; }
   public  string MovieDescription { get; set; }
   public CategoryModel MovieCategory { get; set; }
   public bool HasUserWatched { get; set; } = false;

}
