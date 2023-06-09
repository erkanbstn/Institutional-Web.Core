﻿using Microsoft.AspNetCore.Http;
namespace Institutional.Core.Dto.Dtos.CarouselThumbnail
{
    public class CarouselThumbnailEditDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile Picture { get; set; }
        public bool Status { get; set; }
    }
}
