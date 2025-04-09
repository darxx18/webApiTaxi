namespace webApiTaxi
{
    public class DriversService : IDriversService
    {
        private readonly IDriversRepository _driversRepository;

        public DriversService(IDriversRepository driversRepository)
        {
            _driversRepository = driversRepository;
        }

        public async Task<IEnumerable<Drivers>> GetAllDriverAsync()
        {
            return await _driversRepository.GetAllDriverAsync();
        }
        public async Task<Drivers?> GetDriverByIdAsync(int ID)
        {
            return await _driversRepository.GetDriverByIdAsync(ID);
        }
        public async Task CreateDriverAsync(Drivers driver)
        {
            await _driversRepository.AddDriverAsync(driver);
        }

        public async Task UpdateDriverAsync(Drivers driver)
        {
            await _driversRepository.UpdateDriverAsync(driver);
        }

        public async Task DeleteDriverAsync(int ID)
        {
            await _driversRepository.DeleteDriverAsync(ID);
        }
    }
}
