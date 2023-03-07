using System;

namespace week3.Repositories;
public interface ICarRepository
{
    Task<Car> AddCar(Car newCar);
    Task<Car> GetCar(string id);
    Task<List<Car>> GetAllCars();
    Task<Car> UpdateCar(Car car);
    Task DeleteCar(string id);
    
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

    public async Task<Car> GetCar(string id)
    {
        return await _context.CarsCollection.Find(car => car.Id == id).FirstOrDefaultAsync();
        // return _cars.Find(car => car.Id == id).FirstOrDefault();
    }

    public async Task<List<Car>> GetAllCars()
    {
        return await _context.CarsCollection.Find(_ => true).ToListAsync();
    }

    public async Task<Car> UpdateCar(Car car)
    {
        var filter = Builders<Car>.Filter.Eq(car => car.Id, car.Id);
        var update = Builders<Car>.Update
            .Set("Brand", car.Brand)
            .Set("Name", car.Name)
            .Set("UpdatedOn", DateTime.Now);
        var result = await _context.CarsCollection.UpdateOneAsync(filter, update);
        return car;
        
    }

    public async Task DeleteCar(string id)
    {
        await _context.CarsCollection.DeleteOneAsync(car => car.Id == id);
    }
}
