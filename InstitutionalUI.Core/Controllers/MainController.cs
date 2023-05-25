using Microsoft.AspNetCore.Mvc;

namespace InstitutionalUI.Core.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
