using Concessonaria.Data;
using Concessonaria.Models;
using Concessonaria.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Concessonaria.Repository
{
    public class ConcessonariaRepository : IConcessonariaRepository
    {
        private readonly DbContextApp _dbContext;
        public ConcessonariaRepository(DbContextApp dbContext) { 
            _dbContext = dbContext;
        }
        public async Task<IList<Cars>> GetCarsAsync(int skip, int take)
        {
            var cars = await _dbContext.Car.ToListAsync();
            return cars;
        }

        public async Task<Cars> CreateCarsAsync(Cars car)
        {
            _dbContext.Car.Add(car);
            await _dbContext.SaveChangesAsync();
            return car;
        }

        public async Task DeleteCar(int id)
        {
            Cars carToDelete = await _dbContext.Car.FindAsync(id);

            _dbContext.Car.Remove(carToDelete);

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCar(int id, Cars car)
        {
            //Procura através da chave primiaria o elemento dentro da tabela Car
            Cars carToUpdate = await _dbContext.Car.FindAsync(id);

            carToUpdate.Name = car.Name;
            carToUpdate.Status = car.Status;

            await _dbContext.SaveChangesAsync();
        }
    }
}
