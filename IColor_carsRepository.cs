namespace webApiTaxi
{
    public interface IColor_carsRepository
    {
        Task<IEnumerable<Color_cars>> GetAllColorAsync();
        Task<Color_cars?> GetColorByIdAsync(int ID);
        Task AddColorAsync(Color_cars color);
        Task UpdateColorAsync(Color_cars color);
        Task DeleteColorAsync(int ID);
    }
}
