using Microsoft.Extensions.Logging;
using OneBeyondApi.Model;

namespace OneBeyondApi.DataAccess
{
    public class BookRepository : IBookRepository
    {
        private readonly ILogger<IBookRepository> _logger;
        private readonly LibraryContext _context;

        public BookRepository(ILogger<IBookRepository> logger, LibraryContext context)
        {
            _logger = logger;
            _context = context;
        }

        public List<Book> GetBooks()
        {
            _logger.LogInformation($"{nameof(GetBooks)} has been started");

            try
            {
                var result = _context.Books.ToList();

                _logger.LogInformation($"{nameof(GetBooks)} has been finished with count: {result.Count}");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(GetBooks)} has error, message: {ex.Message}");
                throw new Exception($"Unexpected error occurred: {ex.Message}", ex);
            }
        }

        public Guid AddBook(Book book)
        {
            _logger.LogInformation($"{nameof(AddBook)} has been started");

            try
            {
                _context.Books.Add(book);

                _context.SaveChanges();

                _logger.LogInformation($"{nameof(AddBook)} has been finished for Id: {book.Id}");

                return book.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(AddBook)} has error, message: {ex.Message}");
                throw new Exception($"Unexpected error occurred: {ex.Message}", ex);
            }
        }
    }
}
