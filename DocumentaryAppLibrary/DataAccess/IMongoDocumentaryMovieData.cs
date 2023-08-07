namespace DocumentaryAppLibrary.DataAccess;

public interface IMongoDocumentaryMovieData
{
   Task CreateDocumentary(DocumentaryMovieModel documentary);
   Task<List<DocumentaryMovieModel>> GetAllDocumentarires();
   Task<DocumentaryMovieModel> GetDocumentary(string id);
   Task<List<DocumentaryMovieModel>> GetThreeDocumentariesByCategory(string category);
   Task UpdateDocumentary(DocumentaryMovieModel documentary);
}