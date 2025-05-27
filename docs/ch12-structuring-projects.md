**Structuring projects**

A reader asked, "In Chapter 12, you discussed structuring projects within a solution. I'm a bit confused about where the service, repository, and DTO types should be placed. Specifically, where should I place the IProductRepository, ProductRepository, IProductService, ProductService, and the corresponding DTOs? In traditional N-Layer architecture, repository types are typically found in the Data Access Layer, while service types are located in the Business Layer. Additionally, I've seen some discussions about DTOs being placed in either the Presentation Layer or the Application Layer. Could you provide some guidance on this?"

In my book, in this section, I currently only discuss the structure of projects in a solution. Your question extends that to the structure or architecture of the deployed artifacts. For example, you mention "DTOs being placed in either the Presentation Layer or the Application Layer". But they are usually required in BOTH. Imagine the Presentation Layer (perhaps a Blazor Wasm or MAUI app) makes a request to the Application Layer (maybe a Web API service) for products that match some search criteria. The Application Layer needs to create instances of `ProductDTO` and then serialize them and send them to the Presentation Layer. The Presentation Layer then needs to deserialize those instances of `ProductDTO`. So both the Presentation Layer project and the Application Layer projects must reference the shared class library that defines the `ProductDTO`. But there is only one shared class library in the solution. You would not try to structure the projects in the solution to match one-to-one with the structure of the deployed architecture. I suspect that's what is missing in your understanding. The other pieces you mention tend to only exist in one layer so those can match in the project structure and deployed architecture.

Let’s break this down step-by-step to understand the differences between:

- [1. Logical Architectural Layer Diagram](#1-logical-architectural-layer-diagram)
- [2. Project Source Code Structure](#2-project-source-code-structure)
- [3. Deployed Artifacts Diagram](#3-deployed-artifacts-diagram)
- [Comparison of the Three Perspectives](#comparison-of-the-three-perspectives)
- [Where do DTOs fit?](#where-do-dtos-fit)

I’ll illustrate this with an example of a Products Management vertical slice, where a user can add, update, retrieve, and delete products. Each of these perspectives shows different aspects of the application.


# 1. Logical Architectural Layer Diagram

This diagram shows conceptual layers in the architecture, emphasizing separation of concerns. It’s independent of physical deployment and focuses on the logical responsibilities of the system.

For our "Products Management" example, a common logical layer diagram might include:
```
Presentation Layer
  ↳ Handles user interactions (e.g., ASP.NET MVC Controllers, Blazor Components)
Business Logic Layer
  ↳ Implements domain-specific rules (e.g., ProductService)
Data Access Layer
  ↳ Interacts with the database (e.g., ProductRepository)
Database Layer
  ↳ Physical data storage (e.g., SQL Server)
```
Each layer is logically distinct. For instance:
- The Presentation Layer calls the Business Logic Layer (not directly the database).
- The Business Logic Layer performs business rules (e.g., validate the product’s name or price).
- The Data Access Layer abstracts the database operations, such as querying or persisting data.

Example Flow: A user clicks "Add Product" in the UI → sends data to the Business Logic Layer for validation → passes it to the Data Access Layer to insert into the Database.

# 2. Project Source Code Structure

This shows how the source code is organized in the project. It’s focused on how developers structure the codebase to align with logical layers.

For the Products Management slice, a typical structure might look like this:
```
/ProductsSolution
  /Products.Web          → Presentation Layer (e.g., Controllers, Views, Blazor Components)
  /Products.Services     → Business Logic Layer (e.g., `ProductService.cs`)
  /Products.Data         → Data Access Layer (e.g., `ProductRepository.cs`, DbContext)
  /Products.Tests        → Unit/Integration Tests
```
Here, the code is divided into projects that reflect logical layers, helping developers work modularly. For instance:
- `Products.Web` contains ASP.NET MVC controllers (like `ProductsController.cs`) or Razor pages.
- `Products.Services` contains services implementing business logic (like `ProductService.cs`).
- `Products.Data` contains the database access code (like `ProductRepository.cs` or EF Core DbContext).

# 3. Deployed Artifacts Diagram

This diagram describes how and where the artifacts (compiled assemblies, services, or packages) are deployed in a runtime environment. It’s focused on the physical or logical deployment topology and runtime components.

For our Products Management example, let’s assume this is a web application with a backend API and a database. The deployment might look like this:
```markdown
- Frontend Web Server (e.g., IIS or Azure App Service)
    - Deployed: Presentation Layer artifacts (e.g., `Products.Web.dll` or a Blazor WASM app)
- Backend Application Server
    - Deployed: Business Logic and Data Access artifacts (e.g., `Products.Services.dll` and `Products.Data.dll`)
- Database Server (e.g., SQL Server or Azure SQL)
    - Deployed: The database (e.g., `ProductsDB`)
```
Here, we’re concerned about where the compiled code (DLLs, executables, etc.) and data reside during deployment:
- The frontend artifacts handle user interactions and API requests.
- The backend artifacts host business logic and database interactions.
- The database server stores data like product details.

# Comparison of the Three Perspectives

Perspective|Focus|Example for Products Management
---|---|---
**Logical Architectural Layers**|Conceptual layers (e.g., Presentation, Business Logic, Data Access)|Business Logic Layer validates the product; Data Access Layer interacts with DB
**Project Source Code Structure**|Organization of source code (e.g., folders/projects in a solution)|Separate projects: `Products.Web`, `Products.Services`, `Products.Data`
**Deployed Artifacts Diagram**|Deployment/runtime topology (e.g., physical servers, cloud services)|`Products.Web.dll` on web server, `Products.Data.dll` on backend, SQL DB

Here’s how a typical *Add Product* use case fits into these perspectives:

- **Logical Architectural Layers**:
   1. Presentation Layer: `ProductsController.AddProduct(ProductDto)` receives the HTTP POST request.
   2. Business Logic Layer: `ProductService.AddProduct()` validates the product (e.g., price > 0, name is unique).
   3. Data Access Layer: `ProductRepository.InsertProduct()` saves the product to the database.
- **Project Source Code Structure**:
   1. `/Products.Web`: Contains `ProductsController` and views or API endpoints.
   2. `/Products.Services`: Contains `ProductService` with validation logic.
   3. `/Products.Data`: Contains `ProductRepository` and EF Core DbContext.
- **Deployed Artifacts Diagram**:
   1. Frontend Web Server: Hosts the UI (Blazor app or ASP.NET MVC) and API endpoints.
   2. Backend App Server: Hosts `Products.Services.dll` and `Products.Data.dll`.
   3. Database Server: Hosts the SQL database storing product information.

By thinking in these layers and diagrams, you separate conceptual design (logical layers), runtime deployment (artifacts), and developer organization (source structure). It’s this separation that ensures clarity, maintainability, and scalability in software architecture.

# Where do DTOs fit?

**DTOs (Data Transfer Objects)** are a crucial part of many architectures, but their role can sometimes feel a little ambiguous because they don’t belong neatly to a single logical layer. Instead, they typically facilitate communication between layers, especially when crossing boundaries like between the Presentation Layer and Business Logic Layer.

DTOs are plain objects used to transfer data across application boundaries (e.g., from the frontend to the backend or between layers within the backend). They are simplified representations of data that:
- Contain no behavior (e.g., no business logic or methods).
- Avoid exposing implementation details of other layers (e.g., no direct database entities).
- Are tailored to specific use cases (e.g., a subset of fields for a particular API endpoint).

Business Logic Layer accepts DTOs as input or output from the Presentation Layer but operates on domain models internally. For example, the `ProductService.AddProduct(CreateProductDto dto)` method accepts a DTO and maps it to a domain entity (`Product`) for validation and business rules.

DTOs can be embedded in assemblies like `Products.Web.dll` (for client-server communication) or `Products.Services.dll` (for communication between the Presentation and Business Logic layers).

Alternatively, if multiple layers share DTOs, they might go into a separate shared project:
```markdown
ProductsSolution
  /Products.Shared
    /Dtos
      CreateProductDto.cs
      ProductDetailsDto.cs
  /Products.Web
    ProductsController.cs
  /Products.Services
    ProductService.cs
  /Products.Data
    ProductRepository.cs
```

This ensures clear separation of the DTOs and avoids coupling them too tightly to a specific layer.
