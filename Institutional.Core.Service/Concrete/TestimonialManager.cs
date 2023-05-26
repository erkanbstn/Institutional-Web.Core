using Institutional.Core.Core.Models;
using Institutional.Core.Repository.Abstract;
using Institutional.Core.Service.Abstract;
namespace Institutional.Core.Service.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialRepository _TestimonialRepository;

        public TestimonialManager(ITestimonialRepository TestimonialRepository)
        {
            _TestimonialRepository = TestimonialRepository;
        }

        public async Task DeleteAsync(Testimonial t)
        {
            t.DeletedDate = DateTime.Now;
            t.Status = false;
            await _TestimonialRepository.DeleteAsync(t);
        }

        public async Task<Testimonial> GetByIdAsync(int id)
        {
            return await _TestimonialRepository.GetByIdAsync(id);
        }

        public async Task InsertAsync(Testimonial t)
        {
            await _TestimonialRepository.InsertAsync(t);
        }

        public async Task<int> TestimonialCount()
        {
            return await _TestimonialRepository.TestimonialCount();
        }

        public async Task<List<Testimonial>> ToListAsync()
        {
            return await _TestimonialRepository.ToListAsync();
        }

        public async Task<List<Testimonial>> ToListByFilterAsync()
        {
            return await _TestimonialRepository.ToListByFilterAsync(b => b.Status == true);
        }

        public async Task UpdateAsync(Testimonial t)
        {
            await _TestimonialRepository.UpdateAsync(t);
        }
    }
}
