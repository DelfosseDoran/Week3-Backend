namespace week3.GraphQL.queries;
public class Queries
{
    public async Task<List<Car>> GetAllCars([Service] ICarService carService)
    {
        return await carService.GetAllCars();
    }
}
