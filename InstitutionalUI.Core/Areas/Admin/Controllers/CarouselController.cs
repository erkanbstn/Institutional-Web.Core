using AutoMapper;
using Institutional.Core.Core.Models;
using Institutional.Core.Dto.Dtos;
using Institutional.Core.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Security.Claims;

namespace InstitutionalUI.Core.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CarouselController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFileProvider _fileProvider;
        private readonly ICarouselService _carouselService;

        public CarouselController(ICarouselService carouselService, IFileProvider fileProvider, IMapper mapper)
        {
            _carouselService = carouselService;
            _fileProvider = fileProvider;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.carouselCount = await _carouselService.CarouselCount();
            var carouselList = _mapper.Map<List<CarouselListDto>>(await _carouselService.ToListAsync());
            return View(carouselList);
        }
        public IActionResult NewCarousel()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewCarousel(CarouselAddDto carouselAddDto)
        {
            if (carouselAddDto.Picture != null && carouselAddDto.Picture.Length > 0)
            {
                var wwwrootFolder = _fileProvider.GetDirectoryContents("wwwroot");
                var randomFileName = $"{Guid.NewGuid()}{Path.GetExtension(carouselAddDto.Picture.FileName)}";
                var newPicturePath = Path.Combine(wwwrootFolder.First(b => b.Name == "Images").PhysicalPath, randomFileName);
                using var stream = new FileStream(newPicturePath, FileMode.Create);
                await carouselAddDto.Picture.CopyToAsync(stream);
                carouselAddDto.ImageUrl = randomFileName;
                await _carouselService.InsertAsync(new Carousel()
                {
                    Content = carouselAddDto.Content,
                    Title = carouselAddDto.Title,
                    Image = carouselAddDto.ImageUrl
                });
                return Redirect("~/Admin/Carousel/Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteCarousel(int id)
        {
            await _carouselService.DeleteAsync(await _carouselService.GetByIdAsync(id));
            return Redirect("~/Admin/Carousel/Index");
        }
        public async Task<IActionResult> EditCarousel(int id)
        {
            var carousel = await _carouselService.GetByIdAsync(id);
            return View(new CarouselEditDto()
            {
                Id = carousel.Id,
                Title = carousel.Title,
                Content = carousel.Content,
            });
        }
        [HttpPost]
        public async Task<IActionResult> EditCarousel(CarouselEditDto carouselEditDto)
        {
            var carousel = await _carouselService.GetByIdAsync(carouselEditDto.Id);
            carousel.Title = carouselEditDto.Title;
            carousel.Content = carouselEditDto.Content;
            if (carouselEditDto.Picture != null && carouselEditDto.Picture.Length > 0)
            {
                var wwwrootFolder = _fileProvider.GetDirectoryContents("wwwroot");
                var randomFileName = $"{Guid.NewGuid()}{Path.GetExtension(carouselEditDto.Picture.FileName)}";
                var newPicturePath = Path.Combine(wwwrootFolder.First(b => b.Name == "Images").PhysicalPath, randomFileName);
                using var stream = new FileStream(newPicturePath, FileMode.Create);
                await carouselEditDto.Picture.CopyToAsync(stream);
                carouselEditDto.ImageUrl = randomFileName;
                carousel.Image = carouselEditDto.ImageUrl;
            }
            await _carouselService.UpdateAsync(carousel);
            return Redirect("~/Admin/Carousel/Index");
        }
    }
}
