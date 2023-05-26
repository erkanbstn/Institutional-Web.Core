using Institutional.Core.Core.Models;
using Institutional.Core.Repository.Abstract;
using Institutional.Core.Service.Abstract;
namespace Institutional.Core.Service.Concrete
{
    public class CarouselManager : ICarouselService
    {
        private readonly ICarouselRepository _CarouselRepository;

        public CarouselManager(ICarouselRepository CarouselRepository)
        {
            _CarouselRepository = CarouselRepository;
        }

        public async Task<int> CarouselCount()
        {
            return await _CarouselRepository.CarouselCount();
        }

        public async Task DeleteAsync(Carousel t)
        {
            t.DeletedDate = DateTime.Now;
            t.Status = false;
            await _CarouselRepository.DeleteAsync(t);
        }

        public async Task<Carousel> GetByIdAsync(int id)
        {
            return await _CarouselRepository.GetByIdAsync(id);
        }

        public async Task InsertAsync(Carousel t)
        {
            await _CarouselRepository.InsertAsync(t);
        }

        public async Task<List<Carousel>> ToListAsync()
        {
            return await _CarouselRepository.ToListAsync();
        }

        public async Task UpdateAsync(Carousel t)
        {
            await _CarouselRepository.UpdateAsync(t);
        }
    }
}
