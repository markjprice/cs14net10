using Northwind.EntityModels; // To use AddNorthwindContext method.
using Northwind.Web.Components; // To use App.

#region Configure the web server host and services.

var builder = WebApplication.CreateBuilder(args);

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
app.MapStaticAssets(); // .NET 9 or later.
//app.UseStaticFiles(); // .NET 8 or earlier.

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
    <title>Welcome to Northwind Web!</title>
  </head>
  <body>
    <h1>Welcome to Northwind Web!</h1>
  </body>
  </html>
  """,
  contentType: "text/html"));

#endregion

// Start the web server, host the website, and wait for requests.
app.Run(); // This is a thread-blocking call.
WriteLine("This executes after the web server has stopped!");
