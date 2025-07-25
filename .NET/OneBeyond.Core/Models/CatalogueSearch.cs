namespace OneBeyondApi.Model
{
    /// <summary>
    /// CatralogueSearch class represents a search query for books in a catalogue.
    /// </summary>
    public class CatalogueSearch
    {
        /// <summary>
        /// BookName is the name of the book to search for.
        /// </summary>
        public string BookName { get; set; }

        /// <summary>
        /// Author is the name of the author of the book to search for.
        /// </summary>
        public string Author { get; set; }
    }
}
