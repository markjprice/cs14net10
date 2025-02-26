**Tenth Edition's support for .NET 11 and .NET 12**

- [.NET 11 downloads and announcements](#net-11-downloads-and-announcements)
- [How to switch from .NET 10 to .NET 11](#how-to-switch-from-net-10-to-net-11)
  - [Upgrading the target framework for a project](#upgrading-the-target-framework-for-a-project)
  - [Upgrading packages for a project](#upgrading-packages-for-a-project)
- [What's New in .NET 11 and where will I cover those new features?](#whats-new-in-net-11-and-where-will-i-cover-those-new-features)
- [.NET 12 downloads and announcements](#net-12-downloads-and-announcements)

# .NET 11 downloads and announcements

Microsoft will release previews of .NET 11 regularly starting in February 2026 until the general availability (GA) version on Tuesday, November 12, 2026.

- [Download .NET 11.0 SDK](https://dotnet.microsoft.com/download/dotnet/11.0)
- .NET 11 Release Index
- February 2026: .NET 11 Preview 1
- March 2026: .NET 11 Preview 2
- April 2026: .NET 11 Preview 3
- May 2026: .NET 11 Preview 4
- June 2026: .NET 11 Preview 5
- July 2026: .NET 11 Preview 6
- August 2026: .NET 11 Preview 7
- September 2026: .NET 11 Release Candidate 1
- October 2026: .NET 11 Release Candidate 2
- November 2026: .NET 11.0 GA (general availability)

# How to switch from .NET 10 to .NET 11

After [downloading](https://dotnet.microsoft.com/download/dotnet/11.0) and installing .NET 11.0 SDK, follow the step-by-step instructions in the book and they should work as expected since the project file will automatically reference .NET 11.0 as the target framework. 

## Upgrading the target framework for a project

To upgrade a project in the GitHub repository from .NET 10.0 to .NET 11.0 often only requires a target framework change in your project file.

Change this:

```xml
<TargetFramework>net10.0</TargetFramework>
```

To this:

```xml
<TargetFramework>net11.0</TargetFramework>
```

> **Warning!** Sometimes it is better to recreate a project because the project template and APIs may have changed and only changing the target framework is not enough. This is especially true for third-party project templates like Umbraco CMS.

## Upgrading packages for a project

For projects that reference additional NuGet packages, use the latest NuGet package version instead of the version given in the book. For example, you might reference a package, as shown in the following markup:
```xml
<ItemGroup>
  <PackageReference
    Include="Microsoft.Extensions.Configuration.Binder"
    Version="10.0.0" />
</ItemGroup>
```

To use .NET 11 Preview 1 packages, search https://www.nuget.org for the package and find its latest preview version number. For example, for Preview 1, as shown in the following markup:
```xml
<ItemGroup>
  <PackageReference
    Include="Microsoft.Extensions.Configuration.Binder"
    Version="11.0.0-preview.1.14128.5" />
</ItemGroup>
```

To always use latest .NET 11 preview, release candidate, or patch version package, use a version number wildcard, as shown in the following markup:
```xml
<ItemGroup>
  <PackageReference
    Include="Microsoft.Extensions.Configuration.Binder"
    Version="11.0-*" />
</ItemGroup>
```

> You can search for the correct NuGet package version numbers yourself at the following link: https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Binder#versions-body-tab.

# What's New in .NET 11 and where will I cover those new features?

Official page: https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-11/overview

Preview updates: https://github.com/dotnet/core/discussions

# .NET 12 downloads and announcements

Microsoft will release previews of .NET 12 regularly starting in February 2027 until the final version on Tuesday, November 12, 2027.

- [Download .NET 12.0 SDK](https://dotnet.microsoft.com/download/dotnet/12.0). **Warning!** This link will not activate until February 2027.
