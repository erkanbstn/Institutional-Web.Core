using Institutional.Core.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institutional.Core.Repository.Abstract
{
    public interface IManagerRepository : IGenericRepository<Manager>
    {
        Task<Manager> SignInAsync(Manager manager);
    }
}
