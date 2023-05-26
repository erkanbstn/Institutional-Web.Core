using Institutional.Core.Core.Models;
using Institutional.Core.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
namespace Institutional.Core.Repository.Concrete
{
    public class EFProductRepository : EFRepository<Product>, IProductRepository
    {
        private readonly AppDbContext _appDbContext;
        public EFProductRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Product>> GetProductListWithType(string Type)
        {
            return await _appDbContext.Products.Where(x => x.ShowType == Type).ToListAsync();
        }
    }
}
