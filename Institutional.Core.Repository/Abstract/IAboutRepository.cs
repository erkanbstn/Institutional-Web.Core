using Institutional.Core.Core.Models;
namespace Institutional.Core.Repository.Abstract
{
    public interface IAboutRepository : IGenericRepository<About>
    {
        Task<List<About>> GetAboutListWithType(string Type);
        Task<int> AboutCount();
    }
}
