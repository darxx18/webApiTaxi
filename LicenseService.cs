namespace webApiTaxi
{
    public class LicenseService : ILicenseService
    {
        private readonly ILicenseRepository _licenseRepository;

        public LicenseService(ILicenseRepository licenseRepository)
        {
            _licenseRepository = licenseRepository;
        }

        public async Task<IEnumerable<License>> GetAllLicenseAsync()
        {
            return await _licenseRepository.GetAllLicenseAsync();
        }
        public async Task<License?> GetLicenseByIdAsync(int ID)
        {
            return await _licenseRepository.GetLicenseByIdAsync(ID);
        }
        public async Task CreateLicenseAsync(License license)
        {
            await _licenseRepository.AddLicenseAsync(license);
        }

        public async Task UpdateLicenseAsync(License license)
        {
            await _licenseRepository.UpdateLicenseAsync(license);
        }

        public async Task DeleteLicenseAsync(int ID)
        {
            await _licenseRepository.DeleteLicenseAsync(ID);
        }
    }
}
