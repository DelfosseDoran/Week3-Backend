namespace week3_oef2.Repositories;
public interface IOccaasionRepository
{
    Task<List<Occasion>> GetAllOccasions();
    Task<Occasion> GetOccasionById(string id);
    Task<Occasion> AddOccasion(Occasion occasion);
    Task<List<Occasion>> AddOccasions(List<Occasion> occasions);
}
public class OccaasionRepository: IOccaasionRepository
{
    private readonly IMongoCollection<Occasion> _occasions;
    public OccaasionRepository(IMongoContext MongoContext)
    {
        _occasions = MongoContext.OccasionCollection;
    }
    public async Task<List<Occasion>> GetAllOccasions()
    {
        return await _occasions.Find(_ => true).ToListAsync();
    }
    public async Task<Occasion> GetOccasionById(string id)
    {
        return await _occasions.Find(occasion => occasion.OccasionId == id).FirstOrDefaultAsync();
    }
    public async Task<Occasion> AddOccasion(Occasion occasion)
    {
        await _occasions.InsertOneAsync(occasion);
        return occasion;
    }
    public async Task<List<Occasion>> AddOccasions(List<Occasion> occasions)
    {
        await _occasions.InsertManyAsync(occasions);
        return occasions;
    }
}