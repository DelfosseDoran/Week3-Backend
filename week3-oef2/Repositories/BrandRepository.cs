namespace week3_oef2.Repositories;
public interface IBrandRepository
{
    Task<List<Brand>> GetAllBrands();
    Task<Brand> GetBrandById(string id);
    Task<Brand> AddBrand(Brand brand);
    Task<List<Brand>> AddBrands(List<Brand> brands);
}
public class BrandRepository: IBrandRepository
{
    private readonly IMongoCollection<Brand> _brands;
    public BrandRepository(IMongoContext MongoContext)
    {
        _brands = MongoContext.BrandsCollection;
    }
    public async Task<List<Brand>> GetAllBrands()
    {
        return await _brands.Find(_ => true).ToListAsync();
    }
    public async Task<Brand> GetBrandById(string id)
    {
        return await _brands.Find(brand => brand.BrandId == id).FirstOrDefaultAsync();
    }
    public async Task<Brand> AddBrand(Brand brand)
    {
        await _brands.InsertOneAsync(brand);
        return brand;
    }
    public async Task<List<Brand>> AddBrands(List<Brand> brands)
    {
        await _brands.InsertManyAsync(brands);
        return brands;
    }
}