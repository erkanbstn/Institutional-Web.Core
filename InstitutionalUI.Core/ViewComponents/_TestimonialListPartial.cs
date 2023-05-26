using Institutional.Core.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace InstitutionalUI.Core.ViewComponents
{
    public class _TestimonialListPartial : ViewComponent
    {
        private readonly ITestimonialService _testimonialService;

        public _TestimonialListPartial(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _testimonialService.ToListByFilterAsync());
        }
    }
}
