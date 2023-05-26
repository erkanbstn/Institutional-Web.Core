using Institutional.Core.Core.Models;
namespace Institutional.Core.Service.Abstract
{
    public interface IAboutService : IGenericService<About>
    {
        Task<List<About>> GetAboutListWithType(string Type);
        Task<int> AboutCount();

    }
}
