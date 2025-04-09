namespace webApiTaxi
{
    public interface IBrand_carsRepository
    {
        Task<IEnumerable<Brand_cars>> GetAllBrandAsync();
        Task<Brand_cars?> GetBrandByIdAsync(int ID);
        Task AddBrandAsync(Brand_cars brand);
        Task UpdateBrandAsync(Brand_cars brand);
        Task DeleteBrandAsync(int ID);
    }
}
