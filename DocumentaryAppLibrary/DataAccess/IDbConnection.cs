using MongoDB.Driver;

namespace DocumentaryAppLibrary.DataAccess;
public interface IDbConnection
{
   IMongoCollection<CategoryModel> CategoryCollection { get; }
   string CategoryCollectionName { get; }
   MongoClient Client { get; }
   string DbName { get; }
   IMongoCollection<DocumentaryMovieModel> DocumentaryCollection { get; }
   string DocumentaryCollectionName { get; }
   IMongoCollection<UserModel> UserCollection { get; }
   string UserCollectionName { get; }
}