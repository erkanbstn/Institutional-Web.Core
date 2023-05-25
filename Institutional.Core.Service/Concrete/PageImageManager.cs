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
    public class PageImageManager : IPageImageService
    {
        private readonly IPageImageRepository _PageImageRepository;

        public PageImageManager(IPageImageRepository PageImageRepository)
        {
            _PageImageRepository = PageImageRepository;
        }

        public async Task DeleteAsync(PageImage t)
        {
            await _PageImageRepository.DeleteAsync(t);
        }

        public async Task<PageImage> GetByIdAsync(PageImage t)
        {
            return await _PageImageRepository.GetByIdAsync(t);
        }

        public async Task InsertAsync(PageImage t)
        {
            await _PageImageRepository.InsertAsync(t);
        }

        public async Task<List<PageImage>> ToListAsync()
        {
            return await _PageImageRepository.ToListAsync();
        }

        public async Task UpdateAsync(PageImage t)
        {
            await _PageImageRepository.UpdateAsync(t);
        }
    }
}
