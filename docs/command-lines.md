**Command-Lines**

To make it easier to enter commands at the prompt, this page lists all commands as a single line that can be copied and pasted.

> Note: Page numbers will be updated once the final print files are made available to me in November 2025.

- [Chapter 1 - Hello, C#! Welcome, .NET!](#chapter-1---hello-c-welcome-net)
  - [Page 13 - Installing other extensions](#page-13---installing-other-extensions)
  - [Page 18 - Listing and removing versions of .NET](#page-18---listing-and-removing-versions-of-net)
  - [Page 26 - Understanding top-level programs](#page-26---understanding-top-level-programs)
  - [Page 34 - Cloning the book solution code repository](#page-34---cloning-the-book-solution-code-repository)
  - [Page 36 - Converting a file-based app to a project-based app](#page-36---converting-a-file-based-app-to-a-project-based-app)
  - [Page 36 - Publishing a file-based app](#page-36---publishing-a-file-based-app)
- [Chapter 2 - Speaking C#](#chapter-2---speaking-c)
  - [Page 45 - How to output the SDK version](#page-45---how-to-output-the-sdk-version)
  - [Page 92 - Exploring more about console apps](#page-92---exploring-more-about-console-apps)
  - [Page 104 - Passing arguments to a console app](#page-104---passing-arguments-to-a-console-app)
  - [Page 106 - Passing arguments to a console app](#page-106---passing-arguments-to-a-console-app)
  - [Page 108 - Passing arguments to a console app](#page-108---passing-arguments-to-a-console-app)
- [Chapter 4 - Writing, Debugging, and Testing Functions](#chapter-4---writing-debugging-and-testing-functions)
  - [Page 202 - Creating a class library that needs testing](#page-202---creating-a-class-library-that-needs-testing)
- [Chapter 7 - Packaging and Distributing .NET Types](#chapter-7---packaging-and-distributing-net-types)
  - [Page 359 - Checking your .NET SDKs for updates](#page-359---checking-your-net-sdks-for-updates)
  - [Page 372 - Creating a .NET Standard 2.0 class library](#page-372---creating-a-net-standard-20-class-library)
  - [Page 373 - Controlling the .NET SDK](#page-373---controlling-the-net-sdk)
  - [Page 378 - Understanding dotnet commands](#page-378---understanding-dotnet-commands)
  - [Page 379 - Getting information about .NET and its environment](#page-379---getting-information-about-net-and-its-environment)
  - [Page 381 - Setting project properties at the command line](#page-381---setting-project-properties-at-the-command-line)
  - [Page 382 - Publishing a self-contained app](#page-382---publishing-a-self-contained-app)
  - [Page 384 - Publishing a single-file app](#page-384---publishing-a-single-file-app)
  - [Page 385 - Reducing the size of apps using app trimming](#page-385---reducing-the-size-of-apps-using-app-trimming)
  - [Page 386 - Controlling where build artifacts are created](#page-386---controlling-where-build-artifacts-are-created)
  - [Page 390 - Publishing a native AOT project](#page-390---publishing-a-native-aot-project)
- [Chapter 10 - Working with Data Using Entity Framework Core](#chapter-10---working-with-data-using-entity-framework-core)
  - [Page 518 - Setting up SQLite CLI tools for Windows](#page-518---setting-up-sqlite-cli-tools-for-windows)
  - [Page 518 - Setting up SQLite for macOS and Linux](#page-518---setting-up-sqlite-for-macos-and-linux)
  - [Page 519 - Creating the Northwind sample database for SQLite](#page-519---creating-the-northwind-sample-database-for-sqlite)
  - [Page 535 - Setting up the dotnet-ef tool](#page-535---setting-up-the-dotnet-ef-tool)
  - [Page 538 - Scaffolding models using an existing database](#page-538---scaffolding-models-using-an-existing-database)
- [Chapter 11 - Querying and Manipulating Data Using LINQ](#chapter-11---querying-and-manipulating-data-using-linq)
  - [Page 587 - Creating a console app for exploring LINQ to Entities](#page-587---creating-a-console-app-for-exploring-linq-to-entities)
- [Chapter 12 - Introducing Modern Web Development Using .NET](#chapter-12---introducing-modern-web-development-using-net)
  - [Page 622 - Defining project properties to reuse version numbers](#page-622---defining-project-properties-to-reuse-version-numbers)
  - [Page 629 - Creating a class library for entity models using SQLite](#page-629---creating-a-class-library-for-entity-models-using-sqlite)
- [Chapter 13 - Building Websites Using ASP.NET Core](#chapter-13---building-websites-using-aspnet-core)
  - [Page 651 - Creating an empty ASP.NET Core project](#page-651---creating-an-empty-aspnet-core-project)
  - [Page 656 - Testing and securing the website](#page-656---testing-and-securing-the-website)
- [Chapter 14 - Interactive Web Components Using Blazor](#chapter-14---interactive-web-components-using-blazor)
  - [Page 690 - Creating a Blazor Web App project](#page-690---creating-a-blazor-web-app-project)
- [Chapter 15 - Building and Consuming Web Services](#chapter-15---building-and-consuming-web-services)
  - [Page 738 - Creating an ASP.NET Core Minimal API project](#page-738---creating-an-aspnet-core-minimal-api-project)

# Chapter 1 - Hello, C#! Welcome, .NET!

## Page 13 - Installing other extensions

```shell
code --install-extension ms-dotnettools.csdevkit
```

## Page 18 - Listing and removing versions of .NET

Listing all installed .NET SDKS:
```shell
dotnet --list-sdks
```

Listing all installed .NET runtimes:
```shell
dotnet --list-runtimes
```

Details of all .NET installations:
```shell
dotnet --info
```

## Page 26 - Understanding top-level programs

If you are using the dotnet CLI at the command prompt, add a switch to generate a console app project using the legacy `Program` class with a `Main` method:
```shell
dotnet new console --use-program-main
```

## Page 34 - Cloning the book solution code repository

```shell
git clone https://github.com/markjprice/cs14net10.git
```

## Page 36 - Converting a file-based app to a project-based app

Converting a file-based app to a project-based app:
```shell
dotnet project convert app.cs
```

## Page 36 - Publishing a file-based app

Publishing a file-based app:
```shell
dotnet publish app.cs
```

# Chapter 2 - Speaking C#

## Page 45 - How to output the SDK version

Output the current version of the .NET SDK:
```shell
dotnet --version
```

## Page 92 - Exploring more about console apps

Example of a command line with multiple arguments:
```shell
dotnet new console -lang "F#" --name "ExploringConsole"
```

## Page 104 - Passing arguments to a console app

With the `dotnet` command-line tool, you can pass the name of a new project template, as shown in the following commands:
```
dotnet new console
dotnet new mvc
```

## Page 106 - Passing arguments to a console app

Passing four arguments when running your project:
```shell
dotnet run firstarg second-arg third:arg "fourth arg"
```

## Page 108 - Passing arguments to a console app

Setting options using arguments:
```shell
dotnet run red yellow 50
```

# Chapter 4 - Writing, Debugging, and Testing Functions

## Page 202 - Creating a class library that needs testing

Creating a class library project and adding it to the solution file:
```shell
dotnet new classlib -o CalculatorLib
```

```shell
dotnet sln add CalculatorLib
```

Creating an XUnit text project and adding it to the solution file:
```shell
dotnet new xunit -o CalculatorLibUnitTests
```
```shell
dotnet sln add CalculatorLibUnitTests
```

Running a unit test project:
```shell
dotnet test
```

# Chapter 7 - Packaging and Distributing .NET Types

## Page 359 - Checking your .NET SDKs for updates

Listing the installed .NET SDKs with a column to indicate if it has a newer version that can be upgraded to:
```shell
dotnet sdk check
```

## Page 372 - Creating a .NET Standard 2.0 class library

Creating a new class library project that targets .NET Standard 2.0:
```shell
dotnet new classlib -f netstandard2.0
```

## Page 373 - Controlling the .NET SDK

Listing the installed .NET SDKs:
```shell
dotnet --list-sdks
```

Creating a `global.json` file to control to default .NET SDK for projects created in the current folder and its descendents:
```shell
dotnet new globaljson --sdk-version 8.0.410
```

Creating a class library project:
```shell
dotnet new classlib
```

## Page 378 - Understanding dotnet commands

Listing available project templates using .NET 7 or later:
```shell
dotnet new list
```

Listing available project templates using .NET 6 or earlier:
```shell
dotnet new --list
```

Listing available project templates using .NET 6 or earlier (short form):
```shell
dotnet new -l
```

## Page 379 - Getting information about .NET and its environment

To see what .NET SDKs and runtimes are currently installed, alongside information about the OS:
```shell
dotnet --info
```

## Page 381 - Setting project properties at the command line

```shell
dotnet <command> -p:<PropertyName>=<Value>
```

```shell
dotnet build -p:TargetFramework=net6.0
```

```shell
dotnet publish -p:PublishDir=./custom_output/
```

```shell
dotnet run -p:DefineConstants=DEBUG
```

```shell
dotnet build -p:BuildInParallel=false
```

```shell
dotnet build -p:Configuration=Release -p:Version=1.0.0
```

## Page 382 - Publishing a self-contained app

Build and publish the release version for Windows:
```shell
dotnet publish -c Release -r win-x64 --self-contained
```

Build and publish the release version for Windows on ARM64:
```shell
dotnet publish -c Release -r win-arm64 --self-contained
```

Build and publish the release version for macOS on Apple Silicon:
```shell
dotnet publish -c Release -r osx-arm64 --self-contained
```

Build and publish the release version for Linux on Intel:
```shell
dotnet publish -c Release -r linux-x64 --self-contained
```

## Page 384 - Publishing a single-file app

```shell
dotnet publish -c Release -r win-x64 --no-self-contained -p:PublishSingleFile=true
```

```shell
dotnet publish -c Release -r win-x64 --self-contained -p:PublishSingleFile=true
```

## Page 385 - Reducing the size of apps using app trimming

```shell
dotnet publish -c Release -r win-x64 --self-contained -p:PublishSingleFile=true -p:PublishTrimmed=True
```

```shell
dotnet publish -c Release -r win-x64 --self-contained -p:PublishSingleFile=true -p:PublishTrimmed=True -p:TrimMode=Link
```

## Page 386 - Controlling where build artifacts are created

To create a MSBuild `Directory.Build.props` file:
```shell
dotnet new buildprops --use-artifacts
```

## Page 390 - Publishing a native AOT project

```shell
dotnet publish
```

# Chapter 10 - Working with Data Using Entity Framework Core

## Page 518 - Setting up SQLite CLI tools for Windows

To confirm that the path to SQLite has been configured correctly, at any command prompt or terminal, enter the following command to start SQLite:
```shell
sqlite3
```

## Page 518 - Setting up SQLite for macOS and Linux

On Linux, you can get set up with SQLite using the following command:
```shell
sudo apt-get install sqlite3
```

## Page 519 - Creating the Northwind sample database for SQLite

Creating the Northwind SQLite database:
```shell
sqlite3 Northwind.db -init Northwind4SQLite.sql
```

## Page 535 - Setting up the dotnet-ef tool

Listing installed `dotnet` global tools:
```shell
dotnet tool list --global
```

Updating an older `dotnet-ef` tool:
```shell
dotnet tool update --global dotnet-ef
```

Installing the latest `dotnet-ef` as a global tool:
```shell
dotnet tool install --global dotnet-ef
```

Updating to a specific version of `dotnet-ef` tool like the latest EF Core 11 preview after February 2026:
```shell
dotnet tool update --global dotnet-ef --version 11.0-*
```

Uninstalling an older `dotnet-ef` tool:
```shell
dotnet tool uninstall --global dotnet-ef
```

## Page 538 - Scaffolding models using an existing database

```shell
dotnet ef dbcontext scaffold "Data Source=Northwind.db" Microsoft.EntityFrameworkCore.Sqlite --table Categories --table Products --output-dir AutoGenModels --namespace WorkingWithEFCore.AutoGen --data-annotations --context NorthwindDb
```

Note the following:
- The command action: `dbcontext scaffold`
- The connection string: `"Data Source=Northwind.db"`
- The database provider: `Microsoft.EntityFrameworkCore.Sqlite`
- The tables to generate models for: `--table Categories --table Products`
- The output folder: `--output-dir AutoGenModels`
- The namespace: `--namespace WorkingWithEFCore.AutoGen`
- To use data annotations as well as the Fluent API: `--data-annotations`
- To rename the context from [database_name]Context: `--context NorthwindDb`

# Chapter 11 - Querying and Manipulating Data Using LINQ

## Page 587 - Creating a console app for exploring LINQ to Entities

Creating the Northwind SQLite database:
```shell
sqlite3 Northwind.db -init Northwind4Sqlite.sql
```

# Chapter 12 - Introducing Modern Web Development Using .NET

## Page 622 - Defining project properties to reuse version numbers

To update a project after changing package versions:
```shell
dotnet restore
```

To create a new file named `Directory.Packages.props`:
```shell
dotnet new packagesprops
```

## Page 629 - Creating a class library for entity models using SQLite

Creating the Northwind SQLite database:
```shell
sqlite3 Northwind.db -init Northwind4SQLite.sql
```

Changing to the project folder:
```shell
cd Northwind.EntityModels.Sqlite
```

Creating the EF Core model for the Northwind database:
```shell
dotnet ef dbcontext scaffold "Data Source=../Northwind.db" Microsoft.EntityFrameworkCore.Sqlite --namespace Northwind.EntityModels --data-annotations
```

# Chapter 13 - Building Websites Using ASP.NET Core

## Page 651 - Creating an empty ASP.NET Core project

To create a new empty ASP.NET Core project:
```shell
dotnet new web
```

## Page 656 - Testing and securing the website

Starting an ASP.NET Core project and specifying the `https` profile:
```shell
dotnet run --launch-profile https
```

# Chapter 14 - Interactive Web Components Using Blazor

## Page 690 - Creating a Blazor Web App project

Creating a new project using the **Blazor Web App** template with server-side or client-side interactivity enabled:
```shell
dotnet new blazor --interactivity Auto -o Northwind.Blazor
```
# Chapter 15 - Building and Consuming Web Services

## Page 738 - Creating an ASP.NET Core Minimal API project

Creating a Web API project using ASP.NET Core Minimal API:
```shell
dotnet new webapi -o Northwind.WebApi
```

Creating a Web API project using Minimal API (explicitly):
```shell
dotnet new webapi --use-minimal-api -o Northwind.WebApi
```

Creating a Web API project using Minimal APIs (explicitly, short form):
```shell
dotnet new webapi -minimal -o Northwind.WebApi
```

Creating a Web API project using controllers:
```shell
dotnet new webapi --use-controllers -o Northwind.WebApi
```

Creating a Web API project using controllers (short form):
```shell
dotnet new webapi -controllers -o Northwind.WebApi
```

