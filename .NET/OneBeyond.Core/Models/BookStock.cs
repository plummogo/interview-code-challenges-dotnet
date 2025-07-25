using OneBeyond.Core.Models;

namespace OneBeyondApi.Model
{
    public class BookStock
    {
        public Guid Id { get; set; }
        public Book Book { get; set; }
        public DateTime? LoanEndDate { get; set; }
        public Borrower? OnLoanTo { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
