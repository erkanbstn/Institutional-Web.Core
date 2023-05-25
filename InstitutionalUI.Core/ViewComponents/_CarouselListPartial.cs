using Institutional.Core.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace InstitutionalUI.Core.ViewComponents
{
    public class _CarouselListPartial : ViewComponent
    {
        private readonly ICarouselService _carouselService;

        public _CarouselListPartial(ICarouselService carouselService)
        {
            _carouselService = carouselService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _carouselService.ToListAsync());
        }
    }
}
