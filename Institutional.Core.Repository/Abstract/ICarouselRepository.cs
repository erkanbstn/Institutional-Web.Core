using Institutional.Core.Core.Models;
namespace Institutional.Core.Repository.Abstract
{
    public interface ICarouselRepository : IGenericRepository<Carousel>
    {
        Task<int> CarouselCount();
    }
}
