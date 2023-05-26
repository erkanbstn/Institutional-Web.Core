using Institutional.Core.Core.Models;
namespace Institutional.Core.Repository.Abstract
{
    public interface ITestimonialRepository : IGenericRepository<Testimonial>
    {
        Task<int> TestimonialCount();
    }
}
