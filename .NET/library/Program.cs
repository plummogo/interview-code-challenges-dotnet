using Microsoft.EntityFrameworkCore;
using OneBeyond.Core.Interfaces;
using OneBeyond.Infrastructure.Repositories;
using OneBeyondApi;
using OneBeyondApi.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Registreting LibraryContext to IoC container.
// Using InMemoryDatabase,storing data in RAM
builder.Services.AddDbContext<LibraryContext>(options => options.UseInMemoryDatabase("LibraryDB"));

#region Register Services-Interfaces to the container
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBorrowerRepository, BorrowerRepository>();
builder.Services.AddScoped<ICatalogueRepository, CatalogueRepository>();
builder.Services.AddScoped<ILoanRepository, LoanRepository>();
builder.Services.AddControllers();
#endregion

#region Registering Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

var app = builder.Build();

// New scope for access LibraryContext instance.
// In DI container, we can access DbContext and initialize database or seed data.
using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<LibraryContext>();

#region Seeding dummy data into the in-memory database
SeedData.SetInitialData(context);
#endregion

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
