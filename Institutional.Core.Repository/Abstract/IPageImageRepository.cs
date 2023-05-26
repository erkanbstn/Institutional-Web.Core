using Institutional.Core.Core.Models;
namespace Institutional.Core.Repository.Abstract
{
    public interface IPageImageRepository : IGenericRepository<PageImage>
    {
        Task<List<PageImage>> GetPageImageListWithType(string Type);
        Task<int> PageImageCount();
    }
}
