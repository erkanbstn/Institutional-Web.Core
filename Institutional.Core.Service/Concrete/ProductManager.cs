using Institutional.Core.Core.Models;
using Institutional.Core.Repository.Abstract;
using Institutional.Core.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
