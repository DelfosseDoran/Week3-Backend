namespace week3.GraphQL.queries;
public class Queries
{
    public async Task<List<Car>> GetCars([Service] ICarService carService)
    {
        return await carService.GetAllCars();
    }
    public async Task<List<Brand>> GetBrands([Service] ICarService carService)
    {
        return await carService.GetAllBrands();
    }
}
