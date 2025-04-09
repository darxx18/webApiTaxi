using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webApiTaxi
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusesController : ControllerBase
    {
        private readonly IStatusesService _statusesService;

        public StatusesController(IStatusesService statusesService)
        {
            _statusesService = statusesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Statuses>>> GetStatuses()
        {
            var statuses = await _statusesService.GetAllStatusesAsync();
            return Ok(statuses);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<Statuses>> GetStatuses(int ID)
        {
            var statuses = await _statusesService.GetStatusesByIdAsync(ID);
            if (statuses == null)
            {
                return NotFound();
            }
            return Ok(statuses);
        }

        [HttpPost]
        public async Task<ActionResult> CreateStatus(Statuses status)
        {
            await _statusesService.CreateStatusAsync(status);
            return CreatedAtAction(nameof(GetStatuses), new { ID = status.ID }, status);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateStatus(Statuses status)
        {
            await _statusesService.UpdateStatusAsync(status);
            return NoContent();
        }

        [HttpDelete("{ID}")]
        public async Task<ActionResult> DeleteStatus(int ID)
        {
            await _statusesService.DeleteStatusAsync(ID);
            return NoContent();
        }
    }
}
