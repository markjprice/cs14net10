**Implementing asynchronous methods with EF Core**

Implementing asynchronous methods with EF Core allows your application to perform other work while waiting for database operations to complete, which is especially important for avoiding thread exhaustion in high-traffic websites and web services.

- [How to use EF Core asynchronous methods](#how-to-use-ef-core-asynchronous-methods)
  - [Key Asynchronous EF Core Methods](#key-asynchronous-ef-core-methods)
  - [Explanation](#explanation)
- [Why it's good to avoid thread exhaustion](#why-its-good-to-avoid-thread-exhaustion)
  - [The problem with synchronous operations](#the-problem-with-synchronous-operations)
  - [The asynchronous solution](#the-asynchronous-solution)
- [Good practice with `async` EF Core](#good-practice-with-async-ef-core)
  - [Async all the way](#async-all-the-way)
  - [Don't use `async` for CPU-bound work](#dont-use-async-for-cpu-bound-work)
  - [Be aware of EF Core context thread safety](#be-aware-of-ef-core-context-thread-safety)


# How to use EF Core asynchronous methods

Implementing `async` methods in EF Core is straightforward. It primarily involves using the `async` and `await` keywords and calling the asynchronous versions of EF Core methods, which typically end with the suffix `Async`.

## Key Asynchronous EF Core Methods

  * `ToListAsync()`
  * `FirstOrDefaultAsync()`
  * `SingleOrDefaultAsync()`
  * `FindAsync()`
  * `SaveChangesAsync()`
  * `CountAsync()`
  * `AnyAsync()`

Consider a typical synchronous method to get a list of products from a database:

```cs
// Synchronous (blocking) method
public List<Product> GetProducts()
{
  using NorthwindContext db = new();

  // This blocks the thread until the database returns data.
  return db.Products.ToList(); 
}
```

Here’s how you would convert it to an asynchronous method:

```cs
// Asynchronous (non-blocking) method
public async Task<List<Product>> GetProductsAsync()
{
    using NorthwindContext context = new();

    // The 'await' keyword frees the thread to do other work.
    return await db.Products.ToListAsync();
}
```

## Explanation

1.  The method signature is changed to return a `Task<List<Product>>` and is marked with the `async` keyword.
2.  Inside the method, `await` is used before calling `ToListAsync()`. When the `await` keyword is hit, control is returned to the caller. The thread that was executing this code is released back to the thread pool and is free to handle other requests.
3.  Once the database operation is complete, a thread from the thread pool is used to continue the execution of the method from where it left off.

# Why it's good to avoid thread exhaustion

In a server environment like ASP.NET Core, each incoming request is handled by a thread from a limited thread pool. When you use synchronous (blocking) I/O operations, the thread assigned to a request is held captive, doing nothing but waiting for the database to respond.

## The problem with synchronous operations

Imagine your web application receives a surge of requests.

1.  **Request 1 arrives:** A thread is taken from the pool to handle it. It makes a synchronous call to the database. The thread is now **blocked**, waiting for the database.
2.  **Request 2 arrives:** Another thread is taken from the pool. It also makes a database call and becomes blocked.
3.  **This continues:** As more requests come in, more threads are taken from the pool and become blocked.
4.  **Thread Pool Exhaustion:** Eventually, all available threads in the pool are blocked. New incoming requests have to wait until a thread is freed. This leads to slow response times and, in worst-case scenarios, the application becomes unresponsive. This is *thread exhaustion*.

## The asynchronous solution

Asynchronous operations elegantly solve this problem.

1.  **Request 1 arrives:** A thread is taken from the pool. It makes an asynchronous call to the database using `await`.
2.  **Thread is Released:** The `await` keyword immediately frees the thread, returning it to the thread pool. The thread can now be used to handle another incoming request.
3.  **Request 2 arrives:** The same thread (or another free thread) can now handle this new request.
4.  **Operation Completes:** When the database finishes its work for Request 1, a thread from the pool is used to continue processing the rest of the method.

By not blocking threads, your application can handle a much higher number of concurrent requests with the same number of threads. This dramatically improves scalability and throughput.

# Good practice with `async` EF Core

## Async all the way

If a method is asynchronous, it's best to use `await` all the way up the call stack. Mixing synchronous and asynchronous code (e.g., by calling `.Result` or `.Wait()` on a task) can lead to deadlocks and negate the benefits of async.

## Don't use `async` for CPU-bound work

`async` and `await` are best suited for I/O-bound operations (like database calls, file access, and network requests). 

For CPU-intensive tasks, it's better to use `Task.Run()` to offload the work to a background thread.

## Be aware of EF Core context thread safety

The same `DbContext` instance is not thread-safe. You should always `await` one operation to complete before starting another on the same context instance. EF Core's default dependency injection lifetime (scoped) in ASP.NET Core helps manage this by providing a new context for each request.
