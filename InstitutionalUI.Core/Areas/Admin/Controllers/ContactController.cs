using AutoMapper;
using Institutional.Core.Dto.Dtos.Contact;
using Institutional.Core.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InstitutionalUI.Core.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ContactController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IContactService _contactService;

        public ContactController(IMapper mapper, IContactService contactService)
        {
            _mapper = mapper;
            _contactService = contactService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.contactCount = await _contactService.ContactCount();
            var carouselList = _mapper.Map<List<ContactListDto>>(await _contactService.ToListAsync());
            return View(carouselList);
        }

        public async Task<IActionResult> EditContact(int id)
        {
            var contact = await _contactService.GetByIdAsync(id);
            return View(new ContactEditDto()
            {
                Id = contact.Id,
                Address = contact.Address,
                Email = contact.Email,
                MapLocation = contact.MapLocation,
                Phone = contact.Phone
            });
        }
        [HttpPost]
        public async Task<IActionResult> EditContact(ContactEditDto ContactEditDto)
        {
            var contact = await _contactService.GetByIdAsync(ContactEditDto.Id);
            contact.Address = ContactEditDto.Address;
            contact.Email = ContactEditDto.Email;
            contact.Phone = ContactEditDto.Phone;
            contact.MapLocation = ContactEditDto.MapLocation;
            await _contactService.UpdateAsync(contact);
            return Redirect("~/Admin/Contact/Index");
        }
    }
}
