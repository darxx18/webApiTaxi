namespace webApiTaxi
{
    public class Brand_carsService : IBrand_carsService
    {
        private readonly IBrand_carsRepository _brandRepository;

        public Brand_carsService(IBrand_carsRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<IEnumerable<Brand_cars>> GetAllBrandAsync()
        {
            return await _brandRepository.GetAllBrandAsync();
        }
        public async Task<Brand_cars?> GetBrandByIdAsync(int ID)
        {
            return await _brandRepository.GetBrandByIdAsync(ID);
        }
        public async Task CreateBrandAsync(Brand_cars brand)
        {
            await _brandRepository.AddBrandAsync(brand);
        }

        public async Task UpdateBrandAsync(Brand_cars brand)
        {
            await _brandRepository.UpdateBrandAsync(brand);
        }

        public async Task DeleteBrandAsync(int ID)
        {
            await _brandRepository.DeleteBrandAsync(ID);
        }
    }
}
