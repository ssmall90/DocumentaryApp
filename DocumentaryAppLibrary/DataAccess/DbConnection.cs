using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace DocumentaryAppLibrary.DataAccess;
public class DbConnection
{
   private readonly IConfiguration _config;
   private readonly IMongoDatabase _db;
   private string _connectionId = "MongoDB";

   public string DbName { get; private set; }
   public string CategoryCollectionName { get; private set; } = "categories";
   public string DocumentaryCollectionName { get; private set; } = "documentaries";
   public string UserCollectionName { get; private set; } = "users";

   public MongoClient Client { get; private set; }
   public IMongoCollection<CategoryModel> CategoryCollection { get; private set; }
   public IMongoCollection<DocumentaryMovieModel> DocumentaryCollection { get; private set; }
   public IMongoCollection<UserModel> UserCollection { get; private set; }


   public DbConnection(IConfiguration config)
   {
      _config = config;
      Client = new MongoClient(_config.GetConnectionString(_connectionId));
      DbName = config["DatabaseName"];
      _db = Client.GetDatabase(DbName);

      CategoryCollection = _db.GetCollection<CategoryModel>(CategoryCollectionName);
      DocumentaryCollection = _db.GetCollection<DocumentaryMovieModel>(DocumentaryCollectionName);
      UserCollection = _db.GetCollection<UserModel>(UserCollectionName);
   }
}
