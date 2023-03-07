namespace week3_oef2.Repositories;
public interface ISneackerRepository
{
    Task<List<Sneaker>> GetAllSneackers();
    Task<Sneaker> GetSneackerById(string id);
    Task<Sneaker> AddSneacker(Sneaker sneacker);
}
public class SneackerRepository : ISneackerRepository
{
    private readonly IMongoCollection<Sneaker> _sneackers;
    public SneackerRepository(IMongoContext MongoContext)
    {
        _sneackers = MongoContext.SneakerCollection;
    }
    public async Task<List<Sneaker>> GetAllSneackers()
    {
        return await _sneackers.Find(_ => true).ToListAsync();
    }
    public async Task<Sneaker> GetSneackerById(string id)
    {
        return await _sneackers.Find(sneacker => sneacker.SneakerId == id).FirstOrDefaultAsync();
    }
    public async Task<Sneaker> AddSneacker(Sneaker sneacker)
    {
        await _sneackers.InsertOneAsync(sneacker);
        return sneacker;
    }
}
