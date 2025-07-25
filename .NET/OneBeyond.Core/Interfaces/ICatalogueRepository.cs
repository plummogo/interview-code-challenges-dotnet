using OneBeyondApi.Model;

namespace OneBeyondApi.DataAccess
{
    /// <summary>
    /// Repository interface for managing the library catalogue.
    /// </summary>
    public interface ICatalogueRepository
    {
        /// <summary>
        /// Gets a list of all books in the catalogue.
        /// </summary>
        /// <returns>list of all book stocks</returns>
        public List<BookStock> GetCatalogue();

        /// <summary>
        /// Searches the catalogue based on the provided search criteria.
        /// </summary>
        /// <param name="search">Search by either book name or author</param>
        /// <returns>list of book stocks</returns>
        public List<BookStock> SearchCatalogue(CatalogueSearch search);
    }
}
