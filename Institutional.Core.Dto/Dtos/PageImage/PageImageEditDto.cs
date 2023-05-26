using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
