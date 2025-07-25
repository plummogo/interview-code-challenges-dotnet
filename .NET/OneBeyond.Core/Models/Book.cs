using OneBeyond.Core.Dtos;

namespace OneBeyondApi.Model
{
    /// <summary>
    /// Book model representing a book in the library system.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Identifier for the book.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name of the book.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Author of the book.
        /// </summary>
        public Author Author { get; set; }

        /// <summary>
        /// Book format (e.g., Hardcover, Paperback, eBook).
        /// </summary>
        public BookFormat Format { get; set; }

        /// <summary>
        /// ISBN (International Standard Book Number) of the book.
        /// </summary>
        public string ISBN { get; set; }
    }
}
