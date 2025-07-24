using OneBeyondApi.Model;

namespace OneBeyond.Core.Models
{
    public class Fine
    {
        public Guid Id { get; set; }
        public Guid BorrowerId { get; set; }
        public Borrower Borrower { get; set; }
        public decimal Amount { get; set; }
        public DateTime IssuedDate { get; set; }
        public bool IsPaid { get; set; } = false;
    }
}
