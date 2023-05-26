using Institutional.Core.Core.Models;
namespace Institutional.Core.Service.Abstract
{
    public interface IEventService : IGenericService<Event>
    {
        Task<int> EventCount();
    }
}
