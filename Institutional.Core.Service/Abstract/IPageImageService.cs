using Institutional.Core.Core.Models;
namespace Institutional.Core.Service.Abstract
{
    public interface IPageImageService : IGenericService<PageImage>
    {
        Task<List<PageImage>> GetPageImageListWithType(string Type);
        Task<int> PageImageCount();

    }
}
