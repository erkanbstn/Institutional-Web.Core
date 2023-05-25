using Institutional.Core.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace InstitutionalUI.Core.ViewComponents
{
    public class _MainProductListPartial:ViewComponent
    {
        private readonly IProductService _productService;

        public _MainProductListPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string Type)
        {
            return View(await _productService.GetProductListWithType(Type));
        }
    }
}
