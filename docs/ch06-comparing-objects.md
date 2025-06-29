**Comparing objects using a separate class**

Sometimes, you won’t have access to the source code for a type, and it might not implement the `IComparable` interface. Luckily, there is another way to sort instances of a type. You can create a separate type that implements a slightly different interface, named `IComparer`:

1.	In the `PacktLibrary` project, add a new class file named `PersonComparer.cs`, containing a class implementing the `IComparer` interface that will compare two people, that is, two `Person` instances. We will implement it by comparing the length of their `Name` fields, or if the names are the same length, then compare the names alphabetically, as shown in the following code:
```cs
namespace Packt.Shared;

public class PersonComparer : IComparer<Person?>
{
  public int Compare(Person? x, Person? y)
  {
    int position;

    if ((x is not null) && (y is not null))
    {
      if ((x.Name is not null) && (y.Name is not null))
      {
        // If both Name values are not null...
        // ...then compare the Name lengths...
        int result = x.Name.Length.CompareTo(y.Name.Length);
        // ...and if they are equal...
        if (result == 0)
        {
          // ...then compare by the Names...
          return x.Name.CompareTo(y.Name);
        }
        else
        {
          // ...otherwise compare by the lengths.
          position = result;
        }
      }
      else if ((x.Name is not null) && (y.Name is null))
      {
        position = -1; // x Person precedes y Person.
      }
      else if ((x.Name is null) && (y.Name is not null))
      {
        position = 1; // x Person follows y Person.
      }
      else // x.Name and y.Name are both null.
      {
        position = 0; // x and y are at same position.
      }
    }
    else if ((x is not null) && (y is null))
    {
      position = -1; // x Person precedes y Person.
    }
    else if ((x is null) && (y is not null))
    {
      position = 1; // x Person follows y Person.
    }
    else // x and y are both null.
    {
      position = 0; // x and y are at same position.
    }
    return position;
  }
}
```

2.	In `Program.cs`, add statements to sort the array using an alternative implementation, as shown in the following code:
```cs
Array.Sort(people, new PersonComparer());

OutputPeopleNames(people,
  "After sorting using PersonComparer's IComparer implementation:");
```

3.	Run the `PeopleApp` project, and view the result of sorting the people by the length of their names and then alphabetically, as shown in the following output:
```
After sorting using PersonComparer's IComparer implementation:
  Adam
  Jenny
  Simon
  Richard
  <null> Name
  <null> Person
```

This time, when we sort the people array, we explicitly ask the sorting algorithm to use the `PersonComparer` type instead so that the people are sorted with the shortest names first, like Adam, and the longest names last, like Richard. When the lengths of two or more names are equal, they are sorted alphabetically, like Jenny and Simon.
