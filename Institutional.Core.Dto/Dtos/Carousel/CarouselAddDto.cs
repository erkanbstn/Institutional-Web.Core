using Microsoft.AspNetCore.Http;
namespace Institutional.Core.Dto.Dtos.Carousel
{
    public class CarouselAddDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public IFormFile Picture { get; set; }
        public string ImageUrl { get; set; }
    }
}
