using AutoMapper;
using Institutional.Core.Dto.Dtos.PageImage;
using Institutional.Core.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace InstitutionalUI.Core.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PageImageController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFileProvider _fileProvider;
        private readonly IPageImageService _pageImageService;

        public PageImageController(IMapper mapper, IFileProvider fileProvider, IPageImageService pageImageService)
        {
            _mapper = mapper;
            _fileProvider = fileProvider;
            _pageImageService = pageImageService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.pageImageCount = await _pageImageService.PageImageCount();
            var carouselList = _mapper.Map<List<PageImageListDto>>(await _pageImageService.ToListAsync());
            return View(carouselList);
        }
        public async Task<IActionResult> DeletePageImage(int id)
        {
            await _pageImageService.DeleteAsync(await _pageImageService.GetByIdAsync(id));
            return Redirect("~/Admin/PageImage/Index");
        }
        public async Task<IActionResult> EditPageImage(int id)
        {
            var carousel = await _pageImageService.GetByIdAsync(id);
            return View(new PageImageEditDto()
            {
                Id = carousel.Id,
                ShowType = carousel.ShowType,
            });
        }
        [HttpPost]
        public async Task<IActionResult> EditPageImage(PageImageEditDto pageImageEditDto)
        {
            var pageImage = await _pageImageService.GetByIdAsync(pageImageEditDto.Id);
            pageImage.ShowType = pageImageEditDto.ShowType;
            if (pageImageEditDto.Picture != null && pageImageEditDto.Picture.Length > 0)
            {
                var wwwrootFolder = _fileProvider.GetDirectoryContents("wwwroot");
                var randomFileName = $"{Guid.NewGuid()}{Path.GetExtension(pageImageEditDto.Picture.FileName)}";
                var newPicturePath = Path.Combine(wwwrootFolder.First(b => b.Name == "Images").PhysicalPath, randomFileName);
                using var stream = new FileStream(newPicturePath, FileMode.Create);
                await pageImageEditDto.Picture.CopyToAsync(stream);
                pageImageEditDto.ImageUrl = randomFileName;
                pageImage.Image = pageImageEditDto.ImageUrl;
            }
            await _pageImageService.UpdateAsync(pageImage);
            return Redirect("~/Admin/PageImage/Index");
        }
    }
}
