namespace week3_oef2.Services;
public interface ISneakerServices
{
    Task SetupData();
     Task<List<Sneaker>> GetAllSneackers();
    Task<Sneaker> GetSneackerById(string id);
    Task<Sneaker> AddSneacker(Sneaker sneacker);
    Task<List<Order>> GetAllOrders();
    Task<Order> GetOrderById(string id);
    Task<Order> AddOrder(Order order);
    Task<List<Occasion>> GetAllOccasions();
    Task<Occasion> GetOccasionById(string id);
    Task<Occasion> AddOccasion(Occasion occasion);
    Task<List<Occasion>> AddOccasions(List<Occasion> occasions);
    Task<List<Brand>> GetAllBrands();
    Task<Brand> GetBrandById(string id);
    Task<Brand> AddBrand(Brand brand);
    Task<List<Brand>> AddBrands(List<Brand> brands);
}
public class SneakerServices : ISneakerServices
{
    private readonly IBrandRepository _brandRepository;
    private readonly IOccaasionRepository _occasionRepository;
    private readonly ISneackerRepository _sneakerRepository;
    private readonly IOrderRepository _orderRepository;
    public SneakerServices(IBrandRepository brandRepository, IOccaasionRepository occasionRepository, ISneackerRepository sneakerRepository, IOrderRepository orderRepository)
    {
        _brandRepository = brandRepository;
        _occasionRepository = occasionRepository;
        _sneakerRepository = sneakerRepository;
        _orderRepository = orderRepository;
    }

    public Task<Brand> AddBrand(Brand brand)
    {
        return _brandRepository.AddBrand(brand);
    }

    public Task<List<Brand>> AddBrands(List<Brand> brands)
    {
        return _brandRepository.AddBrands(brands);
    }

    public Task<Occasion> AddOccasion(Occasion occasion)
    {
        return _occasionRepository.AddOccasion(occasion);
    }

    public Task<List<Occasion>> AddOccasions(List<Occasion> occasions)
    {
        return _occasionRepository.AddOccasions(occasions);
    }

    public Task<Order> AddOrder(Order order)
    {
        return _orderRepository.AddOrder(order);
    }

    public Task<Sneaker> AddSneacker(Sneaker sneacker)
    {
        return _sneakerRepository.AddSneacker(sneacker);
    }

    public Task<List<Brand>> GetAllBrands()
    {
        return _brandRepository.GetAllBrands();
    }

    public Task<List<Occasion>> GetAllOccasions()
    {
        return _occasionRepository.GetAllOccasions();
    }

    public Task<List<Order>> GetAllOrders()
    {
        return _orderRepository.GetAllOrders();
    }

    public Task<List<Sneaker>> GetAllSneackers()
    {
        return _sneakerRepository.GetAllSneackers();
    }

    public Task<Brand> GetBrandById(string id)
    {
        return _brandRepository.GetBrandById(id);
    }

    public Task<Occasion> GetOccasionById(string id)
    {
        return _occasionRepository.GetOccasionById(id);
    }

    public Task<Order> GetOrderById(string id)
    {
        return _orderRepository.GetOrderById(id);
    }

    public Task<Sneaker> GetSneackerById(string id)
    {
        return _sneakerRepository.GetSneackerById(id);
    }

    public async Task SetupData()
    {
        try
        {
            if (!(await _brandRepository.GetAllBrands()).Any())
                await _brandRepository.AddBrands(new List<Brand>() { new Brand() { Name = "ASICS" }, new Brand() { Name = "CONVERSE" }, new Brand() { Name = "JORDAN" }, new Brand() { Name = "PUMA" } });

            if (!(await _occasionRepository.GetAllOccasions()).Any())
                await _occasionRepository.AddOccasions(new List<Occasion>() { new Occasion() { Description = "Sports" }, new Occasion() { Description = "Casual" }, new Occasion() { Description = "Skate" }, new Occasion() { Description = "Diner" } });
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
}
