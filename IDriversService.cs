namespace webApiTaxi
{
    public interface IDriversService
    {
        Task<IEnumerable<Drivers>> GetAllDriverAsync();
        Task<Drivers?> GetDriverByIdAsync(int ID);
        Task CreateDriverAsync(Drivers driver);
        Task UpdateDriverAsync(Drivers driver);
        Task DeleteDriverAsync(int ID);
    }
}
