namespace webApiTaxi
{
    public class Color_carsService : IColor_carsService
    {
        private readonly IColor_carsRepository _colorsRepository;

        public Color_carsService(IColor_carsRepository colorsRepository)
        {
            _colorsRepository = colorsRepository;
        }

        public async Task<IEnumerable<Color_cars>> GetAllColorAsync()
        {
            return await _colorsRepository.GetAllColorAsync();
        }
        public async Task<Color_cars?> GetColorByIdAsync(int ID)
        {
            return await _colorsRepository.GetColorByIdAsync(ID);
        }
        public async Task CreateColorAsync(Color_cars color)
        {
            await _colorsRepository.AddColorAsync(color);
        }

        public async Task UpdateColorAsync(Color_cars color)
        {
            await _colorsRepository.UpdateColorAsync(color);
        }

        public async Task DeleteColorAsync(int ID)
        {
            await _colorsRepository.DeleteColorAsync(ID);
        }
    }
}
