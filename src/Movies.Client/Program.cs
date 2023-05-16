using Movies.Client.Extensions;
using Movies.Client.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
services.AddControllersWithViews();

// Add authentication config
services.AddClientAuthentication();

// Add httpClient config
/*services.AddHttpClientConfig();*/

services.AddHttpContextAccessor();

services.AddScoped<MovieService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
