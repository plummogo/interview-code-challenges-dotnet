using OneBeyond.Core.Dtos;

namespace OneBeyond.Core.Interfaces
{
    /// <summary>
    /// Repository interface for managing loans in the library system.
    /// </summary>
    public interface ILoanRepository
    {
        /// <summary>
        /// Gets a list of all loans.
        /// </summary>
        /// <returns>list of loans</returns>
        public IEnumerable<LoanDto> GetLoans();

        /// <summary>
        /// Gets the reservation status of a borrower by their ID.
        /// </summary>
        /// <param name="borrowerId">search condition for getting reservation</param>
        /// <returns>ReservationStatusDto which contains position and date</returns>
        public ReservationStatusDto GetReservationStatus(Guid borrowerId);

        /// <summary>
        /// Reserves a book for a borrower by their ID.
        /// </summary>
        /// <param name="borrowerId">required for reserve a book</param>
        /// <returns>true/false if it is successfully to reserve </returns>
        public bool ReserveBook(Guid borrowerId);

        /// <summary>
        /// Returns a book by its stock ID.
        /// </summary>
        /// <param name="bookStockId">required for return the book</param>
        /// <returns>the id of the book</returns>
        public Guid ReturnBook(Guid bookStockId);
    }
}
