using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webApiTaxi
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseController : ControllerBase
    {
        private readonly ILicenseService _licenseService;

        public LicenseController(ILicenseService licenseService)
        {
            _licenseService = licenseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<License>>> GetLicense()
        {
            var license = await _licenseService.GetAllLicenseAsync();
            return Ok(license);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<License>> GetLicense(int ID)
        {
            var license = await _licenseService.GetLicenseByIdAsync(ID);
            if (license == null)
            {
                return NotFound();
            }
            return Ok(license);
        }

        [HttpPost]
        public async Task<ActionResult> CreateLicense(License license)
        {
            await _licenseService.CreateLicenseAsync(license);
            return CreatedAtAction(nameof(GetLicense), new { ID = license.ID }, license);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateLicense(License license)
        {
            await _licenseService.UpdateLicenseAsync(license);
            return NoContent();
        }

        [HttpDelete("{ID}")]
        public async Task<ActionResult> DeleteLicense(int ID)
        {
            await _licenseService.DeleteLicenseAsync(ID);
            return NoContent();
        }
    }
}
