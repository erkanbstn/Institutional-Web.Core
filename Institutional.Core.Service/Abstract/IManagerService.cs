using Institutional.Core.Core.Models;
using System.Security.Claims;

namespace Institutional.Core.Service.Abstract
{
    public interface IManagerService : IGenericService<Manager>
    {
        Task<Manager> SignInAsync(Manager manager);
        Task<ClaimsPrincipal> SignInWithClaimAsync(Manager manager);
    }
}
