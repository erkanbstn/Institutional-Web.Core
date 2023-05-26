using Microsoft.AspNetCore.Http;
namespace Institutional.Core.Dto.Dtos.PageImage
{
    public class PageImageEditDto
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
        public IFormFile Picture { get; set; }
        public string ShowType { get; set; }
    }
}
