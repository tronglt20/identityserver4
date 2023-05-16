using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Net.Http.Headers;

namespace Movies.Client.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddClientAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
             .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
             .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
             {
                 options.Authority = "https://localhost:3000";

                 options.ClientId = "movies_mvc_client";
                 options.ClientSecret = "secret";
                 options.ResponseType = "code";

                 options.Scope.Add("openid");
                 options.Scope.Add("profile");

                 options.SaveTokens = true;
                 options.GetClaimsFromUserInfoEndpoint = true;
             });

            return services;
        }


        public static IServiceCollection AddHttpClientConfig(this IServiceCollection services)
        {
            services.AddHttpClient("MovieAPIClient", client =>
            {
                client.BaseAddress = new Uri("https://localhost:3001/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            });

            return services;
        }
    }
}
