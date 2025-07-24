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
