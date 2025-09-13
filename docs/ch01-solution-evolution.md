**Solution Evolution - `.sln`, `.slnx`, and `.slnf`**

- [Solution Files `.sln`](#solution-files-sln)
- [XML Solution Files `.slnx`](#xml-solution-files-slnx)
- [Visual Studio support for XML Solution Files](#visual-studio-support-for-xml-solution-files)
- [Other tool support for XML Solution Files](#other-tool-support-for-xml-solution-files)
- [Solution Filter Files `.slnf`](#solution-filter-files-slnf)

# Solution Files `.sln`

Visual Studio allows multiple projects to be grouped and opened together using a solution file `.sln`. The format of this file is a custom plain text file. In *Chapter 1*, the reader creates a solution file that references two projects. If the reader opens the solution file, it would look like the following:
```
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio Version 17
VisualStudioVersion = 17.14.35906.104
MinimumVisualStudioVersion = 10.0.40219.1
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "HelloCS", "HelloCS\HelloCS.csproj", "{3C6C0D9B-6823-1380-8FCF-FBF0821511A6}"
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "AboutMyEnvironment", "AboutMyEnvironment\AboutMyEnvironment.csproj", "{3F7A8DB0-B156-11EA-3DD5-F4C79E02563B}"
EndProject
Global
    GlobalSection(SolutionConfigurationPlatforms) = preSolution
        Debug|Any CPU = Debug|Any CPU
        Release|Any CPU = Release|Any CPU
    EndGlobalSection
    GlobalSection(ProjectConfigurationPlatforms) = postSolution
        {3C6C0D9B-6823-1380-8FCF-FBF0821511A6}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
        {3C6C0D9B-6823-1380-8FCF-FBF0821511A6}.Debug|Any CPU.Build.0 = Debug|Any CPU
        {3C6C0D9B-6823-1380-8FCF-FBF0821511A6}.Release|Any CPU.ActiveCfg = Release|Any CPU
        {3C6C0D9B-6823-1380-8FCF-FBF0821511A6}.Release|Any CPU.Build.0 = Release|Any CPU
        {3F7A8DB0-B156-11EA-3DD5-F4C79E02563B}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
        {3F7A8DB0-B156-11EA-3DD5-F4C79E02563B}.Debug|Any CPU.Build.0 = Debug|Any CPU
        {3F7A8DB0-B156-11EA-3DD5-F4C79E02563B}.Release|Any CPU.ActiveCfg = Release|Any CPU
        {3F7A8DB0-B156-11EA-3DD5-F4C79E02563B}.Release|Any CPU.Build.0 = Release|Any CPU
    EndGlobalSection
    GlobalSection(SolutionProperties) = preSolution
        HideSolutionNode = FALSE
    EndGlobalSection
    GlobalSection(ExtensibilityGlobals) = postSolution
        SolutionGuid = {81C51CB3-C3BC-4812-84B4-E0C19A2B9EA5}
    EndGlobalSection
EndGlobal
```

This is complex and almost impossible to edit manually due to the GUIDs. 

# XML Solution Files `.slnx`

A modern replacement syntax is currently in preview, uses XML, and has the `.slnx` file extension. The preceding file would look like the following markup:
```xml
<Solution>
  <Project Path="AboutMyEnvironment/AboutMyEnvironment.csproj" />
  <Project Path="HelloCS/HelloCS.csproj" />
</Solution>
```

This is much easier to work with, especially with Git because merge conflicts can be reviewed easier.

> **More Information**: Learn more at the following link: https://devblogs.microsoft.com/visualstudio/new-simpler-solution-file-format/.

# Visual Studio support for XML Solution Files

To use the new XML solution format in Visual Studio, enable the feature in **Options**, as shown in the following screenshot:

![Enabling .slnx format in Visual Studio | Options](assets/slnx-options.png)

Then open an existing `.sln` solution file and save it as the new XML format, as shown in the following screenshot:

![Saving a solution using the .slnx format](assets/slnx-save-as.png)

# Other tool support for XML Solution Files

The team is working on providing support for the `.slnx` format across various tools and environments. Currently, the following tools support the `.slnx` format:
- MSBuild
- `dotnet` CLI
- C# Dev Kit for VS Code
- JetBrains Rider

> **Warning!** Although you can have both solution file formats in the same directory, it is recommended to only use one or the other to avoid confusing the build tools and other humans.

> **Note**: This new **XML Solution File** format is still in preview at the time of writing in March 2025. It is likely to officially leave preview and reach general availability status in May 2025 or November 2025.

# Solution Filter Files `.slnf`

To improve performance when opening large solutions, Visual Studio 2019 introduced solution filtering. Solution filtering lets you open a solution with only selective projects loaded. Loading a subset of projects in a solution decreases solution load, build, and test run time, and enables more focused review.

> **Note**: Although solution filtering is not a new feature, I have not covered it in previous editions of my books. I plan to cover it in all my .NET 10 editions, in more depth in the *Fundamentals* book, and briefly in the other books with a reference to an online article about it for more details. 

Solution filter files are JSON files with the extension `.slnf` that indicate which projects to build or load from all the projects in a solution. Starting with MSBuild 16.7, you can invoke MSBuild on the solution filter file to build the solution with filtering enabled.

> **Warning!** The solution filter file reduces the set of projects that will be loaded or built and simplifies the format. The solution file is still required.

For example, in *Chapter 3*, the reader creates six projects during the tasks in that chapter, and optionally four exercises at the end of the chapter. The solution file references all ten projects. I also include two solution filters, one for tasks and one for exercises. 

[`Chapter03-Tasks.slnf`](https://github.com/markjprice/cs14net10/blob/main/code/Chapter03/Chapter03-Tasks.slnf) looks like the following JSON:
```json
{
  "solution": {
    "path": "Chapter03.sln",
    "projects": [
      "Arrays\\Arrays.csproj",
      "CastingConverting\\CastingConverting.csproj",
      "HandlingExceptions\\HandlingExceptions.csproj",
      "IterationStatements\\IterationStatements.csproj",
      "Operators\\Operators.csproj",
      "SelectionStatements\\SelectionStatements.csproj"
    ]
  }
}
```

[`Chapter03-Exercises.slnf`](https://github.com/markjprice/cs14net10/blob/main/code/Chapter03/Chapter03-Exercises.slnf) looks like the following JSON:
```json
{
  "solution": {
    "path": "Chapter03.sln",
    "projects": [
      "Exercise_Exceptions\\Exercise_Exceptions.csproj",
      "Exercise_FizzBuzz\\Exercise_FizzBuzz.csproj",
      "Exercise_LoopsAndOverflow\\Exercise_LoopsAndOverflow.csproj",
      "Exercise_Operators\\Exercise_Operators.csproj"
    ]
  }
}
```

> **Warning!** Solution filter files are tied to a specific solution file. If you migrate your solution from `.sln` to `.slnx` then you’ll need to update the filter file to reference the new `.slnx` file, otherwise it will still try to open the old `.sln` file.

Learn more about solution filters at the following links:
- [Filtered solutions in Visual Studio](https://learn.microsoft.com/en-us/visualstudio/ide/filtered-solutions)
- [Solution filters in MSBuild](https://learn.microsoft.com/en-us/visualstudio/msbuild/solution-filters)
- [JetBrains Rider - Work with solution filters](https://www.jetbrains.com/help/rider/Solution_filters.html)
