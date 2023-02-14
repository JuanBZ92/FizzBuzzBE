using FizzBuzz.Models;
using FizzBuzz.Services;
using Microsoft.AspNetCore.Mvc;

namespace FizzBuzz.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FizzBuzzController : ControllerBase
    {

        private readonly ILogger<FizzBuzzController> _logger;
        private readonly IFizzBuzzService _fizzBuzzService;

        public FizzBuzzController(ILogger<FizzBuzzController> logger, IFizzBuzzService fizzBuzzService)
        {
            _logger = logger;
            _fizzBuzzService = fizzBuzzService;
        }

        [HttpPost]
        public async Task<IActionResult> FizzBuzz(FizzBuzzRequest request)
        {
            try
            {
                if (request.Limit == 0)
                {
                    return BadRequest("Limit can´t be 0. Please use a number bigger than 1");
                }

                var result = _fizzBuzzService.CreateFizzBuzzList(request);
                await _fizzBuzzService.CreateFizzBuzzFile(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error message :: {ex.Message}");
                return BadRequest();
            }
        }
    }
}