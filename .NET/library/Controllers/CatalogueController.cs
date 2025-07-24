using Microsoft.AspNetCore.Mvc;
using OneBeyondApi.DataAccess;
using OneBeyondApi.Model;

namespace OneBeyondApi.Controllers
{
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