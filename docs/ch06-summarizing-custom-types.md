**Summarizing custom type choices**

Now that we have covered OOP and the C# features that enable you to define your own types, let’s summarize what you’ve learned.

- [Categories of custom types and their capabilities](#categories-of-custom-types-and-their-capabilities)
- [Mutability and records](#mutability-and-records)
- [Comparing inheritance and implementation](#comparing-inheritance-and-implementation)
- [Reviewing illustrative code](#reviewing-illustrative-code)


# Categories of custom types and their capabilities

Categories of custom types and their capabilities are summarized in *Table 6.6*:

Type|Instantiation|Inheritance|Equality|Memory
---|---|---|---|---
`class`|Yes|Single|Reference|Heap
`sealed class`|Yes|None|Reference|Heap
`abstract class`|No|Single|Reference|Heap
`record` or `record class`|Yes|Single|Value|Heap
`struct` or `record struct`|Yes|None|Value|Stack
`interface`|No|Multiple|Reference|Heap
*Table 6.6: Categories of custom types and their capabilities*

It is best to think about these differences by starting with the “normal” case and then spotting the differences in other cases. For example, a “normal” class can be instantiated with `new`, it supports single inheritance, it uses memory reference equality, and its state is stored in heap memory.

Now let’s highlight what is different about the more specialized types of `class`:
- A `sealed class` does not support inheritance.
- An `abstract class` does not allow instantiation with new.
- A `record class` uses value equality instead of reference equality.

We can do the same for other types compared to a “normal” `class`:
- A `struct` or `record struct` does not support inheritance, it uses value equality instead of reference equality, and its state is stored in stack memory.
- An `interface` does not allow instantiation with new and supports multiple inheritance.

# Mutability and records

A common misconception is that `record` types are immutable, meaning their instance properties and field values cannot be changed after initialization. 

However, the mutability of a record type actually depends on how the record is defined. 

Let’s explore mutability:

1.	In the `PacktLibrary` project, add a new class file named `Mutability.cs`.
2.	Modify `Mutability.cs`, as shown in the following code, and note the following:
```cs
namespace Packt.Shared;

// A mutable record class.
public record class C1
{
  public string? Name { get; set; }
}

// An immutable record class.
public record class C2(string? Name);

// A mutable record struct.
public record struct S1
{
  public string? Name { get; set; }
}

// Another mutable record struct.
public record struct S2(string? Name);

// An immutable record struct.
public readonly record struct S3(string? Name);
```

3.	In the `PeopleApp` project, in `Program.cs`, create an instance of each type, setting the initial `Name` value to `Bob`, and then modify the `Name` property to `Bill`. You will see the two types that are immutable after initialization because they will give the compiler error `CS8852`, as shown in the following code:
```cs
C1 c1 = new() { Name = "Bob" };
c1.Name = "Bill";

C2 c2 = new(Name: "Bob");
c2.Name = "Bill"; // CS8852: Init-only property.

S1 s1 = new() { Name = "Bob" };
s1.Name = "Bill";

S2 s2 = new(Name: "Bob");
s2.Name = "Bill";

S3 s3 = new(Name: "Bob");
s3.Name = "Bill"; // CS8852: Init-only property.
```

4.	Note that record `C1` is mutable and `C2` is immutable. Note that `S1` and `S2` are mutable and `S3` is immutable.
5.	Comment out the two statements that cause compiler errors.

> Microsoft made some interesting design choices with records. Make sure you remember the subtle differences in behavior when combining record, class, and struct, and use different types of declaration of each.

# Comparing inheritance and implementation

For me, the terms *inherit* and *implement* are different, and in the early days of C# and .NET you could strictly apply them to classes and interfaces, respectively. 

For example, the `FileStream` class inherits from the `Stream` class, and the `Int32` struct implements the `IComparable` interface.

Inherit implies some functionality that a subclass gets “for free” by inheriting from its base, or superclass. 

Implement implies some functionality that is NOT inherited but instead MUST be provided by the subclass. 

This is why I chose to title this chapter *Implementing Interfaces and Inheriting Classes*.

Before C# 8, interfaces were always purely contracts. There was no functionality in an interface that you could inherit. In those days, you could strictly use the term implement for interfaces that represent a list of members that your type must implement, and inherit for classes with functionality that your type can inherit and potentially override.

With C# 8, interfaces can now include default implementations, making them more like abstract classes, and the term inherit for an interface that has default implementations does make sense. But I feel uncomfortable with this capability, as do many other .NET developers, because it messes up what used to be a clean language design. Default interfaces also require changes to the underlying .NET runtime, so they cannot be used with legacy platforms like .NET Standard 2.0 class libraries and .NET Framework.

Classes can also have abstract members, for example, methods or properties without any implementation, just like an interface could have. When a subclass inherits from this class, it MUST provide an implementation of those abstract members, and the base class must be decorated with the abstract keyword to prevent it from being instantiated using `new` because it is missing some functionality.

# Reviewing illustrative code

Let’s review some example code that illustrates some of the important differences between types.

Note the following:
- To simplify the code, I have left out access modifiers like `private` and `public`.
- Instead of normal brace formatting, to save vertical space I have put all the method implementations in one statement, for example:
`void M1() { /* implementation */ }`
- Using “I” as a prefix for interfaces is a convention, not a requirement. It is useful to highlight interfaces using this prefix, since only interfaces support multiple inheritance.

Here’s the code:
```cs
// These are both "classic" interfaces in that they are pure contracts.
// They have no functionality, just the signatures of members that
// must be implemented.
interface IAlpha
{
  // A method that must be implemented in any type that implements
  // this interface.
  void M1();
}

interface IBeta
{
  void M2(); // Another method.
}

// A type (a struct in this case) implementing an interface.
// ": IAlpha" means Gamma promises to implement all members of IAlpha.
struct Gamma : IAlpha
{
  void M1() { /* implementation */ }
}

// A type (a class in this case) implementing two interfaces.
class Delta : IAlpha, IBeta
{
  void M1() { /* implementation */ }
  void M2() { /* implementation */ }
}

// A sub class inheriting from a base aka super class.
// ": Delta" means inherit all members from Delta.
class Episilon : Delta
{
  // This can be empty because this inherits M1 and M2 from Delta.
  // You could also add new members here.
}

// A class with one inheritable method and one abstract method
// that must be implemented in sub classes. A class with at least
// one abstract member must be decorated with the abstract keyword
// to prevent instantiation.
abstract class Zeta
{
  // An implemented method would be inherited.
  void M3() { /* implementation */ }
  // A method that must be implemented in any type that inherits
  // this abstract class.
  abstract void M4();
}

// A class inheriting the M3 method from Zeta but it must provide
// an implementation for M4.
class Eta : Zeta
{
  void M4() { /* implementation */ }
}

// In C# 8 and later, interfaces can have default implementations
// as well as members that must be implemented.
// Requires: .NET Standard 2.1, .NET Core 3.0 or later.
interface ITheta
{
  void M3() { /* implementation */ }
  void M4();
}

// A class inheriting the default implementation from an interface
// and must provide an implementation for M4.
class Iota : ITheta
{
  void M4() { /* implementation */ }
}
```