using OneBeyondApi.Model;

namespace OneBeyondApi.DataAccess
{
    /// <summary>
    /// Interface for managing borrowers in the library system.
    /// </summary>
    public interface IBorrowerRepository
    {
        /// <summary>
        /// Gets a list of all borrowers.
        /// </summary>
        /// <returns>List of borrowers</returns>
        public List<Borrower> GetBorrowers();

        /// <summary>
        /// Adds a new borrower to the repository.
        /// </summary>
        /// <param name="borrower"></param>
        /// <returns>Newly added borrower id</returns>
        public Guid AddBorrower(Borrower borrower);
    }
}
