namespace webApiTaxi
{
    public interface ILicenseRepository
    {
        Task<IEnumerable<License>> GetAllLicenseAsync();
        Task<License?> GetLicenseByIdAsync(int ID);
        Task AddLicenseAsync(License license);
        Task UpdateLicenseAsync(License license);
        Task DeleteLicenseAsync(int ID);
    }
}
