using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OneBeyondApi.Model;

namespace OneBeyondApi.DataAccess
{
    public class CatalogueRepository : ICatalogueRepository
    {
        private readonly ILogger<ICatalogueRepository> _logger;
        private readonly LibraryContext _context;

        public CatalogueRepository(ILogger<ICatalogueRepository> logger, LibraryContext context)
        {
            _logger = logger;
            _context = context;
        }

        public List<BookStock> GetCatalogue()
        {
            _logger.LogInformation($"{nameof(GetCatalogue)} has been started");

            try
            {
                var result = _context.Catalogue
                                    .Include(x => x.Book)
                                    .ThenInclude(x => x.Author)
                                    .Include(x => x.OnLoanTo)
                                    .ToList();

                _logger.LogInformation($"{nameof(GetCatalogue)} has been finished with count: {result.Count}");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(GetCatalogue)} has error, message: {ex.Message}");
                throw new Exception($"Unexpected error occurred: {ex.Message}", ex);
            }
        }

        public List<BookStock> SearchCatalogue(CatalogueSearch search)
        {
            _logger.LogInformation($"{nameof(SearchCatalogue)} has been started");

            try
            {
                var result = _context.Catalogue
                                     .Include(x => x.Book)
                                     .ThenInclude(x => x.Author)
                                     .Include(x => x.OnLoanTo)
                                     .AsQueryable();

                if (search is null || (string.IsNullOrEmpty(search.Author) && string.IsNullOrEmpty(search.BookName)))
                {
                    _logger.LogError($"{nameof(SearchCatalogue)} has been finished with no search criteria.");
                    throw new Exception($"{nameof(SearchCatalogue)} has been finished with no search criteria.");
                }

                result = !string.IsNullOrEmpty(search.Author) 
                         ? result.Where(x => x.Book.Author.Name.Contains(search.Author)) 
                         : !string.IsNullOrEmpty(search.BookName) 
                            ? result.Where(x => x.Book.Name.Contains(search.BookName))
                            : null;

                if (result is null)
                {
                    _logger.LogError($"{nameof(SearchCatalogue)} has been finished with no result.");
                    throw new Exception($"{nameof(SearchCatalogue)} has been finished with no result.");
                }

                _logger.LogInformation($"{nameof(SearchCatalogue)} has been finished with count: { result.ToList().Count}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(SearchCatalogue)} has error, message: {ex.Message}");
                throw new Exception($"Unexpected error occurred: {ex.Message}", ex);
            }
        }
    }
}
