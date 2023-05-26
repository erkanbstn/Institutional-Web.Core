using Institutional.Core.Core.Models;
namespace Institutional.Core.Repository.Abstract
{
    public interface ICarouselThumbnailRepository : IGenericRepository<CarouselThumbnail>
    {
        Task<int> CarouselThumbnailCount();

    }
}
