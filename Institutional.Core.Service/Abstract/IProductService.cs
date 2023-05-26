using Institutional.Core.Core.Models;
namespace Institutional.Core.Service.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        Task<List<Product>> GetProductListWithType(string Type);
    }
}
