using System;


namespace week3.Repositories;
public interface IBrandRepository
{
    Task<Brand> AddBrand(Brand newBrand);
    Task<Brand> GetBrand(string id);
    Task<List<Brand>> GetAllBrands();
    Task<Brand> UpdateBrand(Brand brand);
    Task DeleteBrand(string id);
}
public class BrandRepository : IBrandRepository
{
    private readonly IMongoContext _context;
    public BrandRepository(IMongoContext context)
    {
        _context = context;
    }

    public async Task<Brand> AddBrand(Brand newBrand)
    {
        newBrand.CreatedOn = DateTime.Now;
        await _context.BrandsCollection.InsertOneAsync(newBrand);
        return newBrand;
    }
    public async Task<Brand> GetBrand(string id)
    {
        return await _context.BrandsCollection.Find(brand => brand.Id == id).FirstOrDefaultAsync();
    }
    public async Task<List<Brand>> GetAllBrands()
    {
        return await _context.BrandsCollection.Find(_ => true).ToListAsync();
    }
    public async Task<Brand> UpdateBrand(Brand brand)
    {
        Console.WriteLine(brand);
        var filter = Builders<Brand>.Filter.Eq(brand => brand.Id, brand.Id);
        var update = Builders<Brand>.Update
            .Set("Name", brand.Name)
            .Set("Country", brand.Country)
            .Set("Logo", brand.Logo)
            .Set("UpdatedOn", DateTime.Now);



        var result = await _context.BrandsCollection.UpdateOneAsync(filter, update);
        return brand;
        // _brands.ReplaceOne(brand => brand.Id == brand.Id, brand);
        // return brand;
    }
    public async Task DeleteBrand(string id)
    {
        await _context.BrandsCollection.DeleteOneAsync(brand => brand.Id == id);
        // _brands.DeleteOne(brand => brand.Id == id);
    }
}
