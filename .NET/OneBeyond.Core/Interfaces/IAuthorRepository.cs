using OneBeyondApi.Model;

namespace OneBeyondApi.DataAccess
{
    /// <summary>
    /// Reoisitory interface for managing authors.
    /// </summary>
    public interface IAuthorRepository
    {
        /// <summary>
        /// Fetches all authors.
        /// </summary>
        /// <returns>List of authors</returns>
        public List<Author> GetAuthors();

        /// <summary>
        /// Adds a new author to the repository.
        /// </summary>
        /// <param name="author">The object what we are saving</param>
        /// <returns>Newly added author id</returns>
        public Guid AddAuthor(Author author);
    }
}
