using Microsoft.AspNetCore.Mvc;

namespace InstitutionalUI.Core.Controllers
{
    public class MainController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> About()
        {
            return View();
        }
        public async Task<IActionResult> Product()
        {
            return View();
        }
        public async Task<IActionResult> Contact()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
        public async Task<IActionResult> SendMessage()
        {
            return RedirectToAction(nameof(MainController.Contact));
        }
    }
}
