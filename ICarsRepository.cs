namespace webApiTaxi
{
    public interface ICarsRepository
    {
        Task<IEnumerable<Cars>> GetAllCarsAsync();
        Task<Cars?> GetCarsByIdAsync(int ID);
        Task AddCarAsync(Cars car);
        Task UpdateCarAsync(Cars car);
        Task DeleteCarAsync(int ID);
    }
}
