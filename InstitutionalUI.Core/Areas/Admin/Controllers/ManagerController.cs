using Institutional.Core.Core.Models;
using Institutional.Core.Dto.Dtos.Manager;
using Institutional.Core.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InstitutionalUI.Core.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ManagerController : Controller
    {
        private readonly IManagerService _managerService;

        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        public async Task<IActionResult> ChangePassword()
        {
            var user = await _managerService.GetByNameAsync(User.Identity.Name);
            return View(new ManagerEditDto()
            {
                Id = user.Id,
                UserName = user.UserName,
                Password = user.Password,
            });
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ManagerEditDto managerEditDto)
        {
            var user = await _managerService.GetByNameAsync(managerEditDto.UserName);
            user.UserName = managerEditDto.UserName;
            user.Password = managerEditDto.Password;
            await _managerService.UpdateAsync(user);
            ViewBag.success = "Parolanız Başarıyla Değiştirildi";
            return View();
        }

    }
}
