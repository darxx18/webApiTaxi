namespace webApiTaxi
{
    public interface IRateService
    {
        Task<IEnumerable<Rate>> GetAllRateAsync();
        Task<Rate?> GetRateByIdAsync(int ID);
        Task CreateRateAsync(Rate rate);
        Task UpdateRateAsync(Rate rate);
        Task DeleteRateAsync(int ID);
    }
}
