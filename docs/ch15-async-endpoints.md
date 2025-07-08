**Implementing asynchronous operations**

You implemented the endpoints, most of which return a `Task<IResult>`, but only some will call `await` within the method implementation and therefore need to be decorated with `async`. Let’s see why.

- [When to call `await` inside a method](#when-to-call-await-inside-a-method)
- [When to return a task without `await`](#when-to-return-a-task-without-await)
- [When to decorate a method with `async`](#when-to-decorate-a-method-with-async)
- [Example code for `async` and `await`](#example-code-for-async-and-await)


# When to call `await` inside a method

A method should call `await` inside its implementation if:

- You need to handle exceptions within the method. `await` unwraps exceptions, meaning you can catch them using a `try-catch` inside the method. Without `await`, the method would return a `Task<T>` that, when `await`-ed elsewhere, would throw an `AggregateException` wrapping the real exception.
- You need to perform additional logic after the `await`-ed task completes. If the method needs to do something after the asynchronous operation, it must `await` it. For example, after successfully creating a row in a table, you might need to store it in a cache, as show in the following code:
```cs
public async Task<Customer?> CreateAsync(Customer c)
{
  c.CustomerId = c.CustomerId.ToUpper(); // Normalize to uppercase.

  // Add to database using EF Core.
  EntityEntry<Customer> added =
 
  await _db.Customers.AddAsync(c);
  int affected = await _db.SaveChangesAsync();
 
  if (affected == 1)
  {
    // If saved to database then store in cache.
    await _cache.SetAsync(c.CustomerId, c);
    return c;
  }
  return null;
}
```

- You need to capture the execution context. By default, `await` captures the current execution context (for example, `SynchronizationContext` or `TaskScheduler`). If you need this behavior (for example, when updating UI components in a desktop application), you should await.

# When to return a task without `await`

A method should not use await and should return a `Task<T>` directly if:
- The method is a simple wrapper. If you’re just returning the result of another asynchronous call, there’s no need for `await`. Instead, return the `Task<T>` directly, as shown in the following code:
```cs
public Task<List<Customer>> GetCustomersAsync()
{
  return _db.Customers.ToListAsync();
}
```
- You don’t need to handle exceptions inside the method. If you’re fine with exceptions being handled by the caller, returning a `Task<T>` directly avoids the extra state machine that `async`/`await` introduces.
- The method doesn't need to resume execution after the `await`-ed call. If there’s nothing to do after the asynchronous operation, just return the `Task`.

# When to decorate a method with `async`

A method needs the `async` keyword if:
- It contains an `await` expression. `await` can only be used inside `async` methods.
- You want to return a `Task<T>` without manually wrapping the result. An `async` method automatically wraps return values in a `Task<T>`, whereas a non-`async` method must explicitly return `Task.FromResult(value)`.

# Example code for `async` and `await`

A common example of calling `await` inside an `async` method is because a method handles exceptions inside itself and the method needs to do something after the `await` (in this case multiplying value by 2), as shown in the following code:
```cs
public async Task<int> ComputeValueAsync()
{
  try
  {
    int value = await GetNumberAsync();
    return value * 2;
  }
  catch (Exception ex)
  {
    Console.WriteLine($"Error: {ex.Message}");
    return -1;
  }
}
```

A common example of returning a `Task<T>` without `await`, as shown in the following code:
```cs
public Task<int> ComputeValueAsync()
{
  return GetNumberAsync();
}

// Or simplified.
public Task<int> ComputeValueAsync() => GetNumberAsync();
```

In the preceding code example, we do not need `async`/`await` because the method does nothing after the `await`-ed call, the method does not need to handle exceptions, and therefore we can avoid the unnecessary state machine overhead.

In general, only use `await` if you need to avoid unnecessary overhead from the `async` state machine. Otherwise, return the `Task` directly. A summary of common scenarios is shown in the following table:

Scenario|Use async & await?
---|---
Need to handle exceptions inside the method|Yes
Need to perform logic after the awaited task|Yes
Need to capture execution context (UI apps)|Yes
Just returning a Task from another method|No
