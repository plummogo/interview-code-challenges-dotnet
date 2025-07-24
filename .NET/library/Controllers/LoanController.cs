using Microsoft.AspNetCore.Mvc;
using OneBeyond.Core.Dtos;
using OneBeyond.Core.Interfaces;

namespace OneBeyondApi.Controllers
{
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
    }
}
