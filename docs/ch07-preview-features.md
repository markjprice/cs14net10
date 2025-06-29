**Working with preview features**

It is a challenge for Microsoft to deliver some new features that have cross-cutting effects across many parts of .NET, like the runtime, language compilers, and API libraries. It is the classic chicken and egg problem. What do you do first?

From a practical perspective, it means that although Microsoft might have completed most of the work needed for a feature, the whole thing might not be ready until very late in their now annual cycle of .NET releases, which is too late for proper testing in “the wild.”

So from .NET 6 onward, Microsoft includes preview features in general availability (GA) releases. Developers can opt into these preview features and provide Microsoft with feedback. In a later GA release, they can be enabled for everyone.

It is important to note that this topic is about preview features. This is different from a preview version of .NET or Visual Studio. Microsoft releases preview versions of Visual Studio and .NET while developing them to get feedback from developers, and then they do a final GA release. With GA, the feature is available for everyone. Before GA, the only way to get the new functionality was to install a preview version. Preview features are different because they are installed with GA releases and must be optionally enabled.

# C# compilers as a preview feature

For example, when Microsoft released .NET SDK 6.0.200 in February 2022, it included the C# 11 compiler as a preview feature. This meant that .NET 6 developers could optionally set the language version to preview and then start exploring C# 11 features, like raw string literals and the `required` keyword.

Once .NET SDK 7.0.100 was released in November 2022, any .NET 6 developer who wanted to continue to use the C# 11 compiler then needed to use the .NET 7 SDK for their .NET 6 projects and set the target framework to `net6.0`, with a `<LangVersion>` set to `11`. This way, they use the supported .NET 7 SDK with the supported C# 11 compiler to build .NET 6 projects.

In November 2026, Microsoft is likely to release .NET 11 SDK with a C# 15 compiler. You can then install and use the .NET 11 SDK to gain the benefits of whatever new features are available in C# 15, while still targeting .NET 10, as shown highlighted in the following Project file:
```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <LangVersion>15</LangVersion> <!--Requires .NET 11 SDK GA-->
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>
```

> **Good Practice**: Preview features are not supported in production code. Preview features are likely to have breaking changes before the final release. Enable preview features at your own risk. Switch to a GA-release future SDK like .NET 11 to use new compiler features, while still targeting older but LTS versions of .NET like .NET 8 or 10.

# Requiring preview features

The `[RequiresPreviewFeatures]` attribute is used to indicate assemblies, types, or members that use, and, therefore, require warnings about, preview features. A code analyzer can scan for this attribute and then generate warnings if needed. If your code does not use any preview features, you will not see any warnings. If your code does use any preview features, then you will see warnings. Your code should also be decorated with this attribute to warn other developers that your code uses preview features.

# Enabling preview features

In the project file, add an element to enable preview features and an element to enable preview language features, as shown highlighted in the following markup:
```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
    <EnablePreviewFeatures>true</EnablePreviewFeatures>
    <LangVersion>preview</LangVersion>
  </PropertyGroup>

</Project>
```
