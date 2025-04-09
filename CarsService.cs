namespace webApiTaxi
{
    public class CarsService : ICarsService
    {
        private readonly ICarsRepository _carsRepository;

        public CarsService(ICarsRepository carsRepository)
        {
            _carsRepository = carsRepository;
        }

        public async Task<IEnumerable<Cars>> GetAllCarsAsync()
        {
            return await _carsRepository.GetAllCarsAsync();
        }
        public async Task<Cars?> GetCarsByIdAsync(int ID)
        {
            return await _carsRepository.GetCarsByIdAsync(ID);
        }
        public async Task CreateCarAsync(Cars car)
        {
            await _carsRepository.AddCarAsync(car);
        }

        public async Task UpdateCarAsync(Cars car)
        {
            await _carsRepository.UpdateCarAsync(car);
        }

        public async Task DeleteCarAsync(int ID)
        {
            await _carsRepository.DeleteCarAsync(ID);
        }
    }
}
