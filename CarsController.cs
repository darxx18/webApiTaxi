using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webApiTaxi
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarsService _carsService;

        public CarsController(ICarsService carsService)
        {
            _carsService = carsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cars>>> GetCars()
        {
            var cars = await _carsService.GetAllCarsAsync();
            return Ok(cars);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<Cars>> GetCars(int ID)
        {
            var cars = await _carsService.GetCarsByIdAsync(ID);
            if (cars == null)
            {
                return NotFound();
            }
            return Ok(cars);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCar(Cars car)
        {
            await _carsService.CreateCarAsync(car);
            return CreatedAtAction(nameof(GetCars), new { ID = car.ID }, car);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCar(Cars car)
        {
            await _carsService.UpdateCarAsync(car);
            return NoContent();
        }

        [HttpDelete("{ID}")]
        public async Task<ActionResult> DeleteCar(int ID)
        {
            await _carsService.DeleteCarAsync(ID);
            return NoContent();
        }
    }
}
