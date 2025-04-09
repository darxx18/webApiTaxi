namespace webApiTaxi
{
    public class StatusesService: IStatusesService
    {
        private readonly IStatusesRepository _statusesRepository;

        public StatusesService(IStatusesRepository statusesRepository)
        {
            _statusesRepository = statusesRepository;
        }

        public async Task<IEnumerable<Statuses>> GetAllStatusesAsync()
        {
            return await _statusesRepository.GetAllStatusesAsync();
        }
        public async Task<Statuses?> GetStatusesByIdAsync(int ID)
        {
            return await _statusesRepository.GetStatusesByIdAsync(ID);
        }
        public async Task CreateStatusAsync(Statuses status)
        {
            await _statusesRepository.AddStatusAsync(status);
        }

        public async Task UpdateStatusAsync(Statuses status)
        {
            await _statusesRepository.UpdateStatusAsync(status);
        }

        public async Task DeleteStatusAsync(int ID)
        {
            await _statusesRepository.DeleteStatusAsync(ID);
        }
    }
}
