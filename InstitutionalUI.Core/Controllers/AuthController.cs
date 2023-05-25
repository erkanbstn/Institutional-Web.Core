using Institutional.Core.Core.Models;
using Institutional.Core.Service.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InstitutionalUI.Core.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly IManagerService _managerService;

        public AuthController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(Manager manager)
        {
            ViewBag.failure = null;
            var userAuth = await _managerService.SignInAsync(manager);
            if (userAuth == null)
            {
                ViewBag.failure = "Hatalı Kullanıcı Adı Veya Parola";
                return View();
            }
            await HttpContext.SignInAsync(await _managerService.SignInWithClaimAsync(manager));
            return RedirectToAction("Carousel", "Admin", new { area = "Admin" });
        }
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Main");
        }
    }
}
