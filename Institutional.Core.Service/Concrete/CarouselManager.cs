﻿using Institutional.Core.Core.Models;
using Institutional.Core.Repository.Abstract;
using Institutional.Core.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institutional.Core.Service.Concrete
{
    public class CarouselManager : ICarouselService
    {
        private readonly ICarouselRepository _CarouselRepository;

        public CarouselManager(ICarouselRepository CarouselRepository)
        {
            _CarouselRepository = CarouselRepository;
        }

        public async Task DeleteAsync(Carousel t)
        {
            await _CarouselRepository.DeleteAsync(t);
        }

        public async Task<Carousel> GetByIdAsync(Carousel t)
        {
            return await _CarouselRepository.GetByIdAsync(t);
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