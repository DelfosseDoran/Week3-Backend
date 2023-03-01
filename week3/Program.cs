var builder = WebApplication.CreateBuilder(args);
var DataCon = builder.Services.AddDataProtection();
// DataCon.PersistKeysToFileSystem(new System.IO.DirectoryInfo(@"C:\Users\moham\OneDrive\Desktop\week3\keys"));
builder.Services.AddTransient<IBrandRepository, BrandRepository>();
builder.Services.AddTransient<ICarRepository, CarRepository>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
