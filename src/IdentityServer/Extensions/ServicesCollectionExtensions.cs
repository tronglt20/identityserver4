using IdentityServer.Identity;

namespace IdentityServer.Extensions
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection AddIdentityServer4(this IServiceCollection services
            , IConfiguration configuration)
        {
            services.AddIdentityServer()
                .AddInMemoryClients(Config.Clients)
                .AddInMemoryApiScopes(Config.ApiScopes)
                .AddInMemoryIdentityResources(Config.IdentityResources)
                .AddTestUsers(TestUsers.Users)
                .AddDeveloperSigningCredential();

            return services;
        }
    }
}