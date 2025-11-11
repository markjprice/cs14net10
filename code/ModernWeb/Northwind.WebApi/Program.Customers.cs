using Microsoft.AspNetCore.Mvc; // To use ProblemDetails.
using Microsoft.EntityFrameworkCore; // To use ToArrayAsync, FindAsync, AddAsync, Update, Remove.
using Microsoft.EntityFrameworkCore.ChangeTracking; // To use EntityEntry<T>.
using Northwind.EntityModels; // To use NorthwindContext and Customer.
using System.ComponentModel.DataAnnotations; // To use [Required].

static partial class Program
{
  internal static void MapCustomers(this WebApplication app)
  {
    // GET: /customers
    app.MapGet(pattern: "/customers", handler:
      async (NorthwindContext db) =>
    {
      return await db.Customers.ToArrayAsync();
    });

    // GET: /customers/in/[country]
    app.MapGet(pattern: "/customers/in/{country}", handler:
      async ([Required] string country, NorthwindContext db) =>
    {
      return await db.Customers
        .Where(customer => customer.Country == country)
        .ToArrayAsync();
    });

    // GET: /customers/[id]
    app.MapGet("/customers/{id:regex(^[A-Za-z]{{5}}$)}", 
      async Task<IResult> (string id, NorthwindContext db) =>
    {
      id = id.ToUpper(); // Normalize to uppercase.

      Customer? customer = await db.Customers.FindAsync(id);

      if (customer is null)
      {
        return TypedResults.NotFound(); // 404 Resource not found.
      }
      return TypedResults.Ok(customer); // 200 OK with customer in body.
    });

    // POST: /customers
    // BODY: Customer (JSON)
    app.MapPost(pattern: "/customers", handler:
      async Task<IResult> (Customer? c, NorthwindContext db) =>
    {
      if (c is null)
      {
        return TypedResults.BadRequest(); // 400 Bad request.
      }

      c.CustomerId = c.CustomerId.ToUpper(); // Normalize to uppercase.

      // Add to database using EF Core.
      EntityEntry<Customer> added =
        await db.Customers.AddAsync(c);

      int affected = await db.SaveChangesAsync();
      if (affected == 1)
      {
        return TypedResults.Created( // 201 Created.
          uri: $"/customers/{c.CustomerId}", value: c);
      }
      else
      {
        return TypedResults.BadRequest("Failed to create customer.");
      }
    });

    // PUT: /customers/[id]
    // BODY: Customer (JSON)
    app.MapPut(pattern: "/customers/{id:regex(^[A-Za-z]{{5}}$)}", handler:
      async Task<IResult> (Customer? replacement,
        string id, NorthwindContext db) =>
    {
      if (replacement is null)
      {
        return TypedResults.BadRequest("Replacement customer is null."); // 400 Bad request.
      }

      // Normalize the IDs to uppercase.
      id = id.ToUpper();
      replacement.CustomerId = replacement.CustomerId.ToUpper();

      if (replacement.CustomerId != id)
      {
        return TypedResults.BadRequest("Customer ID mismatch."); // 400 Bad request.
      }

      Customer? existing = await db.Customers.FindAsync(id);

      if (existing is null)
      {
        return TypedResults.NotFound(); // 404 Resource not found.
      }

      // Detach the existing customer from change tracking.
      db.Entry(existing).State = EntityState.Detached;

      // Start change tracking the replacement customer.
      db.Customers.Update(replacement);

      int affected = await db.SaveChangesAsync();
      if (affected == 1)
      {
        return TypedResults.NoContent(); // 204 No content.
      }
      return TypedResults.BadRequest( // 400 Bad request.
        $"Customer {id} was found but failed to update.");
    });

    // DELETE: /customers/[id]
    app.MapDelete(pattern: "/customers/{id}", handler:
      async Task<IResult> (string id, NorthwindContext db) =>
    {
      // Take control of problem details.
      if (id == "bad")
      {
        ProblemDetails problemDetails = new()
        {
          Status = StatusCodes.Status400BadRequest,
          Type = "https://localhost:5151/customers/failed-to-delete",
          Title = $"Customer ID {id} found but failed to delete.",
          Detail = "More details like Company Name, Country and so on."
        };
        return TypedResults.BadRequest(problemDetails); // 400 Bad Request
      }

      id = id.ToUpper();
      Customer? existing = await db.Customers.FindAsync(id);

      if (existing is null)
      {
        return TypedResults.NotFound(); // 404 Resource not found.
      }

      db.Customers.Remove(existing);

      int affected = await db.SaveChangesAsync();
      if (affected == 1)
      {
        return TypedResults.NoContent(); // 204 No content.
      }
      else
      {
        return TypedResults.BadRequest( // 400 Bad request.
          $"Customer {id} was found but failed to delete.");
      }
    });
  }
}
