using System;


namespace week3.Repositories;
public interface IBrandRepository
{
    Brand AddBrand(Brand newBrand);
    Brand GetBrand(string id);
    List<Brand> GetAllBrands();
    Brand UpdateBrand(Brand brand);
}
public class BrandRepository : IBrandRepository
{
    private readonly IMongoCollection<Brand> _brands;
    public BrandRepository(IMongoContext context)
    {
        _brands = context.BrandsCollection;
    }

    public Brand AddBrand(Brand newBrand)
    {
        _brands.InsertOne(newBrand);
        return newBrand;
    }
    public Brand GetBrand(string id)
    {
        return _brands.Find(brand => brand.Id == id).FirstOrDefault();
    }
    public List<Brand> GetAllBrands()
    {
        return _brands.Find(brand => true).ToList();
    }
    public Brand UpdateBrand(Brand brand)
    {
        _brands.ReplaceOne(brand => brand.Id == brand.Id, brand);
        return brand;
    }
}
