﻿using Institutional.Core.Core.Models;
using Institutional.Core.Repository.Abstract;
using Institutional.Core.Repository.Concrete;
using Institutional.Core.Service.Abstract;
namespace Institutional.Core.Service.Concrete
{
    public class CarouselThumbnailManager : ICarouselThumbnailService
    {
        private readonly ICarouselThumbnailRepository _CarouselThumbnailRepository;

        public CarouselThumbnailManager(ICarouselThumbnailRepository CarouselThumbnailRepository)
        {
            _CarouselThumbnailRepository = CarouselThumbnailRepository;
        }

        public async Task<int> CarouselThumbnailCount()
        {
            return await _CarouselThumbnailRepository.CarouselThumbnailCount();
        }

        public async Task DeleteAsync(CarouselThumbnail t)
        {
            t.DeletedDate = DateTime.Now;
            t.Status = false;
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

        public async Task<List<CarouselThumbnail>> ToListByFilterAsync()
        {
            return await _CarouselThumbnailRepository.ToListByFilterAsync(b => b.Status == true);
        }

        public async Task UpdateAsync(CarouselThumbnail t)
        {
            await _CarouselThumbnailRepository.UpdateAsync(t);
        }
    }
}
