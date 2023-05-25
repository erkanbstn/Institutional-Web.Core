using Institutional.Core.Core.Models;
using Institutional.Core.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace InstitutionalUI.Core.Controllers
{
	public class MainController : Controller
	{
		private readonly IMessageService _messageService;

		public MainController(IMessageService messageService)
		{
			_messageService = messageService;
		}

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
		public async Task<IActionResult> Error()
		{
			return View();
		}
		public async Task<IActionResult> SendMessage(Message message)
		{
			await _messageService.InsertAsync(message);
			return RedirectToAction(nameof(MainController.Contact));
		}
	}
}
