namespace webApiTaxi
{
    public interface ITypes_tripService
    {
        Task<IEnumerable<Types_trip>> GetAllTypesAsync();
        Task<Types_trip?> GetTypesByIdAsync(int ID);
        Task CreateTypeAsync(Types_trip type);
        Task UpdateTypeAsync(Types_trip type);
        Task DeleteTypeAsync(int ID);
    }
}
