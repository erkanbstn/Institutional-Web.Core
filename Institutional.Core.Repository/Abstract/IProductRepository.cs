using Institutional.Core.Core.Models;
namespace Institutional.Core.Repository.Abstract
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetProductListWithType(string Type);
        Task<int> ProductCount();
    }
}
