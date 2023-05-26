using Microsoft.AspNetCore.Http;

namespace Institutional.Core.Dto.Dtos.Testimonial
{
    public class TestimonialAddDto
    {
        public string Content { get; set; }
        public string Company { get; set; }
        public string Type { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile Picture { get; set; }
    }
}
