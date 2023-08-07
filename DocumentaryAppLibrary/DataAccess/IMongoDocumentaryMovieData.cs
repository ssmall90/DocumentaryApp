namespace DocumentaryAppLibrary.DataAccess;

public interface IMongoDocumentaryMovieData
{
   Task<List<DocumentaryMovieModel>> GetAllDocumentarires();
   Task<DocumentaryMovieModel> GetDocumentary(string id);
   Task<List<DocumentaryMovieModel>> GetThreeDocumentariesByCategory(CategoryModel category);
   Task UpdateDocumentary(DocumentaryMovieModel documentary);
}