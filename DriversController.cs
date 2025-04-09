using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webApiTaxi
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly IDriversService _driversService;

        public DriversController(IDriversService driversService)
        {
            _driversService = driversService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Drivers>>> GetDrivers()
        {
            var driver = await _driversService.GetAllDriverAsync();
            return Ok(driver);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<Drivers>> GetDrivers(int ID)
        {
            var driver = await _driversService.GetDriverByIdAsync(ID);
            if (driver == null)
            {
                return NotFound();
            }
            return Ok(driver);
        }

        [HttpPost]
        public async Task<ActionResult> CreateDriver(Drivers driver)
        {
            await _driversService.CreateDriverAsync(driver);
            return CreatedAtAction(nameof(GetDrivers), new { ID = driver.ID }, driver);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateDriver(Drivers driver)
        {
            await _driversService.UpdateDriverAsync(driver);
            return NoContent();
        }

        [HttpDelete("{ID}")]
        public async Task<ActionResult> DeleteDriver(int ID)
        {
            await _driversService.DeleteDriverAsync(ID);
            return NoContent();
        }
    }
}
