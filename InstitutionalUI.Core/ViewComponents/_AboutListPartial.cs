using Institutional.Core.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace InstitutionalUI.Core.ViewComponents
{
    public class _AboutListPartial : ViewComponent
    {
        private readonly IAboutService _aboutService;

        public _AboutListPartial(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string Type)
        {
            return View(await _aboutService.GetAboutListWithType(Type));
        }
    }
}
