using Institutional.Core.Core.Models;
using Institutional.Core.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
namespace Institutional.Core.Repository.Concrete
{
    public class EFAboutRepository : EFRepository<About>, IAboutRepository
    {
        private readonly AppDbContext _appDbContext;
        public EFAboutRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> AboutCount()
        {
            return await _appDbContext.Abouts.Where(x => x.Status == true).CountAsync();
        }

        public async Task<List<About>> GetAboutListWithType(string Type)
        {
            return await _appDbContext.Abouts.Where(x => x.ShowType == Type && x.Status == true).ToListAsync();
        }
    }
}
