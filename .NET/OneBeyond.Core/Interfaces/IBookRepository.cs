using OneBeyondApi.Model;

namespace OneBeyondApi.DataAccess
{
    /// <summary>
    /// Repository interface for managing books.
    /// </summary>
    public interface IBookRepository
    {
        /// <summary>
        /// Gets a list of all books.
        /// </summary>
        /// <returns> List of books </returns>
        public List<Book> GetBooks();

        /// <summary>
        /// Adds a new book to the repository.
        /// </summary>
        /// <param name="book"></param>
        /// <returns>The added book id</returns>
        public Guid AddBook(Book book);
    }
}
