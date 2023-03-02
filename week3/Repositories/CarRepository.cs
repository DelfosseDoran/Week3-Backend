using System;

namespace week3.Repositories;
public interface ICarRepository
{
    Task<Car> AddCar(Car newCar);
    Task<Car> GetCar(string id);
    Task<List<Car>> GetAllCars();
    
}
public class CarRepository : ICarRepository
{
    private readonly IMongoContext _context;
    public CarRepository(IMongoContext context)
    {
        _context = context;
    }

    public async Task<Car> AddCar(Car car)
    {
        car.CreatedOn = DateTime.Now;
        await _context.CarsCollection.InsertOneAsync(car);
        return car;
    }

    public Task<Car> GetCar(string id)
    {
        throw new NotImplementedException();
        // return _cars.Find(car => car.Id == id).FirstOrDefault();
    }

    public async Task<List<Car>> GetAllCars()
    {
        return await _context.CarsCollection.Find(_ => true).ToListAsync();
    }

}
