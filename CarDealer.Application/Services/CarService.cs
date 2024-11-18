using CarDealer.Core.Core.Models;
using CarDealer.Core.Interfaces;

namespace CarDealer.Application.Services
{
    public class CarService
    {
        private readonly IRepository<Car> _carRepository;

        public CarService(IRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }

        public Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            return _carRepository.GetAllAsync();
        }

        public Task<Car> GetCarByIdAsync(int id)
        {
            return _carRepository.GetByIdAsync(id);
        }

        public Task AddCarAsync(Car car)
        {
            return _carRepository.AddAsync(car);
        }

        public Task UpdateCarAsync(Car car)
        {
            return _carRepository.UpdateAsync(car);
        }

        public Task DeleteCarAsync(int id)
        {
            return _carRepository.DeleteAsync(id);
        }
    }
}
