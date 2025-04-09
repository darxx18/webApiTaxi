namespace webApiTaxi
{
    public class Types_tripService : ITypes_tripService
    {
        private readonly ITypes_tripRepository _typesRepository;

        public Types_tripService(ITypes_tripRepository typesRepository)
        {
            _typesRepository = typesRepository;
        }

        public async Task<IEnumerable<Types_trip>> GetAllTypesAsync()
        {
            return await _typesRepository.GetAllTypesAsync();
        }
        public async Task<Types_trip?> GetTypesByIdAsync(int ID)
        {
            return await _typesRepository.GetTypesByIdAsync(ID);
        }
        public async Task CreateTypeAsync(Types_trip type)
        {
            await _typesRepository.AddTypeAsync(type);
        }

        public async Task UpdateTypeAsync(Types_trip type)
        {
            await _typesRepository.UpdateTypeAsync(type);
        }

        public async Task DeleteTypeAsync(int ID)
        {
            await _typesRepository.DeleteTypeAsync(ID);
        }
    }
}
