namespace webApiTaxi
{
    public interface IBrand_carsService
    {
        Task<IEnumerable<Brand_cars>> GetAllBrandAsync();
        Task<Brand_cars?> GetBrandByIdAsync(int ID);
        Task CreateBrandAsync(Brand_cars brand);
        Task UpdateBrandAsync(Brand_cars brand);
        Task DeleteBrandAsync(int ID);
    }
}
