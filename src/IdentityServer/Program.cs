using IdentityServer.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add IdentityServer4
builder.Services.AddIdentityServer4(builder.Configuration);

var app = builder.Build();

app.UseIdentityServer();

app.MapGet("/", () => "Hello World!");

app.Run();