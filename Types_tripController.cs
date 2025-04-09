using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webApiTaxi
{
    [Route("api/[controller]")]
    [ApiController]
    public class Types_tripController : ControllerBase
    {
        private readonly ITypes_tripService _typesService;

        public Types_tripController(ITypes_tripService typesService)
        {
            _typesService = typesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Types_trip>>> GetTypes()
        {
            var type = await _typesService.GetAllTypesAsync();
            return Ok(type);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<Types_trip>> GetTypes(int ID)
        {
            var type = await _typesService.GetTypesByIdAsync(ID);
            if (type == null)
            {
                return NotFound();
            }
            return Ok(type);
        }

        [HttpPost]
        public async Task<ActionResult> CreateType(Types_trip type)
        {
            await _typesService.CreateTypeAsync(type);
            return CreatedAtAction(nameof(GetType), new { ID = type.ID }, type);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateType(Types_trip type)
        {
            await _typesService.UpdateTypeAsync(type);
            return NoContent();
        }

        [HttpDelete("{ID}")]
        public async Task<ActionResult> DeleteType(int ID)
        {
            await _typesService.DeleteTypeAsync(ID);
            return NoContent();
        }
    }
}
