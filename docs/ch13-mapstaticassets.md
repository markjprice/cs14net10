# Page 673 - Enabling static and default files

In Step 1, I wrote, "add statements after enabling HTTPS redirection to enable static files and default files" with the following code:
```cs
app.UseDefaultFiles(); // index.html, default.html, and so on.
app.MapStaticAssets(); // .NET 9 or later.
// app.UseStaticFiles(); // .NET 8 or earlier.

app.MapGet("/env", () =>
  $"Environment is {app.Environment.EnvironmentName}");
```

Preceding this, the reader is asked to create the `wwwroot` folder and create four static files within it:
1. `index.html`: This will be the default page for the website.
2. `site.css`: A simple stylesheet that sets `H1` elements to a dark blue color.
3. `categories.jpeg`: An image of different categories of products.
4. `about.html`: This webpage references the stylesheet and image.

## Issue 1: Browsers failing to decode compressed files due to corruption because other features modify the response stream

When running the website, the `index.html` file never downloads so a blank page is shown in Chrome. Developer Tools console shows `Failed to load resource: net::ERR_CONTENT_DECODING_FAILED`.

If you manually request any of the `MapGet` endpoints, they work, e.g. `/env` or `/data`. If you manually request the stylesheet or image, they display correctly.

But `MapStaticAssets` has an issue with working with HTML files. Some have [speculated in a GitHub issue](https://github.com/dotnet/aspnetcore/issues/58940) that this could be caused by:
1. Hot Reload. 
2. Visual Studio Browser Link.
3. `<body>` tag. (Possibly because Browser Link looks for the end of the `</body>` to determine where to inject its script!)

`MapStaticAssets` compresses files during the build process. This is why you must rebuild your project if you add, modify, or remove files from `wwwroot`. If you do not rebuild, the compression process does not happen, and there will be a mismatch between the files in `wwwroot` and what is expected by the previously built project. In the output window, ASP.NET Core will write warnings about which files are mismatched but it will allow your project to run and you will experience unexpected behavior.

My best guess is that any system attempting to dynamically inject some script or other elements into the compressed file at runtime will cause problems during decompression because it has literally "corrupted" the response stream! To fix the issue, you would need to do one of the following (each has pros and cons so there is no good fix--just choices with trade-offs):
1. Disable the Visual Studio browser refresh and Hot Reload/Browser Link features (and anything else that dynamically modifies the response stream). I show how to do this in the *Visual Studio features that dynamically inject into HTML files* section below.
2. Not use static HTML files. You can map an endpoint and return raw HTML instead, as I show in the book and below. But this means your HTML files are not compressed.
3. Switch back to the non-compressed static file process by replacing `MapStaticAssets` with `UseStaticFiles`. But this means all your static files are not compressed.

> **Note**: Since the most common issue is caused by Visual Studio features, if you do not use Visual Studio then you can use `MapStaticAssets` without worrying. And Visual Studio only injects its scripts during development, NOT production. So in production you can use `MapStaticAssets` without worrying at all. But you may have a scenario where some other system dynamically injects into HTML pages in production, and in those scenarios, you will need to consider disabling `MapStaticAssets` for HTML files.

## Issue 2: Simulating a "Production" environment cannot find the correct compressed files

A second issue is related to setting the environment to `Production` instead of `Development`. If the reader leaves the environment set to `Production`, then requests for the stylesheet will fail because the reader is still running the "development" project. To make sure the paths are matched properly, we need to manually tell the static asset system to use the current environment to find the correct files.

I am currently working on the .NET 10 edition of this book, and .NET 10 Preview 4 still has this issue with `.html` files because its not really a "bug" with `MapStaticAssets` itself. Based on the issue (other systems modifying the compressed files), I don't think the issue can be easily fixed. I'm guessing that the team is trying to find a way to allow both compression of HTML files and dynamic injection into them, but it's a tricky problem to fix reliably. I suspect that for .NET 10 all they can do is document the issue and leave it to developers to decide which trade-off to make. So I will do the same in the .NET 10 editions of my books.

I therefore plan the following changes in my book instructions:

1. Create the `about.html`, `site.css`, and `categories.jpeg` files (but not `index.html` since it would immediately fail and confuse the reader).
2. Show how `UseStaticFiles` works with all those static file types (but highlight that they are not compressed).
3. Switch to `MapStaticAssets` and show in **Developer Tools** | **Network** tab how stylesheets and images continue to work and now use GZ compression.
4. Show how HTML files like `about.html` fail with the decoding error so readers will understand what to look for in their own projects to detect this issue.
5. Add some statements to the `MapGet` for `/welcome`, and move it to a separate file as an extension method, as shown in the following code:
```cs
app.MapGet("/", () => Results.Content(
  content: $"""
<!doctype html>
<html lang="en">
<head>
  <!-- Required meta tags -->
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
  <!-- Bootstrap CSS -->
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
  <link href="site.css" rel="stylesheet" />
  <title>Welcome to Northwind Web!</title>
</head>
<body>
  <div class="container">
    <div class="jumbotron">
      <h1 class="display-3">Welcome to Northwind B2B</h1>
      <p class="lead">We supply products to our customers.</p>
      <hr />
      <h2>This is a static HTML page.</h2>
      <p>Our customers include restaurants, hotels, and cruise lines.</p>
      <img src="categories.jpeg" height="400" width="600" />
      <p>
        <a class="btn btn-primary" href="https://www.asp.net/">
          Learn more
        </a>
      </p>
    </div>
  </div>
</body>
</html>
""",
  contentType: "text/html"));
```
6. Show that the endpoint for the root `/` that returns a web page using code instead of a static file works because the static asset system doesn't know to compress it, and note the dynamically injected `<script>` blocks.
7. Disable Browser Link and browser refresh and show that the `about.html` now works. (But warn that other systems that dynamically inject would need to be disabled too.)
    - Navigate to **Tools** | **Options**.
    - In the **Options** dialog box, navigate to **Projects and Solutions** | **ASP.NET Core**.
    - Set the **Auto build and refresh option** dropdown listbox to **None** and the **CSS Hot Reload** dropdown listbox to **Disabled**, as shown in the following figure:
![Disabling Visual Studio features that do dynamic script injection](errata-p673.png)
8. Import the `Microsoft.AspNetCore.Hosting.StaticWebAssets` namespace and then add a statement to manually switch static assets system to the appropriate environment, as shown in the following code:
```cs
// To use StaticWebAssetsLoader.
using Microsoft.AspNetCore.Hosting.StaticWebAssets;

var builder = WebApplication.CreateBuilder(args);

// Enable switching environments (Development, Production) during development.
StaticWebAssetsLoader.UseStaticWebAssets(
  builder.Environment, builder.Configuration);

var app = builder.Build();
```

## Visual Studio features that dynamically inject into HTML files

When **Auto build and refresh option** is set to **Auto build and refresh browser after saving changes**, a `<script>` element for `aspnetcore-browser-refresh.js` is dynamically added to every HTML page. When **CSS Hot Reload** is set to **Enabled**, a `<script>` element for `/_vs/browserLink.js` is dynamically added to every HTML page.

![The injected scripts for those features](errata-p673c.png)
![Enabling Visual Studio features that do dynamic script injection](errata-p673b.png)
