using Institutional.Core.Core.Models;
using Institutional.Core.Repository.Abstract;
namespace Institutional.Core.Repository.Concrete
{
	public class EFMessageRepository : EFRepository<Message>, IMessageRepository
	{
		public EFMessageRepository(AppDbContext appDbContext) : base(appDbContext)
		{
		}
	}
}
