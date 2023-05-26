using AutoMapper;
using Institutional.Core.Core.Models;
using Institutional.Core.Dto.Dtos.About;
using Institutional.Core.Service.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace InstitutionalUI.Core.Areas.Admin.Controllers
{
    public class AboutController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFileProvider _fileProvider;
        private readonly IAboutService _AboutService;

        public AboutController(IAboutService AboutService, IFileProvider fileProvider, IMapper mapper)
        {
            _AboutService = AboutService;
            _fileProvider = fileProvider;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.AboutCount = await _AboutService.AboutCount();
            var AboutList = _mapper.Map<List<AboutListDto>>(await _AboutService.ToListAsync());
            return View(AboutList);
        }
        public async Task<IActionResult> EditAbout(int id)
        {
            var About = await _AboutService.GetByIdAsync(id);
            return View(new AboutEditDto()
            {
                Id = About.Id,
                Title = About.Title,
                Content = About.Content,
                Employee = About.Employee,
                ExperienceYear = About.ExperienceYear,
                HappyCustomer = About.HappyCustomer,
                SockVariety = About.SockVariety,
                ShowType = About.ShowType,
            });
        }
        [HttpPost]
        public async Task<IActionResult> EditAbout(AboutEditDto AboutEditDto)
        {
            var About = await _AboutService.GetByIdAsync(AboutEditDto.Id);
            About.Title = AboutEditDto.Title;
            About.Content = AboutEditDto.Content;
            About.Employee = AboutEditDto.Employee;
            About.ExperienceYear = AboutEditDto.ExperienceYear;
            About.HappyCustomer = AboutEditDto.HappyCustomer;
            About.SockVariety = AboutEditDto.SockVariety;
            About.ShowType = AboutEditDto.ShowType;
            if (AboutEditDto.SmallPicture != null && AboutEditDto.SmallPicture.Length > 0)
            {
                var wwwrootFolder = _fileProvider.GetDirectoryContents("wwwroot");
                var randomFileName = $"{Guid.NewGuid()}{Path.GetExtension(AboutEditDto.SmallPicture.FileName)}";
                var newPicturePath = Path.Combine(wwwrootFolder.First(b => b.Name == "Images").PhysicalPath, randomFileName);
                using var stream = new FileStream(newPicturePath, FileMode.Create);
                await AboutEditDto.SmallPicture.CopyToAsync(stream);
                AboutEditDto.SmallImageUrl = randomFileName;
                About.SmallImage = AboutEditDto.SmallImageUrl;
            }
            if (AboutEditDto.BigPicture != null && AboutEditDto.BigPicture.Length > 0)
            {
                var wwwrootFolder = _fileProvider.GetDirectoryContents("wwwroot");
                var randomFileName = $"{Guid.NewGuid()}{Path.GetExtension(AboutEditDto.BigPicture.FileName)}";
                var newPicturePath = Path.Combine(wwwrootFolder.First(b => b.Name == "Images").PhysicalPath, randomFileName);
                using var stream = new FileStream(newPicturePath, FileMode.Create);
                await AboutEditDto.BigPicture.CopyToAsync(stream);
                AboutEditDto.BigImageUrl = randomFileName;
                About.BigImage = AboutEditDto.BigImageUrl;
            }
            await _AboutService.UpdateAsync(About);
            return Redirect("~/Admin/About/Index");
        }
    }
}
