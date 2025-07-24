using Microsoft.Extensions.Logging;
using OneBeyondApi.Model;

namespace OneBeyondApi.DataAccess
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ILogger<IAuthorRepository> _logger;
        private readonly LibraryContext _context;

        public AuthorRepository(ILogger<IAuthorRepository> logger, LibraryContext context)
        {
            _logger = logger;
            _context = context;
        }

        public List<Author> GetAuthors()
        {
            _logger.LogInformation($"{nameof(GetAuthors)} has been started");

            try
            {
                var result = _context.Authors.ToList();

                _logger.LogInformation($"{nameof(GetAuthors)} has been finished with count: {result.Count}");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(GetAuthors)} has error, message: {ex.Message}");
                throw new Exception($"Unexpected error occurred: {ex.Message}", ex);
            }
        }

        public Guid AddAuthor(Author author)
        {
            _logger.LogInformation($"{nameof(AddAuthor)} has been started");

            try
            {
                _context.Authors.Add(author);

                _context.SaveChanges();

                _logger.LogInformation($"{nameof(AddAuthor)} has been finished for Id: {author.Id}");

                return author.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(AddAuthor)} has error, message: {ex.Message}");
                throw new Exception($"Unexpected error occurred: {ex.Message}", ex);
            }
        }
    }
}
