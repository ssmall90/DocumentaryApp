namespace DocumentaryAppLibrary.DataAccess;

public interface IMongoCategoryData
{
   Task CreateCategory(CategoryModel category);
   Task<List<CategoryModel>> GetAllCategories();
}