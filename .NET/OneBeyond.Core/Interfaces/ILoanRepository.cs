using OneBeyond.Core.Dtos;

namespace OneBeyond.Core.Interfaces
{
    public interface ILoanRepository
    {
        public IEnumerable<LoanDto> GetLoans();

    }
}
