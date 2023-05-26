using Institutional.Core.Core.Models;
using Institutional.Core.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Institutional.Core.Repository.Concrete
{
    public class EFMessageRepository : EFRepository<Message>, IMessageRepository
    {
        private readonly AppDbContext _appDbContext;
        public EFMessageRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task DeleteAllMessages()
        {
            var allMessages = await _appDbContext.Messages.ToListAsync();
            _appDbContext.RemoveRange(allMessages);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<int> MessageCount()
        {
            return await _appDbContext.Messages.Where(x => x.Status == true).CountAsync();
        }

        public async Task<List<Message>> ToListByStatusAsync()
        {
            return await _appDbContext.Messages.Where(x => x.Status == true).ToListAsync();
        }
    }
}
