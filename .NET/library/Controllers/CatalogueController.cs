using Microsoft.AspNetCore.Mvc;
using OneBeyondApi.DataAccess;
using OneBeyondApi.Model;

namespace OneBeyondApi.Controllers
{
    /// <summary>
    /// CatalogueController is responsible for managing the library catalogue.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CatalogueController : ControllerBase
    {
        private readonly ILogger<CatalogueController> _logger;
        private readonly ICatalogueRepository _catalogueRepository;

        public CatalogueController(ILogger<CatalogueController> logger, ICatalogueRepository catalogueRepository)
        {
            _logger = logger;
            _catalogueRepository = catalogueRepository;
        }

        /// <summary>
        /// Gets a list of all books in the library catalogue.
        /// </summary>
        /// <returns>List of catalogues</returns>
        [HttpGet]
        [Route("GetCatalogue")]
        [ProducesResponseType(typeof(IList<BookStock>), 200)]
        [ProducesResponseType(500)]
        public ActionResult<IList<BookStock>> Get()
        {
            _logger.LogInformation($"{nameof(Get)} has been started");

            try
            {
                var result = _catalogueRepository.GetCatalogue();

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
        /// Searches the library catalogue based on the provided search criteria.
        /// </summary>
        /// <param name="search">Search by either title or author name</param>
        /// <returns>the found book stock list</returns>
        [HttpPost]
        [Route("SearchCatalogue")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(500)]
        public ActionResult<IList<BookStock>> Post(CatalogueSearch search)
        {
            _logger.LogInformation($"{nameof(Post)} has been started");

            try
            {
                var result = _catalogueRepository.SearchCatalogue(search);

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