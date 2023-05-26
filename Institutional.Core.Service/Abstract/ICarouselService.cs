using Institutional.Core.Core.Models;
namespace Institutional.Core.Service.Abstract
{
    public interface ICarouselService : IGenericService<Carousel>
    {
        Task<int> CarouselCount();
    }
}
