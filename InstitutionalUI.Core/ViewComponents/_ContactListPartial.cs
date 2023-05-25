using Institutional.Core.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace InstitutionalUI.Core.ViewComponents
{
    public class _ContactListPartial:ViewComponent
    {
        private readonly IContactService _contactService;

        public _ContactListPartial(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _contactService.ToListAsync());
        }
    }
}
