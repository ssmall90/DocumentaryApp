﻿namespace DocumentaryAppUi;

public static class RegisterServices
{
   public static void ConfigureServices(this WebApplicationBuilder builder)
   {
      // Add services to the container.
      builder.Services.AddRazorPages();
      builder.Services.AddServerSideBlazor();
      builder.Services.AddMemoryCache();

      builder.Services.AddScoped<ITmdbService, TmdbService>();
      builder.Services.AddHttpClient();
      builder.Services.AddScoped<IMovieData, MovieData>();
   }

}
