using Institutional.Core.Core.Models;
using Institutional.Core.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institutional.Core.Repository.Concrete
{
    public class EFTestimonialRepository : EFRepository<Testimonial>, ITestimonialRepository
    {
        public EFTestimonialRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
