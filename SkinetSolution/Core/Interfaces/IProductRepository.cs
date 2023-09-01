using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        //signature of two methods, Async convention naming
        Task<Products> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Products>> GetProductsAsync();


        //////////////////////
        Task<IReadOnlyList<ProductBrand>> GetBrandsAsync();
        Task<ProductBrand> GetBrandByIdAsync(int id);

        Task<IReadOnlyList<ProductType>> GetProducTypeAsync();
        Task<ProductType> GetProductTypeByIdAsync(int id);
    }
}
