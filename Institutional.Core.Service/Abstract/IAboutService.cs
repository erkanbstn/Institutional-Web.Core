using Institutional.Core.Core.Models;
using Institutional.Core.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institutional.Core.Service.Abstract
{
    public interface IAboutService : IGenericService<About>
    {
        Task<List<About>> GetAboutListWithType(string Type);
    }
}
