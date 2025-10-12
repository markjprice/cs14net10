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

# Chapter 9

# Chapter 10

# Chapter 11

# Chapter 12

# Chapter 13

# Chapter 14

# Chapter 15

