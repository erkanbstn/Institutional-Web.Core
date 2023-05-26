using Institutional.Core.Core.Models;
using Institutional.Core.Repository.Abstract;
namespace Institutional.Core.Repository.Concrete
{
    public class EFContactRepository : EFRepository<Contact>, IContactRepository
    {
        public EFContactRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
