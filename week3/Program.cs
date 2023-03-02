var builder = WebApplication.CreateBuilder(args);
var DataCon = builder.Configuration.GetSection("MongoConnection");
builder.Services.Configure<DatabaseSettings>(DataCon);
// DataCon.PersistKeysToFileSystem(new System.IO.DirectoryInfo(@"C:\Users\moham\OneDrive\Desktop\week3\keys"));
builder.Services.AddTransient<IBrandRepository, BrandRepository>();
builder.Services.AddTransient<ICarRepository, CarRepository>();
builder.Services.AddTransient<IMongoContext, MongoContext>();
builder.Services.AddTransient<ICarService, CarService>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/setup", async (ICarService carService) =>
{
    await carService.SetupDummyData();
    return "Setup done";
});

app.Run("http://localhost:5000");
