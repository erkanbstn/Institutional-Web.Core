using Institutional.Core.Core.Models;
using Institutional.Core.Repository.Abstract;
using Institutional.Core.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<List<Testimonial>> ToListAsync()
        {
            return await _TestimonialRepository.ToListAsync();
        }

        public async Task UpdateAsync(Testimonial t)
        {
            await _TestimonialRepository.UpdateAsync(t);
        }
    }
}
