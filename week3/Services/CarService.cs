namespace week3.Services;
public class CarService
{
    private readonly ICarRepository _carRepository;
    private readonly IBrandRepository _brandRepository;
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
}