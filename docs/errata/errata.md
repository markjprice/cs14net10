**Errata** (11 items)

If you find any mistakes, then please [raise an issue in this repository](https://github.com/markjprice/cs14net10/issues) or email me at markjprice (at) gmail.com.

> **Warning!** Avoid copying and pasting links that break over multiple lines and include hyphens or dashes because your PDF reader might remove a hyphen thinking that it being helpful but break the link! Just click on the links and they will work. Or carefully check that your PDF reader has not removed a hyphen after pasting into your web browser address bar. [See an example of this issue here](https://github.com/markjprice/cs13net9/issues/77).

- [Online docs](#online-docs)
- [Page 70 - Raw string literals](#page-70---raw-string-literals)
- [Page 71 - Raw string literals](#page-71---raw-string-literals)
- [Page 84 - Storing dynamic types](#page-84---storing-dynamic-types)
- [Page 103 - Getting key input from the user](#page-103---getting-key-input-from-the-user)
- [Page 317 - Comparing objects when sorting](#page-317---comparing-objects-when-sorting)
- [Page 515 - Understanding Entity Framework Core](#page-515---understanding-entity-framework-core)
- [Page 521 - Managing the Northwind sample database with SQLiteStudio, Page 628 - Creating the Northwind database](#page-521---managing-the-northwind-sample-database-with-sqlitestudio-page-628---creating-the-northwind-database)
- [Page 677 - Using shared layouts with Blazor static SSR pages](#page-677---using-shared-layouts-with-blazor-static-ssr-pages)
- [Page 710 - Abstracting a service for a Blazor component](#page-710---abstracting-a-service-for-a-blazor-component)
- [Appendix B - Setting Up Your Development Environment](#appendix-b---setting-up-your-development-environment)
  - [Page 833 - Creating the Northwind sample database locally](#page-833---creating-the-northwind-sample-database-locally)

# Online docs

> Thanks to [Donald Maisey](https://github.com/donaldmaisey) for raising [this issue on January 12, 2026](https://github.com/markjprice/cs14net10/issues/12).

The link to an online topic about async/await was moved in the book from Chapter 2 to Chapter 4, but the online files and link were not. These have now been moved to where they should be. Also, some links to online topics were missing from the docs `README.md` file. These have now been added.

# Page 70 - Raw string literals

> Thanks to [Paul Marangoni](https://github.com/pmarangoni) for raising [this issue on November 19, 2025](https://github.com/markjprice/cs14net10/issues/1).

In the book, the following example is wrong:

![Wrong indentation for final quotes](page70-bad.png)

It should be:

![Correct indentation for final quotes](page70-good.png)

# Page 71 - Raw string literals

> Thanks to [mushobeti](https://github.com/mushobeti) for raising [this issue on November 29, 2025](https://github.com/markjprice/cs14net10/issues/2).

The following code example mistakenly indents the last three-quotes by one space:
```cs
string json = $$"""
{
  "first_name": "{{person.FirstName}}",
  "age": {{person.Age}},
  "calculation": "{{ 1 + 2 }}"
}
 """;
```

This causes the compiler to give `Error CS8999: Line does not start with the same whitespace as the closing line of the raw string literal.`

To fix this error, delete the extra space at the start of the last statement, as shown in the following code:
```cs
string json = $$"""
{
  "first_name": "{{person.FirstName}}",
  "age": {{person.Age}},
  "calculation": "{{ 1 + 2 }}"
}
""";
```

This code example was correct in earlier editions so must have been accidently introduced during the editing process. I apologize for missing it.

# Page 84 - Storing dynamic types

> Thanks to [iheartdotnet](https://github.com/iheartdotnet) for raising [this issue on August 2, 2025](https://github.com/markjprice/cs13net9/issues/61) and to [Chris Alberty](https://github.com/calberty) for noticing that I had missed fixing it in the 10th edition.

In the last paragraph of this section, I wrote, "Dynamic types are most useful when interoperating with non-.NET systems. For example, you might need to work with a class library written in F#, Python, or some JavaScript. You might also need to interop with technologies like the Component Object Model (COM), for example, when automating Excel or Word."

I included F# in the list of languages after giving the example of `dynamic` being useful when interoperating with non-.NET systems. This accidently implies that F# is not a .NET language when it is. In the next edition, I will change "non-.NET systems" to "other .NET languages and non-.NET systems".

# Page 103 - Getting key input from the user

> Thanks to [mushobeti](https://github.com/mushobeti) for raising [this issue on November 30, 2025](https://github.com/markjprice/cs14net10/issues/3).

In Steps 2 and 4, the output of the `Modifiers` should be `None` instead of `0`. To output the integer value of the `Modifiers` enum, we would use `arg2: (int)key.Modifiers`.

# Page 317 - Comparing objects when sorting

> Thanks to [Nick Johnston](https://github.com/nick-johnston) for raising [this issue on December 27, 2025](https://github.com/markjprice/cs14net10/issues/8).

In Step 5, I wrote, "In `Person.cs`, after inheriting from `object`, add a comma and enter `IComparable<Person?>`,"

Inheriting from `object` was shown in Chapter 5. I should have written, "In `Person.cs`, after `Person`, enter `: IComparable<Person?>`," and the code highlighting should include the colon. 

# Page 515 - Understanding Entity Framework Core

On February 10, 2026, the EF Core team published packages for EF Core 11 Preview 1, and a page for what's new: https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-11.0/whatsnew

It includes an important note: "EF11 requires the .NET 11 SDK to build and requires the .NET 11 runtime to run. EF11 will not run on earlier .NET versions, and will not run on .NET Framework."

In my book, I wrote: "EF Core 10 targets .NET 10 or later, and EF Core 11 will also target .NET 10 because the EF Core team wants as many developers as possible to benefit from new features in future releases, even if you must target only long-term support releases of .NET. This means that you can use all the new features of EF Core 11 with either .NET 10 or .NET 11."

In the past, the EF Core team often targeted the latest LTS .NET so you could adopt the new EF Core STS version without moving your whole app runtime. Microsoft’s own “Supported .NET implementations” page even states that as the general approach: “In general, we target the latest LTS release of .NET… There may be exceptions… as runtime features sometimes get added that require us to depend on the latest version of .NET.” From: https://learn.microsoft.com/en-us/ef/core/miscellaneous/platforms

But EF Core 11 is now explicitly saying that it requires the .NET 11 SDK to build and the .NET 11 runtime to run, and it won’t run on earlier .NET versions.

Why? The EF team’s own platform guidance acknowledges that sometimes they must depend on the latest .NET due to runtime features. In practice, “won’t run on earlier .NET” usually means they’re compiling against and taking dependencies on assemblies/APIs that simply are not present (or not the same versions) on earlier runtimes, and the team has decided not to carry the extra compatibility shims or multi-targeting.

Net result: EF Core 11 only running on .NET 11 is the documented requirement. If you want to stay on .NET 10 LTS, EF Core 10 is the ceiling. If you move to .NET 11 (STS), EF Core 11 becomes available.

# Page 521 - Managing the Northwind sample database with SQLiteStudio, Page 628 - Creating the Northwind database

> Thanks to [Amar Jamal](https://github.com/amarjamal) for raising [this issue on November 4, 2025](https://github.com/markjprice/cs13net9/issues/80).

On page 521, in Step 6, I wrote, "You will see the 10 tables..." but there are only 8 tables. For many editions there were 10, but recently I simplified the script to only create 8 tables by removing the unneeded `Territories` and `EmployeeTerritories` tables. 

On page 628, I wrote, "The script for SQLite is a simplified version that only creates 10 tables..." Again, this should be 8 tables. 

# Page 677 - Using shared layouts with Blazor static SSR pages

> Thanks to [Amar Jamal](https://github.com/amarjamal) for raising [this issue on November 19, 2025](https://github.com/markjprice/cs13net9/issues/83).

In Step 3, the markup includes the following to link to the **Suppliers** page:
```html
<NavLink class="nav-link" href="suppliers">
  Suppliers
</NavLink>
```

To prevent broken links, it would be better to use a forward-slash `/` prefix for the `href`, as shown in the following link:
```html
<NavLink class="nav-link" href="/suppliers">
  Suppliers
</NavLink>
```

The same applies when you add a link for the **Customers** page in *Exercise 13.2*.

# Page 710 - Abstracting a service for a Blazor component

> Thanks to [Amar Jamal](https://github.com/amarjamal) for raising [this issue on December 3, 2025](https://github.com/markjprice/cs13net9/issues/88).

In Step 6, the existing reference to the data context project starts the path with `..\` when it should be `..\..\`, as shown in the following markup:
```xml
<ProjectReference Include="..\..\Northwind.DataContext.Sqlite\Northwind.DataContext.Sqlite.csproj" />
```

# Appendix B - Setting Up Your Development Environment

## Page 833 - Creating the Northwind sample database locally

> Thanks to José Luis García for emailing me about this on November 16, 2025.

In Step 7, `Northwind4SQLServer.sql` should be `Northwind4SqlServerLocal.sql`.
