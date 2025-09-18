**A warning about binary serialization using BinaryFormatter**

The `BinaryFormatter` class is a serialization class that can convert a live object, or a graph of connected objects, into a binary format that can be stored or transmitted and later reconstructed. This class has been part of .NET since its early versions and is in the `System.Runtime.Serialization.Formatters.Binary` namespace. But `BinaryFormatter` is problematic for several reasons, primarily related to security and robustness.

For example, `BinaryFormatter` is vulnerable to deserialization attacks, where malicious input can execute arbitrary code during the deserialization process. This makes any application using `BinaryFormatter` susceptible to remote code execution (RCE) if an attacker can control the serialized data. `BinaryFormatter` does not perform any validation or checks on the data it deserializes, making it inherently insecure when handling untrusted data.

`BinaryFormatter` does not support many modern serialization features, like JSON or XML serialization capabilities, which are more secure and flexible.

> **Good Practice**: Microsoft recommends using serialization libraries like `System.Text.Json`, `System.Xml.Serialization`, `or Google.Protobuf`.

In the first version of .NET Core, the Microsoft team removed `BinaryFormatter` entirely due to its known risks, but without a clear path to using something safer, customers demanded that it be brought back, which the team did with .NET Core 1.1. Since then, the team has disabled it by default but allowed developers to explicitly re-enable it, by setting flags if they accept the risks.

With .NET 9 and later, the flags to enable `BinaryFormatter` have been removed, and any use of it will throw an exception. But there is still a way to re-enable it, by referencing a NuGet package marked as being permanently vulnerable and setting some configuration.

You can learn more about why and how the `BinaryFormatter` class was removed in .NET 9 at the following link: https://devblogs.microsoft.com/dotnet/binaryformatter-removed-from-dotnet-9/.
