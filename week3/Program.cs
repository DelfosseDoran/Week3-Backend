using FluentValidation;

var builder = WebApplication.CreateBuilder(args);
var DataCon = builder.Configuration.GetSection("MongoConnection");
builder.Services.Configure<DatabaseSettings>(DataCon);
// DataCon.PersistKeysToFileSystem(new System.IO.DirectoryInfo(@"C:\Users\moham\OneDrive\Desktop\week3\keys"));
builder.Services.AddTransient<IBrandRepository, BrandRepository>();
builder.Services.AddTransient<ICarRepository, CarRepository>();
builder.Services.AddTransient<IMongoContext, MongoContext>();
builder.Services.AddTransient<ICarService, CarService>();
builder.Services.AddValidatorsFromAssemblyContaining<CarRepositoryValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<BrandRepositoryValidator>();
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Queries>()
    .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true)
    .AddMutationType<Mutation>();
var app = builder.Build();
app.MapGraphQL();

app.MapGet("/", () => "Hello World!");

app.MapGet("/setup", async (ICarService carService) =>
{
    await carService.SetupDummyData();
    return "Setup done";
});

app.MapGet("/brands", async (ICarService carService) =>
{
    return await carService.GetAllBrands();
});

app.MapGet("/brands/{id}", async (string id, ICarService carService) =>
{
    return await carService.GetBrand(id);
});

app.MapGet("/cars", async (ICarService carService) =>
{
    return await carService.GetAllCars();
});

app.MapGet("/cars/{id}", async (string id, ICarService carService) =>
{
    return await carService.GetCar(id);
});

app.MapPost("/brands", async (Brand newBrand, ICarService carService, IValidator<Brand> validator) =>
{
    var result = validator.Validate(newBrand);
    if (!result.IsValid)
    {
        return Results.BadRequest(result.Errors);
    }

    return Results.Ok(await carService.AddBrand(newBrand));
});

app.MapPost("/cars", async (Car newCar, ICarService carService, IValidator<Car> validator) =>
{
    var result = validator.Validate(newCar);
    if (!result.IsValid)
    {
        return Results.BadRequest(result.Errors);
    }

    return Results.Ok(await carService.AddCar(newCar));
});

app.MapPut("/brands/{id}", async (string id, Brand brand, ICarService carService, IValidator<Brand> validator) =>
{
    var result = validator.Validate(brand);
    if (!result.IsValid)
    {
        return Results.BadRequest(result.Errors);
    }

    return Results.Ok(await carService.UpdateBrand(brand));
});

app.MapDelete("/brands/{id}", async (string id, ICarService carService) =>
{
    await carService.DeleteBrand(id);
    return Results.Ok();
});



app.Run("http://localhost:5000");
