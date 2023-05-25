using Institutional.Core.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Institutional.Core.Service.Abstract
{
    public interface IManagerService : IGenericService<Manager>
    {
        Task<Manager> SignInAsync(Manager manager);
        Task<ClaimsPrincipal> SignInWithClaimAsync(Manager manager);
    }
}
