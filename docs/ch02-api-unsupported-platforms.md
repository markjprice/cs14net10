**Handling platforms that do not support an API**

So how do we solve the problem of how to handle platforms that do not support an API provided by .NET? 

# Handling unsupported APIs with exception handlers

We can solve this by using an exception handler. You will learn more details about the `try-catch` statement in *Chapter 3, Controlling Flow, Converting Types, and Handling Exceptions*, so for now, just enter the code:

1.	Modify the code to wrap the lines that change the cursor size in a `try` statement, as shown in the following code:
```cs
try
{
  CursorSize = int.Parse(args[2]);
}
catch (PlatformNotSupportedException)
{
  WriteLine("The current platform does not support changing the size of the cursor.");
}
```

2.	If you were to run the code on macOS, then you would see the exception is caught, and a friendlier message is shown to the user.

# Handling unsupported APIs by checking for the OS

Another way to handle differences in operating systems is to use the `OperatingSystem` class in the `System` namespace, as shown in the following code:
```cs
if (OperatingSystem.IsWindowsVersionAtLeast(major: 10))
{
  // Execute code that only works on Windows 10 or later.
}
else if (OperatingSystem.IsWindows())
{
  // Execute code that only works earlier versions of Windows.
}
else if (OperatingSystem.IsIOSVersionAtLeast(major: 14, minor: 5))
{
  // Execute code that only works on iOS 14.5 or later.
}
else if (OperatingSystem.IsBrowser())
{
  // Execute code that only works in the browser with Blazor.
}
```

The `OperatingSystem` class has equivalent methods for other common operating systems, like Android, iOS, Linux, macOS, and even the browser, which is useful for Blazor web components.

# Handling unsupported APIs using conditional compilation

A third way to handle different platforms is to use conditional compilation statements.

There are four preprocessor directives that control conditional compilation: `#if`, `#elif`, `#else`, and `#endif`.

You define symbols using `#define`, as shown in the following code:
```cs
#define MYSYMBOL
```

Many symbols are automatically defined for you, as shown in *Table 2.11*:

Target Framework|Symbols
---|---
.NET Standard|`NETSTANDARD2_0`, `NETSTANDARD2_1`, and so on
Modern .NET|`NET10_0`, `NET10_0_ANDROID`, `NET10_0_IOS`, `NET10_0_WINDOWS`, and so on

*Table 2.11: Predefined compiler symbols*

You can then write statements that will compile only for the specified platforms, as shown in the following code:
```cs
#if NET10_0_ANDROID
// Compile statements that only work on Android.
#elif NET10_0_IOS
// Compile statements that only work on iOS.
#else
// Compile statements that work everywhere else.
#endif
```
