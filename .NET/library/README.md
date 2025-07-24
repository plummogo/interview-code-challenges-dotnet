# Project Structure
## OneBeyond.Core
Purpose: Domain entities, interfaces, and business logic contracts only

Contains:
- Entities/Domain models (e.g., Author, Book)
- Interfaces/Repository (e.g., IAuthorRepository, IAuthorService)
- No dependencies on EF, Infrastructure, or API projects
- Service interfaces is not needful, but can be added later if needed (short reason: too short business logic)

References: None

## OneBeyond.Infrastructure
Purpose: Data access implementation using EF Core, repository classes, DbContext, migrations

Contains:

- Data/ — LibraryContext.cs, EF migrations, seed data (SeedData.cs)
- Repositories/ — Repository implementations (e.g., AuthorRepository)

References: Depends on OneBeyond.Core (to implement interfaces and use domain models)

## OneBeyondApi
Purpose: ASP.NET Core Web API project handling HTTP requests and dependency injection

Contains:

- Controllers (e.g., AuthorsController)
- Startup/Program setup with DI configuration for services and repositories

References: Depends on both OneBeyond.Core and OneBeyond.Infrastructure


# Coding Guidelines

## Controller Guidelines

1. Decorators / Attributes
- Use [ApiController] to enable automatic model validation and response formatting.
- Use [Route("[controller]")] at the class level for consistent routing.
- Define action routes explicitly using [Route("actionname")] to avoid ambiguity.

2. Constructor
- Inject required dependencies (e.g., ILogger<T>, repository interfaces) via constructor injection.
- Store injected services in private readonly fields.

```csharp
private readonly ILogger<LoanController> _logger;
private readonly ILoanRepository _loanRepository;
```

3. Logging
- Log the start and end of each action method using _logger.LogInformation.
- Log exceptions using _logger.LogError, including ex and ex.Message.

```csharp
_logger.LogInformation($"{nameof(Get)} has been started");
_logger.LogError(ex, $"{nameof(Get)} has error, message: {ex.Message}");
```

4. Response Types
- Use [ProducesResponseType] to describe possible responses.
- Return appropriate ActionResult<T> types, e.g., Ok(result), StatusCode(500).

5. Error Handling
- Use try-catch in each action method.
- Return a 500 status code and a clear error message in case of failure.


## Repository Guidelines
1. Constructor
- Inject ILogger<T> and the DbContext via constructor injection.
- Store them in readonly fields.

```csharp
private readonly ILogger<ILoanRepository> _logger;
private readonly LibraryContext _context;
```

2. Logging
- Log method start and completion using _logger.LogInformation.
- Log exceptions with _logger.LogError.

3. Data Access
- Use Entity Framework Core (DbContext) to access and query the database.
- Use .Include() for related entities and .Where() for filtering logic.
- Use projection (Select) to return DTOs rather than entities.

4. Exception Handling
- Wrap logic in try-catch.
- Log and rethrow a descriptive exception with inner exception.

```csharp
catch (Exception ex)
{
    _logger.LogError(ex, $"{nameof(GetLoans)} has error, message: {ex.Message}");
    throw new Exception($"Unexpected error occurred: {ex.Message}", ex);
}
```

# LoanAPI description

## LoanController

### Location
`/Controllers/LoanController.cs`

### Purpose
Handles HTTP requests related to loans, particularly the retrieval of currently loaned books and their borrowers.

### Attributes

```csharp
[ApiController]
[Route("[controller]")]
[ApiController]: Enables automatic model binding and validation.
[Route("[controller]")]: Maps the route to /loan.
```

### Dependencies
- Injected via constructor using ASP.NET Core's built-in Dependency Injection.
- Logging and data access are both delegated to external services.
```csharp
private readonly ILogger<LoanController> _logger;
private readonly ILoanRepository _loanRepository;
```

## LoanRepository
### Location
/Repositories/LoanRepository.cs

### Purpose
Handles all data retrieval related to currently loaned books from the LibraryContext.

### Method: GetLoans()
- Filters for records where the loan hasn't ended (LoanEndDate > DateTime.UtcNow).
- Includes related entities: Book, OnLoanTo.
- Groups results by the borrower.
- Projects results into a DTO:

```csharp
.Select(g => new LoanDto {
    Name = g.Key.Name,
    Email = g.Key.EmailAddress,
    BookTitles = g.Select(bs => bs.Book.Name).ToList()
});
```

### LoadDto
This is the data returned to the client. Properties include:

```csharp
public class LoanDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public List<string> BookTitles { get; set; }
}
```