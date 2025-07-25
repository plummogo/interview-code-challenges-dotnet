using OneBeyond.Core.Models;

namespace OneBeyondApi.Model
{
    /// <summary>
    /// Borrower model representing a person who borrows books from the library system.
    /// </summary>
    public class Borrower
    {
        /// <summary>
        /// Identifier for the borrower.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name of the borrower.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Email address of the borrower.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Fines associated with the borrower, if any.
        /// </summary>
        public ICollection<Fine> Fines { get; set; } = new List<Fine>();

        /// <summary>
        /// Reservations made by the borrower for books.
        /// </summary>
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
