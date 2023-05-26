using AutoMapper;
using Institutional.Core.Dto.Dtos.CarouselThumbnail;
using Institutional.Core.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace InstitutionalUI.Core.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CarouselThumbnailController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFileProvider _fileProvider;
        private readonly ICarouselThumbnailService _carouselThumbnailService;

        public CarouselThumbnailController(IMapper mapper, IFileProvider fileProvider, ICarouselThumbnailService carouselThumbnailService)
        {
            _mapper = mapper;
            _fileProvider = fileProvider;
            _carouselThumbnailService = carouselThumbnailService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.carouselThumbnailCount = await _carouselThumbnailService.CarouselThumbnailCount();
            var carouselList = _mapper.Map<List<CarouselThumbnailListDto>>(await _carouselThumbnailService.ToListAsync());
            return View(carouselList);
        }
        public async Task<IActionResult> DeleteCarouselThumbnail(int id)
        {
            await _carouselThumbnailService.DeleteAsync(await _carouselThumbnailService.GetByIdAsync(id));
            return Redirect("~/Admin/CarouselThumbnail/Index");
        }
        public async Task<IActionResult> EditCarouselThumbnail(int id)
        {
            var carousel = await _carouselThumbnailService.GetByIdAsync(id);
            return View(new CarouselThumbnailEditDto()
            {
                Id = carousel.Id,
                Title = carousel.Title,
                Content = carousel.Content,
            });
        }
        [HttpPost]
        public async Task<IActionResult> EditCarouselThumbnail(CarouselThumbnailEditDto carouselThumbnailEditDto)
        {
            var carousel = await _carouselThumbnailService.GetByIdAsync(carouselThumbnailEditDto.Id);
            carousel.Title = carouselThumbnailEditDto.Title;
            carousel.Content = carouselThumbnailEditDto.Content;
            if (carouselThumbnailEditDto.Picture != null && carouselThumbnailEditDto.Picture.Length > 0)
            {
                var wwwrootFolder = _fileProvider.GetDirectoryContents("wwwroot");
                var randomFileName = $"{Guid.NewGuid()}{Path.GetExtension(carouselThumbnailEditDto.Picture.FileName)}";
                var newPicturePath = Path.Combine(wwwrootFolder.First(b => b.Name == "Images").PhysicalPath, randomFileName);
                using var stream = new FileStream(newPicturePath, FileMode.Create);
                await carouselThumbnailEditDto.Picture.CopyToAsync(stream);
                carouselThumbnailEditDto.ImageUrl = randomFileName;
                carousel.Image = carouselThumbnailEditDto.ImageUrl;
            }
            await _carouselThumbnailService.UpdateAsync(carousel);
            return Redirect("~/Admin/CarouselThumbnail/Index");
        }
    }
}
