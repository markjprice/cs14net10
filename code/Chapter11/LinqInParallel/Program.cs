using System.Diagnostics; // To use Stopwatch.

Write("Press ENTER to start. "); ReadLine();
Stopwatch watch = Stopwatch.StartNew();

int max = 45;
IEnumerable<int> numbers = Enumerable.Range(start: 1, count: max);

// Although IEnumerable<int> enables the AsParallel extension method,
// to work well you should use a type that implements IList<T>.
IList<int> numbersAsList = numbers.ToList();

WriteLine($"Calculating Fibonacci sequence up to term {max}. Please wait...");

// int[] fibonacciNumbers = numbersAsList
//   .Select(number => Fibonacci(number))
//   .ToArray();

int[] fibonacciNumbers = numbersAsList
  .AsParallel()
  .Select(number => Fibonacci(number))
  .OrderBy(number => number)
  .ToArray();

watch.Stop();
WriteLine("{0:#,##0} elapsed milliseconds.",
  arg0: watch.ElapsedMilliseconds);

Write("Results:");
foreach (int number in fibonacciNumbers)
{
  Write($" {number:N0}");
}

static int Fibonacci(int term) =>
  term switch
  {
    1 => 0,
    2 => 1,
    _ => Fibonacci(term - 1) + Fibonacci(term - 2)
  };
