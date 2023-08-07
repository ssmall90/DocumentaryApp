using Microsoft.Extensions.Caching.Memory;

namespace DocumentaryAppLibrary.DataAccess;
public class MongoDocumentaryMovieData : IMongoDocumentaryMovieData
{
   private readonly IDbConnection _db;
   private readonly IMongoUserData _userData;
   private readonly IMemoryCache _cache;
   private readonly IMongoCollection<DocumentaryMovieModel> _documentaries;
   private const string cacheName = "DocumentaryData";
   public MongoDocumentaryMovieData(IDbConnection db, IMongoUserData userData, IMemoryCache cache)
   {
      _db = db;
      _userData = userData;
      _cache = cache;
      _documentaries = db.DocumentaryCollection;
   }

   public async Task<List<DocumentaryMovieModel>> GetAllDocumentarires()
   {
      var output = _cache.Get<List<DocumentaryMovieModel>>(cacheName);
      if (output is null)
      {
         var results = await _documentaries.FindAsync(_ => true);
         output = results.ToList();

         _cache.Set(cacheName, output, TimeSpan.FromMinutes(1));
      }
      return output;
   }

   public async Task<DocumentaryMovieModel> GetDocumentary(string id)
   {
      var results = await _documentaries.FindAsync(d => d.Id == id);
      return results.FirstOrDefault();
   }

   public async Task UpdateDocumentary(DocumentaryMovieModel documentary)
   {
      await _documentaries.ReplaceOneAsync(d => d.Id == documentary.Id, documentary);
      _cache.Remove(cacheName);
   }

   public async Task<List<DocumentaryMovieModel>> GetThreeDocumentariesByCategory(CategoryModel category)
   {
      var results = await _documentaries.FindAsync(m => m.MovieCategory == category);
      var output = results.ToList();

      Random random = new Random();

      return output.OrderBy(x => random.Next()).Take(3).ToList();

   }

}
