using Institutional.Core.Core.Models;
using Institutional.Core.Repository.Abstract;
using Institutional.Core.Service.Abstract;
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
            t.DeletedDate = DateTime.Now;
            t.Status = false;
            await _PageImageRepository.DeleteAsync(t);
        }

        public async Task<PageImage> GetByIdAsync(int id)
        {
            return await _PageImageRepository.GetByIdAsync(id);
        }

        public async Task<List<PageImage>> GetPageImageListWithType(string Type)
        {
            return await _PageImageRepository.GetPageImageListWithType(Type);
        }

        public async Task InsertAsync(PageImage t)
        {
            await _PageImageRepository.InsertAsync(t);
        }

        public async Task<int> PageImageCount()
        {
            return await _PageImageRepository.PageImageCount();
        }

        public async Task<List<PageImage>> ToListAsync()
        {
            return await _PageImageRepository.ToListAsync();
        }

        public async Task<List<PageImage>> ToListByFilterAsync()
        {
            return await _PageImageRepository.ToListByFilterAsync(b => b.Status == true);

        }

        public async Task UpdateAsync(PageImage t)
        {
            await _PageImageRepository.UpdateAsync(t);
        }
    }
}
