namespace DocumentaryAppUi;

public static class RegisterServices
{
   public static void ConfigureServices(this WebApplicationBuilder builder)
   {
      // Add services to the container.
      builder.Services.AddRazorPages();
      builder.Services.AddServerSideBlazor();
      builder.Services.AddMemoryCache();

      builder.Services.AddSingleton<IDbConnection, DbConnection>();
      builder.Services.AddSingleton<IMongoCategoryData, MongoCategoryData>();
      builder.Services.AddSingleton<IMongoDocumentaryMovieData, MongoDocumentaryMovieData>();
      builder.Services.AddSingleton<IMongoUserData, MongoUserData>();
   }

}
