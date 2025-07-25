namespace OneBeyond.Core.Dtos
{
    /// <summary>
    /// DTO for loan information.
    /// </summary>
    public class LoanDto
    {
        /// <summary>
        /// Get or sets the name of the borrower.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Get or sets the email of the borrower.
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// Gets or sets the collection of book titles which are currently borrowed.
        /// </summary>
        public List<string> BookTitles { get; set; }
    }
}
