using Institutional.Core.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace InstitutionalUI.Core.ViewComponents
{
    public class _EventListPartial:ViewComponent
    {
        private readonly IEventService _eventService;

        public _EventListPartial(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _eventService.ToListByFilterAsync());
        }
    }
}
