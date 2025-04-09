namespace webApiTaxi
{
    public interface IDriversRepository
    {
        Task<IEnumerable<Drivers>> GetAllDriverAsync();
        Task<Drivers?> GetDriverByIdAsync(int ID);
        Task AddDriverAsync(Drivers driver);
        Task UpdateDriverAsync(Drivers driver);
        Task DeleteDriverAsync(int ID);
    }
}
