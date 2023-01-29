using Concessonaria.Models;

namespace Concessonaria.Services.Interface
{
    public interface IConcessonariaRepository
    {
        public Task<IList<Cars>> GetCarsAsync(int skip, int take);
        public Task<Cars> CreateCarsAsync(Cars car);
        public Task UpdateCar(int id, Cars car);
        public Task DeleteCar(int id);
    }
}
