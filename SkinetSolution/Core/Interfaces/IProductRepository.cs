using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        //signature of two methods, Async convention naming
        Task<Products> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Products>> GetProductsAsync();
    }
}
