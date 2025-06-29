**In-memory, distributed, and hybrid caches**

Now let’s see an overview of in-memory, distributed, and hybrid caching.

# In-memory caching

In-memory caching stores data in the memory of the web server where the application is running. This is useful for small to medium-sized applications where the caching needs are not too extensive and can be handled by a single server’s memory.

The key points about in-memory caching are shown in the following list:
- **Performance**: Fast retrieval since the data is stored locally in RAM.
- **Simplicity**: Easy to implement and configure within the application.
- **Volatility**: Data is lost if the application restarts or the server goes down.
- **Scalability**: Limited to a single server’s memory; not suitable for large-scale applications needing distributed caching.

To implement in-memory caching, add the memory cache service to the services collection in `Program.cs`, as shown in the following code:
```cs
services.AddMemoryCache();
```

Retrieve the service in an endpoint, as shown in the following code:
```cs
private readonly IMemoryCache _cache;
```

Set data in the cache, as shown in the following code:
```cs
_cache.Set(key, data);
```

Get data from the cache, as shown in the following code:
```cs
bool success = _cache.TryGetValue(key, out var data) ? data : null;
```

Now let’s compare in-memory caching to distributed caching.

# Distributed caching

Distributed caching allows caching data across multiple servers, making it suitable for large-scale, distributed applications. This ensures data availability and consistency across different nodes in a web farm.

The key points about in-memory caching are shown in the following list:

- **Scalability**: Can handle large datasets and provide caching across multiple servers.
- **Persistence**: Depending on the provider, data can be persisted beyond application restarts.
- **Latency**: May have higher latency compared to in-memory caching due to network calls.
- **Providers**: Common providers include Redis, SQL Server, and NCache.

To implement distributed caching, add a distributed caching implementation, like Redis, to the services collection in `Program.cs`, as shown in the following code:
```cs
services.AddStackExchangeRedisCache(options =>
  options.Configuration = "localhost:6379";
  options.InstanceName = "SampleInstance";
});
```

Retrieve the service in an endpoint, as shown in the following code:
```cs
private readonly IDistributedCache _cache;
```

Set data in the cache, as shown in the following code:
```cs
await _cache.SetStringAsync(key, value);
```

Get data from the cache, as shown in the following code:
```cs
return await _cache.GetStringAsync(key);
```

So, in-memory caching is fast and simple but limited to the server’s memory and loses data on restart. Distributed caching is scalable and persistent, ideal for large applications, with various providers like Redis and SQL Server.

Both approaches help improve application performance by reducing the need to repeatedly fetch or compute data. The choice between them depends on the application’s scale, performance needs, and architecture.

But what if we could get the best of both worlds? Let’s see a new option called hybrid caching.

# Hybrid caching

The HybridCache API introduced in preview with ASP.NET Core 9 addresses some limitations found in the `IDistributedCache` and `IMemoryCache` APIs. As an abstract class with a default implementation, HybridCache efficiently manages most tasks related to storing and retrieving data from the cache.

The key points about hybrid caching are shown in the following list:
- **Unified API**: Provides a single interface for both in-process and out-of-process caching. HybridCache can seamlessly replace any existing `IDistributedCache` and `IMemoryCache` usage. It always uses the in-memory cache initially, and when an `IDistributedCache` implementation is available, HybridCache leverages it for secondary caching. This dual-level caching approach combines the speed of in-memory caching with the durability of distributed or persistent caching.
- **Stampede Protection**: HybridCache prevents cache stampedes, which occur when a frequently used cache entry is invalidated, causing multiple requests to try to repopulate it simultaneously. HybridCache merges concurrent operations, ensuring all requests for the same response wait for the first request to be completed.
- **Configurable Serialization**: HybridCache allows for configurable serialization during service registration, supporting both type-specific and generalized serializers via the `WithSerializer` and `WithSerializerFactory` methods, which are chained from the `AddHybridCache` call. By default, it manages `string` and `byte[]` internally and utilizes `System.Text.Json` for other types. It can be configured to use other serializers, such as Protobuf or XML.

Although HybridCache was introduced in preview with .NET 9, its package targets .NET Standard 2.0, so it can be used with older versions of .NET, even .NET Framework 4.6.2 or later. The HybridCache package reached general availability in March 2025 with version 9.3 (previous versions were all previews): https://devblogs.microsoft.com/dotnet/hybrid-cache-is-now-ga/
