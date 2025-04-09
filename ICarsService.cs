namespace webApiTaxi
{
    public interface ICarsService
    {
        Task<IEnumerable<Cars>> GetAllCarsAsync();
        Task<Cars?> GetCarsByIdAsync(int ID);
        Task CreateCarAsync(Cars car);
        Task UpdateCarAsync(Cars car);
        Task DeleteCarAsync(int ID);
    }
}
