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
    public class EFPageImageRepository : EFRepository<PageImage>, IPageImageRepository
    {
        private readonly AppDbContext _appDbContext;
        public EFPageImageRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<PageImage>> GetPageImageListWithType(string Type)
        {
            return await _appDbContext.PageImages.Where(x => x.ShowType == Type).ToListAsync();
        }
    }
}
