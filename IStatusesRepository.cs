namespace webApiTaxi
{
    public interface IStatusesRepository
    {
        Task<IEnumerable<Statuses>> GetAllStatusesAsync();
        Task<Statuses?> GetStatusesByIdAsync(int ID);
        Task AddStatusAsync(Statuses status);
        Task UpdateStatusAsync(Statuses status);
        Task DeleteStatusAsync(int ID);
    }
}
