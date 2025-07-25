using Microsoft.AspNetCore.Mvc;
using OneBeyond.Core.Dtos;
using OneBeyond.Core.Interfaces;

namespace OneBeyondApi.Controllers
{
    /// <summary>
    /// LoanController is responsible for managing book loans in the library system.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly ILogger<LoanController> _logger;
        private readonly ILoanRepository _loanRepository;

        public LoanController(ILogger<LoanController> logger, ILoanRepository loanRepository)
        {
            _logger = logger;
            _loanRepository = loanRepository;
        }

        /// <summary>
        /// Gets a list of all loans in the library system.
        /// </summary>
        /// <returns>list of loans</returns>
        [HttpGet]
        [Route("onloan")]
        [ProducesResponseType(typeof(IEnumerable<LoanDto>), 200)]
        [ProducesResponseType(500)]
        public ActionResult<IEnumerable<LoanDto>> Get()
        {
            _logger.LogInformation($"{nameof(Get)} has been started");

            try
            {
                var result = _loanRepository.GetLoans();

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
        /// Returns a book by its stock ID.
        /// </summary>
        /// <param name="bookStockId">Book stock id</param>
        /// <returns>Returned book id</returns>
        [HttpPost]
        [Route("onreturn")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(500)]
        public ActionResult<Guid> ReturnBook([FromBody] Guid bookStockId)
        {
            _logger.LogInformation($"{nameof(ReturnBook)} has been started");

            try
            {
                if (bookStockId.Equals(Guid.Empty))
                {
                    _logger.LogWarning($"{nameof(ReturnBook)} has warning, message: Invalid book stock ID provided.");
                    return BadRequest("Invalid book stock ID provided.");
                }

                var result = _loanRepository.ReturnBook(bookStockId);

                _logger.LogInformation($"{nameof(ReturnBook)} has been finished");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(ReturnBook)} has error, message: {ex.Message}");
                return StatusCode(500, $"Unexpected error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Reserves a book for a borrower by their ID.
        /// </summary>
        /// <param name="borrowerId">The one's id who borrowes</param>
        /// <returns>true/false if it is successfully</returns>
        [HttpPost]
        [Route("onreserve")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(500)]
        public ActionResult<bool> ReserveBook([FromBody] Guid borrowerId)
        {
            _logger.LogInformation($"{nameof(ReserveBook)} has been started");

            try
            {
                if (borrowerId.Equals(Guid.Empty))
                {
                    _logger.LogWarning($"{nameof(ReserveBook)} has warning, message: Invalid borrower ID provided.");
                    return BadRequest("Invalid borrower ID provided.");
                }

                var result = _loanRepository.ReserveBook(borrowerId);

                _logger.LogInformation($"{nameof(ReserveBook)} has been finished");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(ReserveBook)} has error, message: {ex.Message}");
                return StatusCode(500, $"Unexpected error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets the reservation status of a borrower by their ID.
        /// </summary>
        /// <param name="borrowerId">Who borrowed the book</param>
        /// <param name="isbn">The book id</param>
        /// <returns>Queue and date</returns>
        [HttpGet]
        [Route("onstatus")]
        [ProducesResponseType(typeof(ReservationStatusDto), 200)]
        [ProducesResponseType(500)]
        public ActionResult<ReservationStatusDto> GetReservationStatus([FromQuery] Guid borrowerId, [FromQuery] string isbn)
        {
            _logger.LogInformation($"{nameof(GetReservationStatus)} has been started");

            try
            {
                if (borrowerId.Equals(Guid.Empty))
                {
                    _logger.LogWarning($"{nameof(ReserveBook)} has warning, message: Invalid borrower ID provided.");
                    return BadRequest("Invalid borrower ID provided.");
                }

                var result = _loanRepository.GetReservationStatus(borrowerId);

                _logger.LogInformation($"{nameof(GetReservationStatus)} has been finished");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(GetReservationStatus)} has error, message: {ex.Message}");
                return StatusCode(500, $"Unexpected error occurred: {ex.Message}");
            }
        }
    }
}
