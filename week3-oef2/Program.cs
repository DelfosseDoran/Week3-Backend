



var builder = WebApplication.CreateBuilder(args);
var Mongo = builder.Configuration.GetSection("MongoConnection");
builder.Services.Configure<DatabaseSettings>(Mongo);
builder.Services.AddSingleton<IMongoContext, MongoContext>();
builder.Services.AddSingleton<IBrandRepository, BrandRepository>();
builder.Services.AddSingleton<IOccaasionRepository, OccaasionRepository>();
builder.Services.AddSingleton<ISneackerRepository, SneackerRepository>();
builder.Services.AddSingleton<IOrderRepository, OrderRepository>();
builder.Services.AddSingleton<ISneakerServices, SneakerServices>();
builder.Services.AddValidatorsFromAssemblyContaining<SneakerValidator>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/setup",async (ISneakerServices sneakerServices) =>
{
    await sneakerServices.SetupData();
    return "Setup done";
});

app.MapGet("/sneakers", async (ISneakerServices sneakerServices) =>
{
    var sneakers = await sneakerServices.GetAllSneackers();
    return Results.Ok(sneakers);
});

app.MapGet("/sneakers/{id}", async (string id, ISneakerServices sneakerServices) =>
{
    var sneaker = await sneakerServices.GetSneackerById(id);
    return Results.Ok(sneaker);
});

app.MapPost("/sneakers", async (Sneaker sneaker, ISneakerServices sneakerServices) =>
{
    var sneakerAdded = await sneakerServices.AddSneacker(sneaker);
    return Results.Created("/sneakers/{id}",sneakerAdded);
});

app.MapGet("/orders", async (ISneakerServices sneakerServices) =>
{
    var orders = await sneakerServices.GetAllOrders();
    return Results.Ok(orders);
});

app.MapGet("/orders/{id}", async (string id, ISneakerServices sneakerServices) =>
{
    var order = await sneakerServices.GetOrderById(id);
    return Results.Ok(order);
});

app.MapPost("/orders", async (Order order, ISneakerServices sneakerServices) =>
{
    var orderAdded = await sneakerServices.AddOrder(order);
    return Results.Ok(orderAdded);
});

app.MapGet("/occasions", async (ISneakerServices sneakerServices) =>
{
    var occasions = await sneakerServices.GetAllOccasions();
    return Results.Ok(occasions);
});

app.MapGet("/occasions/{id}", async (string id, ISneakerServices sneakerServices) =>
{
    var occasion = await sneakerServices.GetOccasionById(id);
    return Results.Ok(occasion);
});

app.MapPost("/occasions", async (Occasion occasion, ISneakerServices sneakerServices) =>
{
    var occasionAdded = await sneakerServices.AddOccasion(occasion);
    return Results.Ok(occasionAdded);
});

app.MapGet("/brands", async (ISneakerServices sneakerServices) =>
{
    var brands = await sneakerServices.GetAllBrands();
    return Results.Ok(brands);
});

app.MapGet("/brands/{id}", async (string id, ISneakerServices sneakerServices) =>
{
    var brand = await sneakerServices.GetBrandById(id);
    return Results.Ok(brand);
});

app.MapPost("/brands", async (Brand brand, ISneakerServices sneakerServices) =>
{
    var brandAdded = await sneakerServices.AddBrand(brand);
    return Results.Ok(brandAdded);
});

app.Run("http://localhost:5000");
