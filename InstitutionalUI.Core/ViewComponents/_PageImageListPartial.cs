using Institutional.Core.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace InstitutionalUI.Core.ViewComponents
{
    public class _PageImageListPartial : ViewComponent
    {
        private readonly IPageImageService _pageImageService;

        public _PageImageListPartial(IPageImageService pageImageService)
        {
            _pageImageService = pageImageService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string Type)
        {
            ViewBag.Type = Type;
            return View(await _pageImageService.GetPageImageListWithType(Type));
        }
    }
}
