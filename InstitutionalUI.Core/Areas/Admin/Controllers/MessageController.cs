using AutoMapper;
using Institutional.Core.Dto.Dtos.Message;
using Institutional.Core.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InstitutionalUI.Core.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MessageController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMessageService _MessageService;

        public MessageController(IMapper mapper, IMessageService MessageService)
        {
            _mapper = mapper;
            _MessageService = MessageService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.MessageCount = await _MessageService.MessageCount();
            var messageList = _mapper.Map<List<MessageListDto>>(await _MessageService.ToListByFilterAsync());
            return View(messageList);
        }
        public async Task<IActionResult> DetailMessage(int id)
        {
            var message = await _MessageService.GetByIdAsync(id);
            ViewBag.messageId = id;
            return View(new MessageListDto()
            {
                Id = message.Id,
                Content = message.Content,
                Email = message.Email,
                Name = message.Name,
                Date = message.Date
            });
        }
        public async Task<IActionResult> DeleteMessage(int id)
        {
            await _MessageService.DeleteAsync(await _MessageService.GetByIdAsync(id));
            return Redirect("~/Admin/Message/Index");
        }
        public async Task<IActionResult> DeleteAllMessage()
        {
            await _MessageService.DeleteAllMessages();
            return Redirect("~/Admin/Message/Index");
        }
    }
}
