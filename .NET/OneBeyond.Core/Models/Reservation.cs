using OneBeyondApi.Model;

namespace OneBeyond.Core.Models
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public Guid BookStockId { get; set; }
        public BookStock BookStock { get; set; }
        public Guid BorrowerId { get; set; }
        public Borrower Borrower { get; set; }
        public DateTime ReservedAt { get; set; } = DateTime.UtcNow;
        public bool IsFulfilled { get; set; } = false;
    }
}
