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
    public class CarouselThumbnailManager : ICarouselThumbnailService
    {
        private readonly ICarouselThumbnailRepository _CarouselThumbnailRepository;

        public CarouselThumbnailManager(ICarouselThumbnailRepository CarouselThumbnailRepository)
        {
            _CarouselThumbnailRepository = CarouselThumbnailRepository;
        }

        public async Task DeleteAsync(CarouselThumbnail t)
        {
            await _CarouselThumbnailRepository.DeleteAsync(t);
        }

        public async Task<CarouselThumbnail> GetByIdAsync(int id)
        {
            return await _CarouselThumbnailRepository.GetByIdAsync(id);
        }

        public async Task InsertAsync(CarouselThumbnail t)
        {
            await _CarouselThumbnailRepository.InsertAsync(t);
        }

        public async Task<List<CarouselThumbnail>> ToListAsync()
        {
            return await _CarouselThumbnailRepository.ToListAsync();
        }

        public async Task UpdateAsync(CarouselThumbnail t)
        {
            await _CarouselThumbnailRepository.UpdateAsync(t);
        }
    }
}
