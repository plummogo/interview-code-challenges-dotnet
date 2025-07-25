using Microsoft.AspNetCore.Mvc;
using OneBeyondApi.DataAccess;
using OneBeyondApi.Model;

namespace OneBeyondApi.Controllers
{
    /// <summary>
    /// BorrowerController is responsible for managing borrowers in the library system.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class BorrowerController : ControllerBase
    {
        private readonly ILogger<BorrowerController> _logger;
        private readonly IBorrowerRepository _borrowerRepository;

        public BorrowerController(ILogger<BorrowerController> logger, IBorrowerRepository borrowerRepository)
        {
            _logger = logger;
            _borrowerRepository = borrowerRepository;
        }

        /// <summary>
        /// Gets a list of all borrowers in the library system.
        /// </summary>
        /// <returns>List of borrowers</returns>
        [HttpGet]
        [Route("GetBorrowers")]
        [ProducesResponseType(typeof(IList<Borrower>), 200)]
        [ProducesResponseType(500)]
        public ActionResult<IList<Borrower>> Get()
        {
            _logger.LogInformation($"{nameof(Get)} has been started");

            try
            {
                var result = _borrowerRepository.GetBorrowers();

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
        /// Adds a new borrower to the library system.
        /// </summary>
        /// <param name="borrower">The borrower what is being saved</param>
        /// <returns>Newly saved borrower id</returns>
        [HttpPost]
        [Route("AddBorrower")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(500)]
        public ActionResult<Guid> Post(Borrower borrower)
        {
            _logger.LogInformation($"{nameof(Post)} has been started");

            try
            {
                var result = _borrowerRepository.AddBorrower(borrower);

                _logger.LogInformation($"{nameof(Get)} has been finished");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(Get)} has error, message: {ex.Message}");
                return StatusCode(500, $"Unexpected error occurred: {ex.Message}");
            }
        }
    }
}