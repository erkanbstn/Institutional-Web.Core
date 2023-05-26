using Institutional.Core.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institutional.Core.Service.Abstract
{
    public interface IEventService : IGenericService<Event>
    {
        Task<int> EventCount();
    }
}
