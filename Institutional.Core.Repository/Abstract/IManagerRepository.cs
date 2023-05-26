using Institutional.Core.Core.Models;
namespace Institutional.Core.Repository.Abstract
{
    public interface IManagerRepository : IGenericRepository<Manager>
    {
        Task<Manager> SignInAsync(Manager manager);
    }
}
