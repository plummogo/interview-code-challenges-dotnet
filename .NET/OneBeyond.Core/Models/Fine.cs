using OneBeyondApi.Model;

namespace OneBeyond.Core.Models
{
    /// <summary>
    /// Fine represents a monetary penalty issued to a borrower for overdue items or other violations.
    /// </summary>
    public class Fine
    {
        /// <summary>
        /// Identifier for the fine.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Borrower associated with the fine.
        /// </summary>
        public Guid BorrowerId { get; set; }

        /// <summary>
        /// Borrower who is responsible for the fine.
        /// </summary>
        public Borrower Borrower { get; set; }

        /// <summary>
        /// Amount of the fine. 
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Isssued date of the fine.
        /// </summary>
        public DateTime IssuedDate { get; set; }

        /// <summary>
        /// Ispaid status of the fine.
        /// </summary>
        public bool IsPaid { get; set; } = false;
    }
}
