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
    public class EFTestimonialRepository : EFRepository<Testimonial>, ITestimonialRepository
    {
        private readonly AppDbContext _appDbContext;
        public EFTestimonialRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> TestimonialCount()
        {
            return await _appDbContext.Testimonials.CountAsync();
        }
    }
}
