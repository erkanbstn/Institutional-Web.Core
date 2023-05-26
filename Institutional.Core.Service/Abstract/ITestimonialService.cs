using Institutional.Core.Core.Models;
namespace Institutional.Core.Service.Abstract
{
    public interface ITestimonialService : IGenericService<Testimonial>
    {
        Task<int> TestimonialCount();
    }
}
