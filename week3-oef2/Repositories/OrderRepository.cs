namespace week3_oef2.Repositories;
public interface IOrderRepository
{
    Task<List<Order>> GetAllOrders();
    Task<Order> GetOrderById(string id);
    Task<Order> AddOrder(Order order);
}
public class OrderRepository : IOrderRepository
{
    private readonly IMongoCollection<Order> _orders;
    public OrderRepository(IMongoContext MongoContext)
    {
        _orders = MongoContext.OrdersCollection;
    }
    public async Task<List<Order>> GetAllOrders()
    {
        return await _orders.Find(_ => true).ToListAsync();
    }
    public async Task<Order> GetOrderById(string id)
    {
        return await _orders.Find(order => order.OrderId == id).FirstOrDefaultAsync();
    }
    public async Task<Order> AddOrder(Order order)
    {
        await _orders.InsertOneAsync(order);
        return order;
    }
}
