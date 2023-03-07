namespace week3.GraphQL.Mutations;
public class Mutation
{
    public async Task<AddBrandPayload> AddBrand([Service] ICarService carService, AddBrandInput input)
    {
        var newBrand = new Brand()
        {
            Name = input.name,
            Country = input.country
        };
        var created = await carService.AddBrand(newBrand);
        return new AddBrandPayload(created);
    }

    public async Task<AddCarPayload> AddCar([Service] ICarService carService, AddCarInput input)
    {
        var newCar = new Car()
        {
            Name = input.name,
            Brand = new Brand()
            {
                Id = input.brandId,
                Name = input.brandName,
                Country = input.brandCountry,
                CreatedOn = DateTime.Now
            }
        };
        var created = await carService.AddCar(newCar);
        return new AddCarPayload(created);
    }
    public async Task<string> DeleteBrand([Service] ICarService carService, string id)
    {
        await carService.DeleteBrand(id);
        return id;
    }
    public async Task<UpdateCarPayload> UpdateCar([Service] ICarService carService, UpdateCarInput input)
    {
        var car = new Car()
        {
            Id = input.id,
            Name = input.name,
            Brand = new Brand()
            {
                Id = input.brandId,
                Name = input.brandName,
                Country = input.brandCountry,
                CreatedOn = DateTime.Now
            }
        };
        var updated = await carService.UpdateCar(car);
        return new UpdateCarPayload(updated);
    }
    public async Task<UpdateBrandPayload> UpdateBrand([Service] ICarService carService, UpdateBrandInput input)
    {
        var brand = new Brand()
        {
            Id = input.id,
            Name = input.name,
            Country = input.country,
            CreatedOn = DateTime.Now
        };
        var updated = await carService.UpdateBrand(brand);
        return new UpdateBrandPayload(updated);
    }
}
public record AddBrandInput(string name, string country);
public record AddBrandPayload(Brand Brand);
public record AddCarInput(string name, string brandId, String brandName, String brandCountry);
public record AddCarPayload(Car Car);
public record DeleteBrandInput(string id);
public record DeleteBrandPayload(string Id);
public record UpdateCarInput(string id, string name, string brandId, String brandName, String brandCountry);
public record UpdateCarPayload(Car Car);
public record UpdateBrandInput(string id, string name, string country);
public record UpdateBrandPayload(Brand Brand);