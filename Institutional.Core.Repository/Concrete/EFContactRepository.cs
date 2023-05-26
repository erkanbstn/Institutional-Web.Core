using Institutional.Core.Core.Models;
using Institutional.Core.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Institutional.Core.Repository.Concrete
{
    public class EFContactRepository : EFRepository<Contact>, IContactRepository
    {
        private readonly AppDbContext _appDbContext;
        public EFContactRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> ContactCount()
        {
            return await _appDbContext.Contacts.CountAsync();
        }
    }
}
