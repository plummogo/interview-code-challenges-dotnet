using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OneBeyond.Core.Dtos;
using OneBeyond.Core.Interfaces;
using OneBeyondApi.DataAccess;

namespace OneBeyond.Infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly ILogger<ILoanRepository> _logger;
        private readonly LibraryContext _context;

        public LoanRepository(ILogger<ILoanRepository> logger, LibraryContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<LoanDto> GetLoans()
        {
            _logger.LogInformation($"{nameof(GetLoans)} has been started");

            try
            {
                var onLoanBooks = _context.Catalogue
                                  .Include(bs => bs.Book)
                                  .Include(bs => bs.OnLoanTo)
                                  .Where(bs => bs.OnLoanTo != null && bs.LoanEndDate > DateTime.UtcNow);


                var result = onLoanBooks.GroupBy(bs => bs.OnLoanTo)
                                        .Select(g => new LoanDto
                                        {
                                            Name = g.Key.Name,
                                            Email = g.Key.EmailAddress,
                                            BookTitles = g.Select(bs => bs.Book.Name).ToList()
                                        });
                _logger.LogInformation($"{nameof(GetLoans)} has been finished");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(GetLoans)} has error, message: {ex.Message}");
                throw new Exception($"Unexpected error occurred: {ex.Message}", ex);
            }
        }
    }
}
