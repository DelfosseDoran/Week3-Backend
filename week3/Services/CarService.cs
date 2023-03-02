namespace week3.Services;

public interface ICarService
{
    Task SetupDummyData();
    Task<Brand> AddBrand(Brand newBrand);
    Task<Brand> GetBrand(string id);
    Task<List<Brand>> GetAllBrands();
    Task<Brand> UpdateBrand(Brand brand);
    Task DeleteBrand(string id);
    Task<Car> AddCar(Car newCar);
    Task<Car> GetCar(string id);
    Task<List<Car>> GetAllCars();
}

public class CarService: ICarService
{
    private readonly ICarRepository _carRepository;
    private readonly IBrandRepository _brandRepository;
    public CarService(ICarRepository carRepository, IBrandRepository brandRepository)
    {
        _carRepository = carRepository;
        _brandRepository = brandRepository;
    }

    public Task<Brand> AddBrand(Brand newBrand)
    {
        throw new NotImplementedException();
    }

    public Task<Car> AddCar(Car newCar)
    {
        throw new NotImplementedException();
    }

    public Task DeleteBrand(string id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Brand>> GetAllBrands()
    {
        throw new NotImplementedException();
    }

    public Task<List<Car>> GetAllCars()
    {
        throw new NotImplementedException();
    }

    public Task<Brand> GetBrand(string id)
    {
        return _brandRepository.GetBrand(id);
    }

    public Task<Car> GetCar(string id)
    {
        throw new NotImplementedException();
    }

    public async Task SetupDummyData()
    {
        if (!(await _brandRepository.GetAllBrands()).Any())
        {

            var brands = new List<Brand>(){
            new Brand()
            {
            Country = "Germany" , Name = "Volkswagen"
            },
            new Brand()
            {
           Country = "Germany" , Name = "BMW"
            },
            new Brand()
            {
         Country = "Germany" , Name = "Audi"
            },
            new Brand()
            {
              Country = "USA" , Name = "Tesla"
            }
        };

            foreach (var brand in brands)
                await _brandRepository.AddBrand(brand);
        }

        if (!(await _carRepository.GetAllCars()).Any())
        {
            var brands = await _brandRepository.GetAllBrands();
            var cars = new List<Car>()
        {
            new Car(){

                Name = "ID.3",
                Brand = brands[0],
            },
            new Car(){

                Name = "ID.4",
                Brand = brands[0],
            },
            new Car(){

                Name = "IX3",
                Brand = brands[1],
            },
            new Car(){

                Name = "E-Tron",
                Brand = brands[2],
            },
            new Car(){

                Name = "Model Y",
                Brand = brands[3],
            }
        };
            foreach (var car in cars)
                await _carRepository.AddCar(car);
        }
    }

    public Task<Brand> UpdateBrand(Brand brand)
    {
        throw new NotImplementedException();
    }
}