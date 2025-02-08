**Errata** (18 items)

If you find any mistakes, then please [raise an issue in this repository](https://github.com/markjprice/cs13net9/issues) or email me at markjprice (at) gmail.com.

- [Page 24 - Revealing the namespace for the Program class](#page-24---revealing-the-namespace-for-the-program-class)
- [Page 29 - Writing code using VS Code](#page-29---writing-code-using-vs-code)
- [Page 112 - Custom number formatting](#page-112---custom-number-formatting)
- [Page 147 - Understanding how foreach works internally](#page-147---understanding-how-foreach-works-internally)
- [Page 175 - Throwing overflow exceptions with the checked statement](#page-175---throwing-overflow-exceptions-with-the-checked-statement)
- [Page 208 - Using the Visual Studio Code integrated terminal during debugging](#page-208---using-the-visual-studio-code-integrated-terminal-during-debugging)
- [Page 393 - Publishing a single-file app](#page-393---publishing-a-single-file-app)
- [Page 400 - Publishing a native AOT project](#page-400---publishing-a-native-aot-project)
- [Page 437 - Understanding the syntax of a regular expression](#page-437---understanding-the-syntax-of-a-regular-expression)
- [Page 483 - Managing directories, Managing files](#page-483---managing-directories-managing-files)
- [Page 570 - Getting a single entity](#page-570---getting-a-single-entity)
- [Page 650 - Testing the class libraries, Page 693 - Build a data-driven web page, Page 694 - Build web pages for functions](#page-650---testing-the-class-libraries-page-693---build-a-data-driven-web-page-page-694---build-web-pages-for-functions)
- [Page 660 - Creating an empty ASP.NET Core project](#page-660---creating-an-empty-aspnet-core-project)
- [Page 683 - Adding code to a Blazor static SSR page](#page-683---adding-code-to-a-blazor-static-ssr-page)
- [Page 750 - Creating data repositories with caching for entities](#page-750---creating-data-repositories-with-caching-for-entities)
- [Page 780 - Companion books to continue your learning journey](#page-780---companion-books-to-continue-your-learning-journey)
- [Exercise 13.2 – practice exercises - Build web pages for functions](#exercise-132--practice-exercises---build-web-pages-for-functions)
- [Appendix - Page 3](#appendix---page-3)

# Page 24 - Revealing the namespace for the Program class

> Thanks to **John Tempest** in an email for raising this issue on December 21, 2024.

In the **Good Practice** box, I wrote, "Code editors have a feature named code snippets. These allow you to insert pieces of code that you commonly use, by typing a shortcut and pressing *Tab* twice." But you only need to press *Tab* once.

# Page 29 - Writing code using VS Code

> Thanks to **Andriko** in the book's Discord channel for asking a question about this issue.

I wrote, "In the preceding steps, I showed you how to use the dotnet CLI to create solutions and projects. Finally, with the August 2024 or later releases of the C# Dev Kit, VS Code has an improved project creation experience that provides you access to the same options you can use when creating a new project through the `dotnet` CLI. To enable this ability, you must change a setting, as shown in the following configuration:"
```
"csharp.experimental.dotnetNewIntegration": true
```

This feature is no longer in preview so you do not need to enable it. In the next edition, I will remove the sentence about enabling it and the setting.

# Page 112 - Custom number formatting

> Thanks to [Donald Maisey](https://github.com/donaldmaisey) for raising [this issue on February 5, 2025](https://github.com/markjprice/cs13net9/issues/13).

In Step 1, I tell the reader to enter some code that calls the `WriteLine` method without the `Console.` prefix. I do not introduce simplifying the statement like that for another two pages. In the next edition, I will add the prefix, as shown in the following code:
```cs
decimal value = 0.325M;
Console.WriteLine("Currency: {0:C}, Percentage: {0:0.0%}", value);
```

# Page 147 - Understanding how foreach works internally

> Thanks to [Justin Treher](https://github.com/jtreher) for raising [this issue on January 3, 2025](https://github.com/markjprice/cs13net9/issues/6).

In Step 1, I wrote, "Type statements to create an array of string variables and then output the length of each one, as shown in the following code:"
```cs
string[] names = { "Adam", "Barry", "Charlie" };

foreach (string name in names)
{
  WriteLine($"{name} has {name.Length} characters.");
}
```

I then wrote, "The compiler turns the `foreach` statement in the preceding example into something like the following pseudocode:"
```cs
IEnumerator e = names.GetEnumerator();

while (e.MoveNext())
{
  string name = (string)e.Current; // Current is read-only!
  WriteLine($"{name} has {name.Length} characters.");
}
```

But the `names` variable is an array, and although arrays implement the `IEnumerable<T>` interface as described in this section, the compiler is smart enough to ignore that and instead write a `for` loop that uses the `Length` property of the array since that is more efficient than using the `IEnumerable` interface. 

In the next edition, I will use a `List<string>` instead of an array for the `names` variable, and add a note that arrays are treated as a special case by the compiler. 

# Page 175 - Throwing overflow exceptions with the checked statement

> Thanks to [Justin Treher](https://github.com/jtreher) for raising [this issue on January 3, 2025](https://github.com/markjprice/cs13net9/issues/7).

In Step 3, I wrote, "let’s get the compiler to warn us about the overflow by wrapping the statements using a `checked` statement block", but it is not the compiler that warns us, it is the runtime that detects the overflow and throws the exception. In the next edition I will replace "compiler" with "runtime".

# Page 208 - Using the Visual Studio Code integrated terminal during debugging

> Thanks to **kingace9371** for asking a question about this, and to **rene** for providing the answer in the book's Discord channel.

In Step 7, I wrote, "In the `launch.json` file editor, click the **Add Configuration...** button, and then select **.NET: Launch .NET Core Console App**"

The name of this option is now called **.NET: Launch Executable file (Console)**, as shown in the following figure:

![.NET: Launch Executable file (Console)](errata-p196.png)

# Page 393 - Publishing a single-file app

> Thanks to [Vlad Alexandru Meici](https://github.com/vladmeici) for raising [this issue on December 8, 2024](https://github.com/markjprice/cs12dotnet8/issues/77).

In the two command lines, I used `/p` to set a project property when I should have used `-p`. The complete command is:
```
dotnet publish -r win10-x64 -c Release --no-self-contained -p:PublishSingleFile=true
```

# Page 400 - Publishing a native AOT project

> Thanks to [Nathan Wolfe](https://github.com/scotswolfie) for raising [this issue on January 14, 2025](https://github.com/markjprice/cs12dotnet8/issues/83).

I wrote, "A console app that functions correctly during development when the code is untrimmed and JIT-compiled could still fail once you publish it using native AOT because then the code is trimmed and JIT-compiled and, therefore, it is a different code with different behavior."

But I mistakenly repeated "JIT-compiled" when I meant "AOT-compiled". 

I should have written, "A console app that functions correctly during development when the code is untrimmed and JIT-compiled could still fail once you publish it using native AOT because then the code is trimmed and AOT-compiled and, therefore, it is a different code with different behavior."

# Page 437 - Understanding the syntax of a regular expression

> Thanks to **rene** in the book's Discord channel for raising this issue.

In *Table 8.6*, the entry for `{,3}` is wrong. That is not a valid range and so it actually matches the exact string `{,3}`! To match "Up to three", you should use `{0,3}` or `{1,3}` depending on whether you want to accept zero or one as the lowest value. I will fix this in the 10th edition.

# Page 483 - Managing directories, Managing files

> Thanks to [Vlad Alexandru Meici](https://github.com/vladmeici) for raising [this issue on December 31, 2024](https://github.com/markjprice/cs12dotnet8/issues/80).

After prompting the user to press any key to delete the directory or file, the code should have an extra statement to output a new line otherwise the next text written to the console will appear immediately at the end of the "Press any key..." text.

This has been fixed in the code solutions here:
https://github.com/markjprice/cs13net9/commit/d75644ad74bf3ffbd9ff202e0bf6f2ad665ca5ea

# Page 570 - Getting a single entity

> Thanks to [es-moises](https://github.com/es-moises) for raising [this issue on January 22, 2025](https://github.com/markjprice/cs12dotnet8/issues/84).

In Step 3, the output in two places shows part of the `WHERE` clause as `"p"."ProductId" > @__id_0` but both should be `"p"."ProductId" = @__id_0`.

# Page 650 - Testing the class libraries, Page 693 - Build a data-driven web page, Page 694 - Build web pages for functions

I end the **Testing the class libraries** section by writing, "Finally, in this chapter, let’s review some key concepts about web development, enabling us to be better prepared to dive into ASP.NET Core Razor Pages in the next chapter."

In the **Build a data-driven web page** exercise, I wrote, "Add a Razor Page to the `Northwind.Web` website..."

In the **Build web pages for functions** exercise, I wrote, "Reimplement some of the console apps from earlier chapters as Razor Pages;"

In these instances, "Razor Pages" or "Razor Page" should be "Blazor" or "Blazor page component".

# Page 660 - Creating an empty ASP.NET Core project

> Thanks to **rene** in the Discord channel for this book for raising this issue on February 6, 2025.

In Step 1, I describe the options when creating a new ASP.NET Core project. The option that used to be labelled **Enable Docker** is now labelled **Enable container support**. And the new option labelled **Enlist in .NET Aspire orchestration** should be cleared.

# Page 683 - Adding code to a Blazor static SSR page

> Thanks to [Taylor Fore](https://github.com/trfore) for raising [this issue on January 8, 2025](https://github.com/markjprice/cs13net9/issues/8).

In Step 1, I wrote, `Index.cshtml` when I should have written `Index.razor`.

# Page 750 - Creating data repositories with caching for entities

> Thanks to Jeroen for asking a question about this issue.

In Step 3, I wrote, "In `Program.cs`, before the call to `Build`, in the section for configuring services, register the hybrid cache service..."

Unfortunately, even after the release of .NET 9 on November 12, 2024, the `Microsoft.Extensions.Caching.Hybrid` package is still in preview, and the `AddHybridCache` method call causes a compiler warning. Until the package is released as GA, you will need to surround the call with a temporary warning suppression, as shown in the following code:
```cs
#pragma warning disable EXTEXP0018 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
builder.Services.AddHybridCache(options =>
{
  options.DefaultEntryOptions = new HybridCacheEntryOptions
  {
    Expiration = TimeSpan.FromSeconds(60),
    LocalCacheExpiration = TimeSpan.FromSeconds(30)
  };
});
#pragma warning restore EXTEXP0018 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
```

# Page 780 - Companion books to continue your learning journey

> Thanks to [Jort Rodenburg](https://github.com/jjrodenburg) for raising [this issue on January 31, 2025](https://github.com/markjprice/cs13net9/issues/12).

The order of the four books in *Figure 16.1* does not match the order of the numbered descriptions. Numbers 3. and 4. should be swapped.

# Exercise 13.2 – practice exercises - Build web pages for functions

This exercise should have been in *Chapter 14 Building Interactive Web Components Using Blazor*, because it is much easier to implement using interactive Blazor features rather than the limited Blazor static server-side rendering (SSR).

Updated functions page to use server-side interactivity:
https://github.com/markjprice/cs13net9/blob/main/code/ModernWeb/Northwind.Blazor/Northwind.Blazor/Components/Pages/Functions.razor

Updated navmenu to include link to functions page:
https://github.com/markjprice/cs13net9/blob/main/code/ModernWeb/Northwind.Blazor/Northwind.Blazor/Components/Layout/NavMenu.razor

# Appendix - Page 3

> Thanks to [Donald Maisey](https://github.com/donaldmaisey) for raising [this issue on February 5, 2025](https://github.com/markjprice/cs13net9/issues/14).

I re-arranged the practices and exercises at the end of Chapter 2 but forgot to also update the order in the appendix:
- **Exercise 2.1 – Test your knowledge** should be **Exercise 2.3**.
- **Exercise 2.2 – Test your knowledge of number types** is a second part to **Exercise 2.3**.
- **Exercise 2.3 – Practice number sizes and ranges** should be **Exercise 2.2**.
