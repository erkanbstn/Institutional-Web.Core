using Institutional.Core.Core.Models;
namespace Institutional.Core.Repository.Abstract
{
    public interface IEventRepository : IGenericRepository<Event>
    {
        Task<int> EventCount();
    }
}
