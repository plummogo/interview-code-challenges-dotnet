using Microsoft.AspNetCore.Mvc;
using OneBeyondApi.DataAccess;
using OneBeyondApi.Model;

namespace OneBeyondApi.Controllers
{
    /// <summary>
    /// BookController provides endpoints for managing books in the library system.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookRepository _bookRepository;

        public BookController(ILogger<BookController> logger, IBookRepository bookRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
        }

        /// <summary>
        /// Gets a list of all books in the library system.
        /// </summary>
        /// <returns>List of books</returns>
        [HttpGet]
        [Route("GetBooks")]
        [ProducesResponseType(typeof(IList<Book>), 200)]
        [ProducesResponseType(500)]
        public ActionResult<IList<Book>> Get()
        {
            _logger.LogInformation($"{nameof(Get)} has been started");

            try
            {
                var result = _bookRepository.GetBooks();

                _logger.LogInformation($"{nameof(Get)} has been finished");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(Get)} has error, message: {ex.Message}");
                return StatusCode(500, $"Unexpected error occurred: {ex.Message}");
            }

        }

        /// <summary>
        /// Adds a new book to the library system.
        /// </summary>
        /// <param name="book">The book what is being saved</param>
        /// <returns>Newly added book id</returns>
        [HttpPost]
        [Route("AddBook")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(500)]
        public ActionResult<Guid> Post(Book book)
        {
            _logger.LogInformation($"{nameof(Post)} has been started");

            try
            {
                var result = _bookRepository.AddBook(book);

                _logger.LogInformation($"{nameof(Post)} has been finished");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(Post)} has error, message: {ex.Message}");
                return StatusCode(500, $"Unexpected error occurred: {ex.Message}");
            }
        }
    }
}