namespace webApiTaxi
{
    public interface ITypes_tripRepository
    {
        Task<IEnumerable<Types_trip>> GetAllTypesAsync();
        Task<Types_trip?> GetTypesByIdAsync(int ID);
        Task AddTypeAsync(Types_trip type);
        Task UpdateTypeAsync(Types_trip type);
        Task DeleteTypeAsync(int ID);
    }
}
