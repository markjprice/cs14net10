**Improvements** (5 items)

If you have suggestions for improvements, then please [raise an issue in this repository](https://github.com/markjprice/cs14net10/issues) or email me at markjprice (at) gmail.com.

- [Page 119 - Null-conditional assignment operator](#page-119---null-conditional-assignment-operator)
- [Page 267 - Controlling how parameters are passed](#page-267---controlling-how-parameters-are-passed)
- [Page 640 - Improving the class-to-table mapping](#page-640---improving-the-class-to-table-mapping)
- [Page 737 - Creating an ASP.NET Core Minimal API project](#page-737---creating-an-aspnet-core-minimal-api-project)
- [Appendix - Exercise 3.3 – Test your knowledge](#appendix---exercise-33--test-your-knowledge)


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

# Page 267 - Controlling how parameters are passed

> Thanks to [alhi44](https://github.com/alhi44) who raised an [issue on September 14, 2025](https://github.com/markjprice/cs13net9/issues/78) that prompted this improvement.

It is too late for the 10th edition in 2025, but in the 11th edition I will add an analogy about passing pieces of paper, as follows: 

When a parameter is passed into a method, it can be passed in one of several ways:

1. By **value** (this is the default): Think of these as being *in-only*. Although the value can be changed, this only affects the parameter in the method. Imagine someone has a piece of paper with a number written on it. They pass a photocopy of the paper, not the original. The function can write on the photocopy, but the original remains unchanged.
2. As an `out` parameter: Think of these as being *out-only*. `out` parameters cannot have a default value assigned in their declaration and cannot be left uninitialized. They must be set inside the method; otherwise, the compiler will give an error. Imagine someone has a blank piece of paper and asks the function to write on it. They cannot pass a piece of paper with something written on it; it *must* be blank. And the function *must* write on it before returning it.
3. By reference as a `ref` parameter: Think of these as being *in-and-out*. Like `out` parameters, `ref` parameters also cannot have default values, but since they can already be set outside the method, they do not need to be set inside the method. Imagine someone has a piece of paper with a number written on it. They pass the original piece of paper and allow the function to write on it. This means that any changes made are immediately visible to them as well as you. The paper *must* have a number written on it before it is passed.
4. As an `in` parameter: Think of these as being a reference parameter that is read-only. `in` parameters cannot have their values changed and the compiler will show an error if you try. Imagine someone has a piece of paper with a number written on it. They pass the original piece of paper and allow the function to read it but not write on it.

# Page 640 - Improving the class-to-table mapping

> Thanks to [Amar Jamal](https://github.com/amarjamal) who raised an [issue on November 7, 2025](https://github.com/markjprice/cs13net9/issues/81) that prompted this improvement.

In Step 4, I use a regular expression for replace: `$0\n    [StringLength($2)]`

Although this works on all operating systems, on Windows, when we open these files that have been modified we get a pop up titled: "Inconsistent Line Endings". On selecting the **Windows (CR LF)** option it highlights all the lines that where modified. Once you do a **Save All**, everything is fixed. 

To avoid this, you must use the appropriate line ending for your operating system in the replace expression:
- For Windows (CRLF): Use `$0\r\n`
- For Unix/macOS (LF): Use `$0\n`

In the next edition, I will use `$0\r\n` in the main example and add a note box to explain that Linux and Mac users should use `$0\n`.

# Page 737 - Creating an ASP.NET Core Minimal API project

> Thanks to [Amar Jamal](https://github.com/amarjamal) for raising [this issue on December 3, 2025](https://github.com/markjprice/cs13net9/issues/89).

In Step 2, the reader is told, "In `Program.Weather.cs`, add statements to extend the automatically generated partial `Program` class by moving (cut and paste the statements) the weather-related statements from `Program.cs`..." 

The "weather-related statements" include the `record WeatherForecast` so the reader should have moved the `record` from `Program.cs`. In the 11th edition, I will make that clearer.

# Appendix - Exercise 3.3 – Test your knowledge

> Thanks to [s3ba-b](https://github.com/s3ba-b) for raising this [issue on December 2, 2025](https://github.com/markjprice/cs12dotnet8/issues/106).

In the 11th edition, I will add a link to the documentation: https://learn.microsoft.com/en-us/dotnet/api/system.dividebyzeroexception, and quote it, "Dividing a floating-point value by zero doesn't throw an exception; it results in positive infinity, negative infinity, or not a number (NaN), according to the rules of IEEE 754 arithmetic."
