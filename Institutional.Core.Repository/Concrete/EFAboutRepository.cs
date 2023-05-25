using Institutional.Core.Core.Models;
using Institutional.Core.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institutional.Core.Repository.Concrete
{
    public class EFAboutRepository : EFRepository<About>, IAboutRepository
    {
        public EFAboutRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
