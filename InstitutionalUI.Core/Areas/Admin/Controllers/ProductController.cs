using Microsoft.AspNetCore.Mvc;

namespace InstitutionalUI.Core.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
