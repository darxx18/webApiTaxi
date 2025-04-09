namespace webApiTaxi
{
    public interface ILicenseService
    {
        Task<IEnumerable<License>> GetAllLicenseAsync();
        Task<License?> GetLicenseByIdAsync(int ID);
        Task CreateLicenseAsync(License license);
        Task UpdateLicenseAsync(License license);
        Task DeleteLicenseAsync(int ID);
    }
}
