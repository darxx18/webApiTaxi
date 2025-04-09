namespace webApiTaxi
{
    public interface IStatusesService
    {
        Task<IEnumerable<Statuses>> GetAllStatusesAsync();
        Task<Statuses?> GetStatusesByIdAsync(int ID);
        Task CreateStatusAsync(Statuses status);
        Task UpdateStatusAsync(Statuses status);
        Task DeleteStatusAsync(int ID);
    }
}
