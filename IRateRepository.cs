namespace webApiTaxi
{
    public interface IRateRepository
    {
        Task<IEnumerable<Rate>> GetAllRateAsync();
        Task<Rate?> GetRateByIdAsync(int ID);
        Task AddRateAsync(Rate rate);
        Task UpdateRateAsync(Rate rate);
        Task DeleteRateAsync(int ID);
    }
}
