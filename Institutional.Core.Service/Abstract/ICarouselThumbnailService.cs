using Institutional.Core.Core.Models;
namespace Institutional.Core.Service.Abstract
{
    public interface ICarouselThumbnailService : IGenericService<CarouselThumbnail>
    {
        Task<int> CarouselThumbnailCount();
    }
}
