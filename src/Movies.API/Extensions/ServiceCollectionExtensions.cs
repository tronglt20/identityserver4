using Microsoft.EntityFrameworkCore;
using Movies.API.Data;

namespace Movies.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                   options.UseInMemoryDatabase("Movies"));

            // Seeding data here
            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                MovieDataSeeder.SeedAsync(context);
            }

            return services;
        }
    }
}
