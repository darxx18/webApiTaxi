using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webApiTaxi
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        private readonly IRateService _rateService;

        public RateController(IRateService rateService)
        {
            _rateService = rateService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rate>>> GetRate()
        {
            var rate = await _rateService.GetAllRateAsync();
            return Ok(rate);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<Rate>> GetRate(int ID)
        {
            var rate = await _rateService.GetRateByIdAsync(ID);
            if (rate == null)
            {
                return NotFound();
            }
            return Ok(rate);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRate(Rate rate)
        {
            await _rateService.CreateRateAsync(rate);
            return CreatedAtAction(nameof(GetRate), new { ID = rate.ID }, rate);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateRate(Rate rate)
        {
            await _rateService.UpdateRateAsync(rate);
            return NoContent();
        }

        [HttpDelete("{ID}")]
        public async Task<ActionResult> DeleteRate(int ID)
        {
            await _rateService.DeleteRateAsync(ID);
            return NoContent();
        }
    }
}
