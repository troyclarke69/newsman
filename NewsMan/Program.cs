using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace NewsMan
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();


            // below works for .net core 2.x, not v3
            //var host = CreateHostBuilder(args).Build();
            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;

            //    try
            //    {
            //        var context = services.GetRequiredService<NewsManDbContext>();
            //        context.Database.Migrate();
            //        SeedData.Initialize(services);
            //    }
            //    catch (Exception ex)
            //    {
            //        var logger = services.GetRequiredService<ILogger<Program>>();
            //        logger.LogError(ex, "An error occurred seeding the DB.");
            //    }
            //}
            //
            //host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
