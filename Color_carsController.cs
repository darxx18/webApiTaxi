using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webApiTaxi
{
    [Route("api/[controller]")]
    [ApiController]
    public class Color_carsController : ControllerBase
    {
        private readonly IColor_carsService _colorService;

        public Color_carsController(IColor_carsService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Color_cars>>> GetColor()
        {
            var color = await _colorService.GetAllColorAsync();
            return Ok(color);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<Color_cars>> GetColor(int ID)
        {
            var color = await _colorService.GetColorByIdAsync(ID);
            if (color == null)
            {
                return NotFound();
            }
            return Ok(color);
        }

        [HttpPost]
        public async Task<ActionResult> CreateColor(Color_cars color)
        {
            await _colorService.CreateColorAsync(color);
            return CreatedAtAction(nameof(GetColor), new { ID = color.ID }, color);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateColor(Color_cars color)
        {
            await _colorService.UpdateColorAsync(color);
            return NoContent();
        }

        [HttpDelete("{ID}")]
        public async Task<ActionResult> DeleteColor(int ID)
        {
            await _colorService.DeleteColorAsync(ID);
            return NoContent();
        }
    }
}
