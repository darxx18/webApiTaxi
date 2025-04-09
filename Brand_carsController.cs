using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webApiTaxi
{
    [Route("api/[controller]")]
    [ApiController]
    public class Brand_carsController : ControllerBase
    {
        private readonly IBrand_carsService _brandService;

        public Brand_carsController(IBrand_carsService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand_cars>>> GetBrand()
        {
            var brand = await _brandService.GetAllBrandAsync();
            return Ok(brand);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<Brand_cars>> GetBrand(int ID)
        {
            var brand = await _brandService.GetBrandByIdAsync(ID);
            if (brand == null)
            {
                return NotFound();
            }
            return Ok(brand);
        }

        [HttpPost]
        public async Task<ActionResult> CreateBrand(Brand_cars brand)
        {
            await _brandService.CreateBrandAsync(brand);
            return CreatedAtAction(nameof(GetBrand), new { ID = brand.ID }, brand); 
        }

        [HttpPut]
        public async Task<ActionResult> UpdateBrand(Brand_cars brand)
        {
            await _brandService.UpdateBrandAsync(brand);
            return NoContent();
        }

        [HttpDelete("{ID}")]
        public async Task<ActionResult> DeleteBrand(int ID)
        {
            await _brandService.DeleteBrandAsync(ID);
            return NoContent();
        }
    }
}
