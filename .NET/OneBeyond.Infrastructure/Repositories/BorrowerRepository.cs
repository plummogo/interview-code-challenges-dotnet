using Microsoft.Extensions.Logging;
using OneBeyondApi.Model;

namespace OneBeyondApi.DataAccess
{
    public class BorrowerRepository : IBorrowerRepository
    {
        private readonly ILogger<IBorrowerRepository> _logger;
        private readonly LibraryContext _context;

        public BorrowerRepository(ILogger<IBorrowerRepository> logger, LibraryContext context)
        {
            _logger = logger;
            _context = context;
        }
        public List<Borrower> GetBorrowers()
        {
            _logger.LogInformation($"{nameof(GetBorrowers)} has been started");

            try
            {
                var result = _context.Borrowers.ToList();

                _logger.LogInformation($"{nameof(GetBorrowers)} has been finished with count: {result.Count}");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(GetBorrowers)} has error, message: {ex.Message}");
                throw new Exception($"Unexpected error occurred: {ex.Message}", ex);
            }
        }

        public Guid AddBorrower(Borrower borrower)
        {
            _logger.LogInformation($"{nameof(AddBorrower)} has been started");

            try
            {
                _context.Borrowers.Add(borrower);

                _context.SaveChanges();

                _logger.LogInformation($"{nameof(AddBorrower)} has been finished for Id: {borrower.Id}");

                return borrower.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(AddBorrower)} has error, message: {ex.Message}");
                throw new Exception($"Unexpected error occurred: {ex.Message}", ex);
            }
        }
    }
}
