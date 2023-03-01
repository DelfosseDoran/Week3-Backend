using System;

namespace week3.Repositories;
public interface ICarRepository
{
    Car AddCar(Car newCar);
    Car GetCar(string id);
    List<Car> GetAllCars();
}
public class CarRepository: ICarRepository
{
    private readonly IMongoCollection<Car> _cars;
    public CarRepository(IMongoContext context)
    {
        _cars = context.CarsCollection;
    }

    public Car AddCar(Car car)
    {
        _cars.InsertOne(car);
        return car;
    }

    public Car GetCar(string id)
    {
        return _cars.Find(car => car.Id == id).FirstOrDefault();
    }

    public List<Car> GetAllCars()
    {
        return _cars.Find(car => true).ToList();
    }

}
