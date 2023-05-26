using Institutional.Core.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace InstitutionalUI.Core.ViewComponents
{
    public class _CarouselThumbnailListPartial : ViewComponent
    {
        private readonly ICarouselThumbnailService _carouselThumbnailService;

        public _CarouselThumbnailListPartial(ICarouselThumbnailService carouselThumbnailService)
        {
            _carouselThumbnailService = carouselThumbnailService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _carouselThumbnailService.ToListByFilterAsync());
        }
    }
}
