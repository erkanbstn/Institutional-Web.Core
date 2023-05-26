using AutoMapper;
using Institutional.Core.Dto.Dtos.Product;
using Institutional.Core.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace InstitutionalUI.Core.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFileProvider _fileProvider;
        private readonly IProductService _ProductService;

        public ProductController(IProductService ProductService, IFileProvider fileProvider, IMapper mapper)
        {
            _ProductService = ProductService;
            _fileProvider = fileProvider;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.ProductCount = await _ProductService.ProductCount();
            var ProductList = _mapper.Map<List<ProductListDto>>(await _ProductService.ToListAsync());
            return View(ProductList);
        }
        public async Task<IActionResult> EditProduct(int id)
        {
            var Product = await _ProductService.GetByIdAsync(id);
            return View(new ProductEditDto()
            {
                Id = Product.Id,
                Title = Product.Title,
                Content = Product.Content,
                Detail = Product.Detail,
                Detail2 = Product.Detail2,
                ShowType = Product.ShowType,
            });
        }
        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductEditDto ProductEditDto)
        {
            var Product = await _ProductService.GetByIdAsync(ProductEditDto.Id);
            Product.Title = ProductEditDto.Title;
            Product.Content = ProductEditDto.Content;
            Product.Detail = ProductEditDto.Detail;
            Product.Detail2 = ProductEditDto.Detail2;
            Product.ShowType = ProductEditDto.ShowType;
            if (ProductEditDto.Picture != null && ProductEditDto.Picture.Length > 0)
            {
                var wwwrootFolder = _fileProvider.GetDirectoryContents("wwwroot");
                var randomFileName = $"{Guid.NewGuid()}{Path.GetExtension(ProductEditDto.Picture.FileName)}";
                var newPicturePath = Path.Combine(wwwrootFolder.First(b => b.Name == "Images").PhysicalPath, randomFileName);
                using var stream = new FileStream(newPicturePath, FileMode.Create);
                await ProductEditDto.Picture.CopyToAsync(stream);
                ProductEditDto.ImageUrl = randomFileName;
                Product.Image = ProductEditDto.ImageUrl;
            }
            await _ProductService.UpdateAsync(Product);
            return Redirect("~/Admin/Product/Index");
        }
    }
}
