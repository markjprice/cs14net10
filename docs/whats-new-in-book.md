**What's New in the 10th Edition**

There are hundreds of minor fixes and improvements throughout the 10th edition; too many to list individually. 

All [errata](https://github.com/markjprice/cs13net9/blob/main/docs/errata/errata.md) and [improvements](https://github.com/markjprice/cs13net9/blob/main/docs/errata/improvements.md) for the 9th edition (up to mid-September 2025) have been made to the 10th edition. After publishing the 10th edition, any errata and improvements for the 9th edition have been duplicated in both the 9th and 10th edition [errata and improvements](https://github.com/markjprice/cs14net10/blob/main/docs/errata/README.md).

The main new sections in *C# 14 and .NET 10 - Modern Cross-Platform Development*, 10th edition compared to the 9th edition can be found in this book's section on the [What's New in your .NET 10 books?](https://github.com/markjprice/markjprice/blob/main/articles/whats-new-in-net10-books.md#c-14-and-net-10---modern-cross-platform-development-fundamentals) page.

# Chapter 1
- New section **Shared content across all my books**: I use my personal GitHub repository to store shared content that is relevant to all my books. 
- I have streamlined this book by focusing on Visual Studio 2026, which is by far still the most popular IDE for .NET developers, especially beginners. Step-by-step instructions for using VS Code have moved online only: https://github.com/markjprice/cs14net10/blob/main/docs/code-editors/vscode.md
- New section **Cross-platform development on Windows**: Windows Subsystem for Linux (WSL) is one of the most powerful tools Microsoft has ever given to .NET developers doing cross-platform work.
- New section **Understanding how .NET and C# are related**: *Figure 1.8* shows how C# and other languages are related to .NET
- New section **Running a C# code file without a project file**: Rival languages like Python allow you to execute a code file without a project file. C# 14 introduces a similar feature named *file-based apps* that allows developers to execute single `.cs` files directly.

# Chapter 2
- Improved **Good practice** box discussing `double` versus `decimal`: https://github.com/markjprice/cs14net10/blob/main/docs/ch02-decimal-vs-double.md
- New section **Dynamic types with ExpandoObject**: A `dynamic` object that lets you add and remove properties at runtime, and internally it uses a dictionary to store the keys and values of these properties, but it’s accessible with dot notation just like with a regular class.

# Chapter 3
- New section **Null-coalescing operators**: summary of common null-related operators.
- New section **Null-conditional assignment operator**: new operator in C# 14.
- New section **Early return or guard clause style if statements**: avoids deeply nested code in if statements by returning from a method as soon as a condition is met (or not met).

# Chapter 4
- New section **Getting ChatGPT to add XML comments**
- Step-by-step instructions for using VS Code to debug and run tests have moved online: https://github.com/markjprice/cs14net10/blob/main/docs/code-editors/vscode.md#debugging-during-development
- Free .NET debugging book: *Practical Debugging for .NET Developers* by Michael Shpilt is now free: https://michaelscodingspot.com/free-book/

# Chapter 5
- New content *Table 5.3: Base enum types and their maximum values* and paragraphs to explain more about choices between signed and unsigned integers.
- New section **Outputting an object’s state using Dumpify**: A quick way to output all of an object’s fields and properties (collectively known as its state).
- New section **Implementing properties using the field keyword**: With C# 14 and later, instead of defining a private field to store a property value, you can let the compiler define the private field automatically and refer to it using the contextual keyword `field`.
- New section **Partial members**: C# 3 introduced partial methods. C# 13 introduced partial properties. C# 14 introduces partial events and partial instance constructors.

# Chapter 6
- New section **Dumping an object graph to the output**: When you are constructing complex object models (aka an object graph), it can be useful to quickly
output them in one method call using Dumpify.
- Moved section online: To learn how to compare objects using a separate class, you can read the online section found at the following link: https://github.com/markjprice/cs14net10/blob/main/docs/ch06-comparing-objects.md
- New section **Extension members** including *extension blocks*: In C# 14, you can define other types of extension members beyond just instance methods: static methods, instance properties, static properties, and operators.

# Chapter 7
- New section **Choosing between targeting .NET Standard 2.0 and .NET 10 for class libraries**
- New section **Noun-first alias for dotnet CLI commands**: Starting in .NET 10, the dotnet CLI tool has new aliases for commonly used commands.
- New section **Setting project properties at the command line**: The `-p` switch in the .NET CLI (`dotnet`) is shorthand for specifying a property or properties for a build or run command. 
- New section **Version ranges**: Understand the notation for version numbers and how to control version ranges.

# Chapter 8
- New section **Numeric ordering for string comparison**: Numerical string comparison, introduced with .NET 10, compares string values numerically instead of lexicographically. 
- New section **Using read-only lists**: `IReadOnlyList<string>` is often better than `List<string>` in public APIs when you want to enforce read-only semantics and hide implementation details
- New content: `OrderedDictionary<TKey, TValue>` provides `TryAdd` and `TryGetValue` for addition and retrieval.
- Moved section online: **Working with spans, indexes, and ranges**: https://github.com/markjprice/cs14net10/blob/main/docs/ch08-spans-indexes-ranges.md

# Chapter 9
- New section **Asynchronous ZIP archive APIs**: .NET 10 introduces new asynchronous APIs for working with ZIP archives, making it easier to perform non-blocking operations when reading from or writing to ZIP files.
- New section **JSON Patch implementation improvements**: .NET 10 introduces a new implementation of JSON Patch (RFC 6902) for ASP.NET Core based on `System.Text.Json`. This new implementation provides improved performance and reduced memory usage compared to the existing `Newtonsoft.Json`-based implementation.

# Chapter 10
- Added warning about the chapter using synchronous example code for learning but you should use asynchronous calls like `SaveChangesAsync` in production projects.
- New section **Why the EF Core CLI cannot use data annotations for everything**
- New content: In EF Core 9 and earlier, you can only have a single query filter per entity type. In EF Core 10 and later, you can name query filters and then disable them in specific LINQ queries.
- New online section **Implementing asynchronous methods with EF Core**: https://github.com/markjprice/cs14net10/blob/main/docs/ch10-ef-core-async.md

# Chapter 11
- New section **Difference between GroupBy and ToLookup**: Both GroupBy and ToLookup give you groups keyed by something, but the execution model and type are different.
- New section **Left and right join LINQ extension methods**: SQL has multiple types of `JOIN`. LINQ has always supported the equivalent of the default join type, `INNER JOIN`. .NET 10 adds support for `LeftJoin` and `RightJoin` methods.

# Chapter 12
- New content: Microsoft makes extensive use of ASP.NET Core for server-side projects internally, and uses it for Microsoft 365, Xbox services, and most Azure services.
- New section **Fluent UI React**: It provides robust, accessible React-based components that are highly customizable.
- New section **Defining project properties to reuse version numbers**: You can define properties at the top of your `Directory.Packages.props` file and then reference these properties throughout the file. This approach keeps package versions consistent and makes updates easy.
- New section **Package source mapping**: If you use CPM and you have more than one package source configured for your code editor then you will see NuGet Warning NU1507. 
- Added steps to add statements to temporarily disable and then reenable the `non-nullable field must contain a non-null value when exiting constructor` warning.

# Chapter 13
- Improved the enabling of static files and assets to work better with `MapStaticAssets` in .NET 9 and later. Adding steps to view the injected scripts that are messed with when serving static HTML web pages with `MapStaticAssets`. More details are available here: https://github.com/markjprice/cs14net10/blob/main/docs/ch13-mapstaticassets.md

# Chapter 15
- New section **Documenting web services with Swagger, OpenAPI, and Swashbuckle**: Explains some terminology related to documenting web services.
- New section **A non-benefit of the Minimal API**: Explains how controller-based web API aren't as bad as some people say.
- Simplified the implementation of the web service by removing the repository pattern implementation.
- New section **Validation support in Minimal API web services**: With .NET 10 and later, Minimal API web services now support validation of data sent in requests to your API endpoints. 
- New sections **Clearing Chrome’s address bar autocomplete** and **Designing for case sensitivity**
- New section **Reviewing and customizing the OpenAPI document**: With .NET 10, ASP.NET Core added support for generating OpenAPI version 3.1 documents. OpenAPI
3.1 is a significant update to OAS.
- New section **Generating OpenAPI documents in YAML format**
- New section **Populating XML documentation comments into the OpenAPI document**
- New section **Implementing Scalar for documentation**: Add a modern third-party package to provide a user interface to try out a web service.
