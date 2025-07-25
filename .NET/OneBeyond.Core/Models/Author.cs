namespace OneBeyondApi.Model
{
    /// <summary>
    /// Author model representing a book author.
    /// </summary>
    public class Author
    {
        /// <summary>
        /// Identifier for the author.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name of the author.
        /// </summary>
        public string Name { get; set; }
    }
}
