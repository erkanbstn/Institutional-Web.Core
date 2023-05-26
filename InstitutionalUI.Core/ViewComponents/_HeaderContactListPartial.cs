using Institutional.Core.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace InstitutionalUI.Core.ViewComponents
{
    public class _HeaderContactListPartial : ViewComponent
    {
        private readonly IContactService _contactService;

        public _HeaderContactListPartial(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _contactService.ToListByFilterAsync());
        }
    }
}
