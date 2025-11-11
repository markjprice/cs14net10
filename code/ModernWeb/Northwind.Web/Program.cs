using Northwind.EntityModels; // To use AddNorthwindContext method.
using Northwind.Web.Components; // To use App.

// To use StaticWebAssetsLoader.
using Microsoft.AspNetCore.Hosting.StaticWebAssets;

#region Configure the web server host and services.

var builder = WebApplication.CreateBuilder(args);

// Only necessary if you want to switch environments during development.
StaticWebAssetsLoader.UseStaticWebAssets(
  builder.Environment, builder.Configuration);

builder.Services.AddRazorComponents();
builder.Services.AddNorthwindContext();

var app = builder.Build();

#endregion

#region Configure the HTTP pipeline and routes

if (!app.Environment.IsDevelopment())
{
  app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.UseDefaultFiles(); // index.html, default.html, and so on.
//app.UseStaticFiles(); // .NET 8 or earlier.
app.MapStaticAssets(); // .NET 9 or later.

app.MapRazorComponents<App>();

app.MapGet("/env", () =>
  $"Environment is {app.Environment.EnvironmentName}");

app.MapGet("/data", () => Results.Json(new
{
  firstName = "John",
  lastName = "Doe",
  age = 30
}));

app.MapGet("/welcome", () => Results.Content(
  content: $"""
  <!doctype html>
  <html lang="en">
  <head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <link href="site.css" rel="stylesheet" />
    <title>About Northwind Web</title>
  </head>
  <body>
    <div class="container">
      <div class="jumbotron">
        <h1 class="display-3">About Northwind Web</h1>
        <p class="lead">We supply products to our customers.</p>
        <img src="categories.jpeg" style="height:200px;width:300px;" />
      </div>
    </div>
  </body>
  </html>
  """,
  contentType: "text/html"));

#endregion

// Start the web server, host the website, and wait for requests.
app.Run(); // This is a thread-blocking call.

WriteLine("This executes after the web server has stopped!");
