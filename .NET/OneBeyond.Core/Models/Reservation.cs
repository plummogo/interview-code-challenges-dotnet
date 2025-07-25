using OneBeyondApi.Model;

namespace OneBeyond.Core.Models
{
    /// <summary>
    /// Reservation represents a request by a borrower to hold a book stock item for future borrowing.
    /// </summary>
    public class Reservation
    {
        /// <summary>
        /// Identifier for the reservation.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Book stock Identifier associated with the reservation.
        /// </summary>
        public Guid BookStockId { get; set; }

        /// <summary>
        /// Book stock item that is reserved.
        /// </summary>
        public BookStock BookStock { get; set; }

        /// <summary>
        /// Borrower Identifier who made the reservation.
        /// </summary>
        public Guid BorrowerId { get; set; }

        /// <summary>
        /// Borrower who made the reservation.
        /// </summary>
        public Borrower Borrower { get; set; }

        /// <summary>
        /// Reservation date and time.
        /// </summary>
        public DateTime ReservedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// isFulfilled status of the reservation.
        /// </summary>
        public bool IsFulfilled { get; set; } = false;
    }
}
