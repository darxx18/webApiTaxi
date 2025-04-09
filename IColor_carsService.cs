namespace webApiTaxi
{
    public interface IColor_carsService
    {
        Task<IEnumerable<Color_cars>> GetAllColorAsync();
        Task<Color_cars?> GetColorByIdAsync(int ID);
        Task CreateColorAsync(Color_cars color);
        Task UpdateColorAsync(Color_cars color);
        Task DeleteColorAsync(int ID);
    }
}
