namespace webApiTaxi
{
    public class RateService : IRateService
    {
        private readonly IRateRepository _rateRepository;

        public RateService(IRateRepository rateRepository)
        {
            _rateRepository = rateRepository;
        }

        public async Task<IEnumerable<Rate>> GetAllRateAsync()
        {
            return await _rateRepository.GetAllRateAsync();
        }
        public async Task<Rate?> GetRateByIdAsync(int ID)
        {
            return await _rateRepository.GetRateByIdAsync(ID);
        }
        public async Task CreateRateAsync(Rate rate)
        {
            await _rateRepository.AddRateAsync(rate);
        }

        public async Task UpdateRateAsync(Rate rate)
        {
            await _rateRepository.UpdateRateAsync(rate);
        }

        public async Task DeleteRateAsync(int ID)
        {
            await _rateRepository.DeleteRateAsync(ID);
        }
    }
}
