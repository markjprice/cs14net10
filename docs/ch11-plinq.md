**Using multiple threads with parallel LINQ**

- [Introducing Parallel LINQ](#introducing-parallel-linq)
- [Creating an app that benefits from multiple threads](#creating-an-app-that-benefits-from-multiple-threads)
- [Using Windows](#using-windows)
- [Using macOS](#using-macos)
- [For all operating systems](#for-all-operating-systems)
- [Why should you avoid calling AsParallel in IEnumerable objects?](#why-should-you-avoid-calling-asparallel-in-ienumerable-objects)
  - [Why `AsParallel` exists on `IEnumerable<T>` at all](#why-asparallel-exists-on-ienumerablet-at-all)
  - [Why `IList<T>` matters for performance](#why-ilistt-matters-for-performance)
    - [Case A: Indexable collections like `IList<T>`](#case-a-indexable-collections-like-ilistt)
    - [Case B: Streaming enumerables](#case-b-streaming-enumerables)
  - [Guidance for using `AsParallel`](#guidance-for-using-asparallel)
  - [Alternative to PLINQ](#alternative-to-plinq)
  - [Summary](#summary)


# Introducing Parallel LINQ

By default, only one thread is used to execute a LINQ query. **Parallel LINQ (PLINQ)** is an easy way to enable multiple threads to execute a LINQ query.

> **Good Practice**: Do not assume that using parallel threads will improve the performance of your applications. Always measure real-world timings and resource usage.

# Creating an app that benefits from multiple threads

To see it in action, we will start with some code that only uses a single thread to calculate Fibonacci numbers for 45 integers. We will use the `StopWatch` type to measure the change in performance.

We will use operating system tools to monitor the CPU and CPU core usage. If you do not have multiple CPUs or at least multiple cores, then this exercise won't show much!

1.	Use your preferred code editor to add a new **Console App** / `console` project named `LinqInParallel` to the `Chapter11` solution.
2.	In `Program.cs`, delete the existing statements and then import the `System.Diagnostics` namespace so that we can use the `StopWatch` type. Add statements to create a stopwatch to record timings, wait for a keypress before starting the timer, create 45 integers, calculate the Fibonacci number for each of them, stop the timer, and display the elapsed milliseconds, as shown in the following code:
```cs
using System.Diagnostics; // To use Stopwatch.

Write("Press ENTER to start. ");
ReadLine();
Stopwatch watch = Stopwatch.StartNew();

watch.Start();
int max = 45;
IEnumerable<int> numbers = Enumerable.Range(start: 1, count: max);

// Although IEnumerable<int> enables the AsParallel extension method,
// to work well you should use a type that implements IList<T>.
IList<int> numbersAsList = numbers.ToList();

WriteLine($"Calculating Fibonacci sequence up to term {max}. Please wait...");

int[] fibonacciNumbers = numbersAsList
  .Select(number => Fibonacci(number))
  .ToArray(); 

watch.Stop();
WriteLine("{0:#,##0} elapsed milliseconds.",
  arg0: watch.ElapsedMilliseconds);

Write("Results:");
foreach (int number in fibonacciNumbers)
{
  Write($"  {number:N0}");
}

static int Fibonacci(int term) =>
  term switch
  {
    1 => 0,
    2 => 1,
    _ => Fibonacci(term - 1) + Fibonacci(term - 2)
  };
```

3.	Run the console app, but do not press *Enter* to start the stopwatch yet because we need to make sure a monitoring tool is showing processor activity.

# Using Windows

If you are using Windows:

1.	Right-click on the Windows Start button or press *Ctrl* + *Alt* + *Delete*, and then click on **Task Manager**.
2.	At the bottom of the **Task Manager** window, click **More details**.
3.	At the top of the **Task Manager** window, click on the **Performance** tab.
4.	Right-click on the **CPU Utilization** graph, select **Change graph to**, and then select **Logical processors**.

# Using macOS

If you are using macOS:

1.	Launch **Activity Monitor**.
2.	Navigate to **View** | **Update Frequency Very often (1 sec)**.
3.	To see the CPU graphs, navigate to **Window** | **CPU History**.

# For all operating systems

If you are using Windows, macOS, or any other OS:

1.	Rearrange your monitoring tool and your code editor so that they are side by side.
2.	Wait for the CPUs to settle and then press *Enter* to start the stopwatch and run the query. The result should be a number of elapsed milliseconds, as shown in the following output:
```
Calculating Fibonacci sequence up to term 45. Please wait...
17,624 elapsed milliseconds.
Results: 0 1 1 2 3 5 8 13 21 34 55 89 144 233 377 610 987 1,597 2,584 4,181 6,765 10,946 17,711 28,657 46,368 75,025 121,393 196,418 317,811 514,229 832,040 1,346,269 2,178,309 3,524,578 5,702,887 9,227,465 14,930,352 24,157,817 39,088,169 63,245,986 102,334,155 165,580,141 267,914,296 433,494,437 701,408,733
```

The monitoring tool will probably show that one or two CPUs were used the most, alternating over time. Others may execute background tasks at the same time, such as the garbage collector, so the other CPUs or cores won't be completely flat, but the work is certainly not being evenly spread among all the possible CPUs or cores. Also, note that some of the logical processors are maxing out at 100%.

3.	In `Program.cs`, modify the query to make a call to the `AsParallel` extension method and to sort the resulting sequence, because when processing in parallel the results can become misordered, as shown highlighted in the following code:
```cs
int[] fibonacciNumbers = numbersAsList
  .AsParallel()
  .Select(number => Fibonacci(number))
  .OrderBy(number => number)
  .ToArray();
```

> **Good Practice**: Never call `AsParallel` at the end of a query. This does nothing. You must perform at least one operation after the call to `AsParallel` for that operation to be parallelized. .NET 6 introduced a code analyzer that will warn about this type of misuse.

4.	Run the code, wait for CPU charts in your monitoring tool to settle, and then press *Enter* to start the stopwatch and run the query. This time, the application should complete in less time (although it might not be as less as you might hope for—managing those multiple threads takes extra effort!):
```
Calculating Fibonacci sequence up to term 45. Please wait...
9,028 elapsed milliseconds.
Results: 0 1 1 2 3 5 8 13 21 34 55 89 144 233 377 610 987 1,597 2,584 4,181 6,765 10,946 17,711 28,657 46,368 75,025 121,393 196,418 317,811 514,229 832,040 1,346,269 2,178,309 3,524,578 5,702,887 9,227,465 14,930,352 24,157,817 39,088,169 63,245,986 102,334,155 165,580,141 267,914,296 433,494,437 701,408,733
```

5.	The monitoring tool should show that all CPUs were used equally to execute the LINQ query and note that none of the logical processors max out at 100% because the work is more evenly spread.

# Why should you avoid calling AsParallel in IEnumerable<T> objects?

This one trips .NET developers up, including me, because the API design and the performance guidance are mismatched. The bottom line is that `AsParallel` is defined on `IEnumerable<T>` for usability and composability, not because every `IEnumerable<T>` is a good idea to parallelize from a performance perspective.

## Why `AsParallel` exists on `IEnumerable<T>` at all

PLINQ is designed to sit naturally on top of LINQ. LINQ’s entire ecosystem is built around `IEnumerable<T>`. If `AsParallel` only worked on `IList<T>`, it would break a huge amount of existing LINQ code and force awkward casts everywhere. If `AsParallel` required `IList<T>`, the moment you used `Where` or `Select`, you would lose that type and be blocked. That would be a terrible developer experience.

So Microsoft made a very deliberate choice:
- **Correctness**: Any `IEnumerable<T>` can be parallelized safely.
- **Performance**: Some `IEnumerable<T>` implementations are dramatically better than others.

## Why `IList<T>` matters for performance

Parallel execution needs to split work into chunks. This is called partitioning. There are two broad cases.

### Case A: Indexable collections like `IList<T>`

Examples:
- `List<T>`
- `T[]`
- `ObservableCollection<T>`

These support:
- `Count` property
- Fast random access by index

PLINQ can partition these up front into contiguous ranges. Thread 1 gets items 0–999, thread 2 gets 1000–1999, etc. This is cheap, predictable, cache-friendly, and fast.

### Case B: Streaming enumerables

Examples:
- `Enumerable.Range`
- `yield return` sequences
- LINQ pipelines
- `File.ReadLines`

These are pull-based streams. They do not know their size ahead of time and do not support indexing.

In these scenarios, PLINQ must use a dynamic partitioner, which means that threads contend for the next item, more synchronization, less predictable scheduling, and more overhead. This is why people say "only use `AsParallel` on `IList<T>`". They really mean "only expect good performance if your source is indexable", not "`AsParallel` is invalid or broken on other types."

If you directly use the result of calling `Enumerable.Range`, then PLINQ ends up wrapping it in a dynamic partitioner. The overhead can exceed the cost of the work unless each element does something heavy. That's why our code calls `ToList` to create a data structure that supports `Count` and indexing before processing the numbers.

## Guidance for using `AsParallel`

Use `AsParallel` when at least one of these is true:
- The per-item work is expensive, not just arithmetic
- The source is indexable like `List<T>` or an array
- You have measured and proven it helps

Otherwise, you are probably slowing things down. And yes, this means that using `AsParallel` over `Range` is usually pointless unless you are doing something heavyweight per element.

PLINQ is massively overused for trivial workloads. People see parallel and assume faster. That is not how it works. Coordination costs real money in CPU terms.

## Alternative to PLINQ

If your workload really is numeric and index-based, skip PLINQ and do this instead:
```cs
Parallel.For(0, n, i =>
{
  // work
});
```

That API is built exactly for this scenario and avoids the enumerable abstraction entirely.

> You can learn more about `Parallel.For` method at the following link: https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.parallel.for

## Summary

`AsParallel` extends `IEnumerable<T>` because LINQ composability matters more than performance guarantees, and the advice to only use `AsParallel` on `IList<T>` sequences is about avoiding slow partitioning, not about correctness or API validity.
