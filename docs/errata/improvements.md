**Improvements** (13 items)

If you have suggestions for improvements, then please [raise an issue in this repository](https://github.com/markjprice/cs14net10/issues) or email me at markjprice (at) gmail.com.

- [Page 26 - Implicitly imported namespaces](#page-26---implicitly-imported-namespaces)
- [Page 98 - Custom number formatting](#page-98---custom-number-formatting)
- [Page 119 - Null-conditional assignment operator](#page-119---null-conditional-assignment-operator)
- [Page 221 - Creating a class library](#page-221---creating-a-class-library)
- [Page 267 - Controlling how parameters are passed](#page-267---controlling-how-parameters-are-passed)
- [Page 419 - Joining, formatting, and other string members](#page-419---joining-formatting-and-other-string-members)
- [Page 472 - Managing paths](#page-472---managing-paths)
- [Page 507 - Controlling JSON processing](#page-507---controlling-json-processing)
- [Page 523 - Choosing an EF Core database provider](#page-523---choosing-an-ef-core-database-provider)
- [Page 640 - Improving the class-to-table mapping](#page-640---improving-the-class-to-table-mapping)
- [Page 697 - Reviewing Blazor routing, layouts, and navigation](#page-697---reviewing-blazor-routing-layouts-and-navigation)
- [Page 737 - Creating an ASP.NET Core Minimal API project](#page-737---creating-an-aspnet-core-minimal-api-project)
- [Appendix - Exercise 3.3 – Test your knowledge](#appendix---exercise-33--test-your-knowledge)

# Page 26 - Implicitly imported namespaces

> Thanks to [MertKushan](https://github.com/MertKushan) for raising [this issue on February 21, 2026](https://github.com/markjprice/cs14net10/issues/13).

In Step 1, I wrote, "In **Solution Explorer**, expand the `obj`, `Debug`, and `net10.0` folders, and open the file named
`HelloCS.GlobalUsings.g.cs`." This assumes that you are using Visual Studio 2026 because it is in the section about "Compiling and running code using Visual Studio", not in the online-only section about VS Code.

At the end of this section, at the bottom of page 30, I wrote, "When using VS Code, or more accurately, the `dotnet` CLI, it has different behavior, as you will see if you complete the optional online section about writing code with VS Code, found at the following link:
https://github.com/markjprice/cs14net10/blob/main/docs/code-editors/vscode.md."

In the next edition, I will add a note to the Visual Studio 2026 section in the print book about VS Code not showing `bin` folders in **Solution Explorer** so you need to look in the **Folders** view of **EXPLORER**.

# Page 98 - Custom number formatting

> Thanks to [Chris Alberty](https://github.com/calberty) who raised an [issue on December 19, 2025](https://github.com/markjprice/cs14net10/issues/6) that prompted this improvement.

In *Table 2.9*, all the codes are for specifying custom date and time formats using multiple characters, not single characters. So in the row for `y`, `yy`, the description is correct to say, "The year of the current century, from `0` through `99`, or with a leading zero from `00` through `99`." For example, with the custom formats, `d/M/y` or `d/M/yy`, Christmas Day this year would be formatted as `25/12/25`. But if you use the `y` code on it's own, it is not processed as a custom format, it is processed as a standard format, that outputs the month and year. Christmas Day this year would be `December 2025`. You will see a similar effect for `d`, `m`, and so on. When used in a custom format, `d` represents the day of the month, but when used as a single character, it is a standard date format meaning `dd/MM/yyyy`. 

In the next edition, I will add a warning about this subtle difference, like the one below, and add a row to *Table 2.10* for the standard format for `y`.

> **Warning!** When defining a custom format you should use multiple different characters. If you try to define a custom format with a single character, like `d` or `y`, then your format could be interpreted as a standard format, as defined in *Table 2.10*. Standard format codes take priority over custom format codes.

# Page 119 - Null-conditional assignment operator

After C# 14 was released, someone asked a question on LinkedIn: "Wasnt the null-conditional assignment operator a thing before? I mean I have been using it for a while now... Am I missing smth?" In the next edition, I will add more details to clarify.

The **null-conditional operator** `?.` (for safe reading) was introduced in C# 6. Before C# 14 you could safely read from a possibly-`null` object using `?.`, but you could not safely assign through it, as shown in the following code:

```cs
Person? p = GetPersonOrNull();

// Reading: OK with C# 6 and later.
string? maybeName = p?.Name;

// But this won't compile with C# 6 to 13.
p?.Name = "Alice";

// You have to do this before C# 14.
if (p is not null)
{
  p.Name = "Alice";
}

// With C# 14 and later, you can now safely assign with the concise syntax.
p?.Name = "Alice";
```

To summarize, previously `?.` only worked on the right side (for **null-conditional** reading). With C# 14 you can use it on the left side of an assignment (**null-conditional assignment**). 

# Page 221 - Creating a class library

> Thanks to **JSho** in the book's Discord channel who asked a question about why the class library targets .NET Standard 2.0 that prompted this improvement.

I introduce this section and the step-by-step instructions with the following: "The first task is to create a reusable .NET class library:"

In the next edition, I will add some more text: "The first task is to create a reusable .NET class library that can be used not just with .NET 10 projects but with older .NET projects like .NET Core 2.0 and later, .NET 5 and later, .NET Framework 4.7.1 and later, Mono and Xamarin:"

# Page 267 - Controlling how parameters are passed

> Thanks to [alhi44](https://github.com/alhi44) who raised an [issue on September 14, 2025](https://github.com/markjprice/cs13net9/issues/78) that prompted this improvement.

It is too late for the 10th edition in 2025, but in the 11th edition I will add an analogy about passing pieces of paper, as follows: 

When a parameter is passed into a method, it can be passed in one of several ways:

1. By **value** (this is the default): Think of these as being *in-only*. Although the value can be changed, this only affects the parameter in the method. Imagine someone has a piece of paper with a number written on it. They pass a photocopy of the paper, not the original. The function can write on the photocopy, but the original remains unchanged.
2. As an `out` parameter: Think of these as being *out-only*. `out` parameters cannot have a default value assigned in their declaration and cannot be left uninitialized. They must be set inside the method; otherwise, the compiler will give an error. Imagine someone has a blank piece of paper and asks the function to write on it. They cannot pass a piece of paper with something written on it; it *must* be blank. And the function *must* write on it before returning it.
3. By reference as a `ref` parameter: Think of these as being *in-and-out*. Like `out` parameters, `ref` parameters also cannot have default values, but since they can already be set outside the method, they do not need to be set inside the method. Imagine someone has a piece of paper with a number written on it. They pass the original piece of paper and allow the function to write on it. This means that any changes made are immediately visible to them as well as you. The paper *must* have a number written on it before it is passed.
4. As an `in` parameter: Think of these as being a reference parameter that is read-only. `in` parameters cannot have their values changed and the compiler will show an error if you try. Imagine someone has a piece of paper with a number written on it. They pass the original piece of paper and allow the function to read it but not write on it.

# Page 419 - Joining, formatting, and other string members

> Thanks to [Nick Johnston](https://github.com/nick-johnston) who raised an [issue on December 30, 2025](https://github.com/markjprice/cs14net10/issues/10) that prompted this improvement.

In *Table 8.4*, in the row for `string.IsNullOrWhiteSpace`, I will add that the method also checks for an empty string even though the method name does not specify that. A more accurate name for the method would be `string.IsNullEmptyOrWhiteSpace`. 

In the next edition, I will change the description to, "This checks whether a `string` variable is `null`, empty, or whitespace; ..."

# Page 472 - Managing paths

In Step 1, three methods (`GetDirectoryName`, `GetFileName`, and `GetExtension`) are used on the `string` variable named `textFile` that contains the value `<SpecialFolder.Personal>\OutputFiles\Dummy.txt` where `<SpecialFolder.Personal>` is your operating system's "Documents" folder or similar. 

A reader emailed to ask why the methods work when we had previous deleted the file defined by that path. They work because the methods do not need the file to exist. They look at the `string` value and extract the part of the path that you have requested.

In the next edition, I will add a paragraph to emphasize this.

# Page 507 - Controlling JSON processing

> Thanks to **TheHeLlWarrior31** / `thehellwarrior31` in the 9th edition's Discord channel for asking a question about `[JsonInclude]` that prompted this improvement item.

The book already shows an example of using the `[JsonInclude]` attribute. In the book, we change the default behavior of `System.Text.Json` only serializing properties to also include fields, and then use the attribute to exclude one field. In the 11th edition, I will add another example with explanation, as shown below.

---

By default, `System.Text.Json` only serializes and deserializes `public` properties that have a public getter and, for deserialization, usually a public setter or a usable constructor. So this works with no attributes at all:
```cs
public class Person
{
  public string Name { get; set; }
}
```

The property is `public`, so it’s included automatically.

Now look at this very common, very sensible design:
```cs
public class Person
{
  public string Name { get; private set; }

  public Person(string name)
  {
    Name = name;
  }
}
```

From a domain-model point of view, this is solid. The object controls its own state. No random code can mutate `Name`.

But `System.Text.Json` sees this and thinks:
- Public getter? Yes.
- Public setter? No.

So although serialization works, deserialization does not populate `Name`. Which means `Name` stays `null` unless you use a constructor-based approach.

`[JsonInclude]` tells `System.Text.Json`, “Yes, I know this member doesn’t meet your default rules, but I want it included anyway.” It overrides the default visibility rules.
```cs
public class Person
{
  [JsonInclude]
  public string Name { get; private set; }

  public Person() { }
}
```

Now `System.Text.Json` will serialize `Name` and set `Name` during deserialization despite the private setter. 

To summarize:
- Public auto-properties: included automatically
- Anything that looks like intentional encapsulation: excluded
- `[JsonInclude]`: “I meant to do this. Don’t second-guess me.” This attribute is for members that look excluded on purpose but shouldn’t be.

You don’t use `[JsonInclude]` to include normal properties. You use it to override the serializer’s safety rules when your class design is more sophisticated than public getters and setters everywhere. Once you start writing immutable models or proper domain objects, the attribute suddenly stops looking redundant and starts looking necessary.

# Page 523 - Choosing an EF Core database provider

> Thanks to [zkazz](https://github.com/zkazz) who raised an [issue on December 29, 2025](https://github.com/markjprice/cs14net10/issues/9) that prompted this improvement.

In the next edition, I will add a note to warn readers that the chapter uses the SQLite EF Core database provider and so all output reflects that. If a reader chooses a different EF Core database provider like the one for SQL Server then their output is likely to be different from what is shown in the book. 

For example, database object name delimiters might be different like quotes `"table name"` or square brackets `[table name]`, data types could be different since not all databases support the same types, and automatically-generated variable names could be different.

# Page 640 - Improving the class-to-table mapping

> Thanks to [Amar Jamal](https://github.com/amarjamal) who raised an [issue on November 7, 2025](https://github.com/markjprice/cs13net9/issues/81) that prompted this improvement.

In Step 4, I use a regular expression for replace: `$0\n    [StringLength($2)]`

Although this works on all operating systems, on Windows, when we open these files that have been modified we get a pop up titled: "Inconsistent Line Endings". On selecting the **Windows (CR LF)** option it highlights all the lines that where modified. Once you do a **Save All**, everything is fixed. 

To avoid this, you must use the appropriate line ending for your operating system in the replace expression:
- For Windows (CRLF): Use `$0\r\n`
- For Unix/macOS (LF): Use `$0\n`

In the next edition, I will use `$0\r\n` in the main example and add a note box to explain that Linux and Mac users should use `$0\n`.

# Page 697 - Reviewing Blazor routing, layouts, and navigation

In Step 7, I tell the reader to: "Note that `NavMenu.razor` has its own isolated stylesheet named `NavMenu.razor.css`." 

In the next edition, I will add: "Some code editors like Visual Studio collapse related files under their parent to save space. In **Solution Explorer**, expand `NavMenu.razor` to see its related files like `NavMenu.razor.css`."

# Page 737 - Creating an ASP.NET Core Minimal API project

> Thanks to [Amar Jamal](https://github.com/amarjamal) for raising [this issue on December 3, 2025](https://github.com/markjprice/cs13net9/issues/89).

In Step 2, the reader is told, "In `Program.Weather.cs`, add statements to extend the automatically generated partial `Program` class by moving (cut and paste the statements) the weather-related statements from `Program.cs`..." 

The "weather-related statements" include the `record WeatherForecast` so the reader should have moved the `record` from `Program.cs`. In the 11th edition, I will make that clearer.

# Appendix - Exercise 3.3 – Test your knowledge

> Thanks to [s3ba-b](https://github.com/s3ba-b) for raising this [issue on December 2, 2025](https://github.com/markjprice/cs12dotnet8/issues/106).

In the 11th edition, I will add a link to the documentation: https://learn.microsoft.com/en-us/dotnet/api/system.dividebyzeroexception, and quote it, "Dividing a floating-point value by zero doesn't throw an exception; it results in positive infinity, negative infinity, or not a number (NaN), according to the rules of IEEE 754 arithmetic."
