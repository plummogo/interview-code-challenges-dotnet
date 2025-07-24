using Microsoft.AspNetCore.Mvc;
using OneBeyondApi.DataAccess;
using OneBeyondApi.Model;

namespace OneBeyondApi.Controllers
{
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