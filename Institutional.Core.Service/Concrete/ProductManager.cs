using Institutional.Core.Core.Models;
using Institutional.Core.Repository.Abstract;
using Institutional.Core.Service.Abstract;
namespace Institutional.Core.Service.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _ProductRepository;

        public ProductManager(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }

        public async Task DeleteAsync(Product t)
        {
            await _ProductRepository.DeleteAsync(t);
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _ProductRepository.GetByIdAsync(id);
        }

        public async Task<List<Product>> GetProductListWithType(string Type)
        {
            return await _ProductRepository.GetProductListWithType(Type);
        }

        public async Task InsertAsync(Product t)
        {
            await _ProductRepository.InsertAsync(t);
        }

        public async Task<int> ProductCount()
        {
             return await _ProductRepository.ProductCount();
        }

        public async Task<List<Product>> ToListAsync()
        {
            return await _ProductRepository.ToListAsync();
        }

        public async Task UpdateAsync(Product t)
        {
            await _ProductRepository.UpdateAsync(t);
        }
    }
}
