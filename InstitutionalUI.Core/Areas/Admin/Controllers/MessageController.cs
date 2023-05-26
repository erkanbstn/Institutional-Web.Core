using Microsoft.AspNetCore.Mvc;

namespace InstitutionalUI.Core.Areas.Admin.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
