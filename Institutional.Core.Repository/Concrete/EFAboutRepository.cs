using Institutional.Core.Core.Models;
using Institutional.Core.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institutional.Core.Repository.Concrete
{
    public class EFAboutRepository : EFRepository<About>, IAboutRepository
    {
        private readonly AppDbContext _appDbContext;
        public EFAboutRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<About>> GetAboutListWithType(string Type)
        {
            return await _appDbContext.Abouts.Where(x => x.ShowType == Type).ToListAsync();
        }
    }
}
