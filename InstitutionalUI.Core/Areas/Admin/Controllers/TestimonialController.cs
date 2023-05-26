using AutoMapper;
using Institutional.Core.Core.Models;
using Institutional.Core.Dto.Dtos.Carousel;
using Institutional.Core.Dto.Dtos.Testimonial;
using Institutional.Core.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace InstitutionalUI.Core.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TestimonialController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFileProvider _fileProvider;
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(IMapper mapper, IFileProvider fileProvider, ITestimonialService testimonialService)
        {
            _mapper = mapper;
            _fileProvider = fileProvider;
            _testimonialService = testimonialService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.testimonialCount = await _testimonialService.TestimonialCount();
            var carouselList = _mapper.Map<List<TestimonialListDto>>(await _testimonialService.ToListAsync());
            return View(carouselList);
        }
        public IActionResult NewTestimonial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewTestimonial(TestimonialAddDto testimonialAddDto)
        {
            if (testimonialAddDto.Picture != null && testimonialAddDto.Picture.Length > 0)
            {
                var wwwrootFolder = _fileProvider.GetDirectoryContents("wwwroot");
                var randomFileName = $"{Guid.NewGuid()}{Path.GetExtension(testimonialAddDto.Picture.FileName)}";
                var newPicturePath = Path.Combine(wwwrootFolder.First(b => b.Name == "Images").PhysicalPath, randomFileName);
                using var stream = new FileStream(newPicturePath, FileMode.Create);
                await testimonialAddDto.Picture.CopyToAsync(stream);
                testimonialAddDto.ImageUrl = randomFileName;
                await _testimonialService.InsertAsync(new Testimonial()
                {
                    Content = testimonialAddDto.Content,
                    Type = testimonialAddDto.Type,
                    Image = testimonialAddDto.ImageUrl,
                    Company = testimonialAddDto.Company,

                });
                return Redirect("~/Admin/Testimonial/Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _testimonialService.DeleteAsync(await _testimonialService.GetByIdAsync(id));
            return Redirect("~/Admin/Testimonial/Index");
        }
        public async Task<IActionResult> EditTestimonial(int id)
        {
            var testimonial = await _testimonialService.GetByIdAsync(id);
            return View(new TestimonialEditDto()
            {
                Id = testimonial.Id,
                Content = testimonial.Content,
                Type = testimonial.Type,
                Company = testimonial.Company,
            });
        }
        [HttpPost]
        public async Task<IActionResult> EditTestimonial(TestimonialEditDto testimonialEditDto)
        {
            var testimonial = await _testimonialService.GetByIdAsync(testimonialEditDto.Id);
            testimonial.Type = testimonialEditDto.Type;
            testimonial.Content = testimonialEditDto.Content;
            testimonial.Company=testimonialEditDto.Company;

            if (testimonialEditDto.Picture != null && testimonialEditDto.Picture.Length > 0)
            {
                var wwwrootFolder = _fileProvider.GetDirectoryContents("wwwroot");
                var randomFileName = $"{Guid.NewGuid()}{Path.GetExtension(testimonialEditDto.Picture.FileName)}";
                var newPicturePath = Path.Combine(wwwrootFolder.First(b => b.Name == "Images").PhysicalPath, randomFileName);
                using var stream = new FileStream(newPicturePath, FileMode.Create);
                await testimonialEditDto.Picture.CopyToAsync(stream);
                testimonialEditDto.ImageUrl = randomFileName;
                testimonial.Image = testimonialEditDto.ImageUrl;
            }
            await _testimonialService.UpdateAsync(testimonial);
            return Redirect("~/Admin/Testimonial/Index");
        }
    }
}
