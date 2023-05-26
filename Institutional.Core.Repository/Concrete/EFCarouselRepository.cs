using Institutional.Core.Core.Models;
using Institutional.Core.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
namespace Institutional.Core.Repository.Concrete
{
    public class EFCarouselRepository : EFRepository<Carousel>, ICarouselRepository
    {
        private readonly AppDbContext _appDbContext;
        public EFCarouselRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> CarouselCount()
        {
            return await _appDbContext.Carousels.CountAsync();
        }
    }
}
