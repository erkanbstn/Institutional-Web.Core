using Institutional.Core.Core.Models;
using Institutional.Core.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
namespace Institutional.Core.Repository.Concrete
{
    public class EFEventRepository : EFRepository<Event>, IEventRepository
    {
        private readonly AppDbContext _appDbContext;
        public EFEventRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> EventCount()
        {
            return await _appDbContext.Events.CountAsync();
        }
    }
}
