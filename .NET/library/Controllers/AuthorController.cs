using Microsoft.AspNetCore.Mvc;
using OneBeyondApi.DataAccess;
using OneBeyondApi.Model;

namespace OneBeyondApi.Controllers
{
    /// <summary>
    /// AuthorController provides endpoints for managing authors in the library system.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly ILogger<AuthorController> _logger;
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(ILogger<AuthorController> logger, IAuthorRepository authorRepository)
        {
            _logger = logger;
            _authorRepository = authorRepository;
        }

        /// <summary>
        /// Gets a list of all authors in the library system.
        /// </summary>
        /// <returns>List of Authors</returns>
        [HttpGet]
        [Route("GetAuthors")]
        [ProducesResponseType(typeof(IList<Author>), 200)]
        [ProducesResponseType(500)]
        public ActionResult<IList<Author>> Get()
        {
            _logger.LogInformation($"{nameof(Get)} has been started");

            try
            {
                var result = _authorRepository.GetAuthors();

                _logger.LogInformation($"{nameof(Get)} has been finished");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(Get)} has error, message: {ex.Message}");
                return StatusCode(500, $"Unexpected error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Adds a new author to the library system.
        /// </summary>
        /// <param name="author">The author what is being saved</param>
        /// <returns>Newly added autheor id</returns>
        [HttpPost]
        [Route("AddAuthor")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(500)]
        public ActionResult<Guid> Post(Author author)
        {
            _logger.LogInformation($"{nameof(Post)} has been started");

            try
            {
                var result = _authorRepository.AddAuthor(author);

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