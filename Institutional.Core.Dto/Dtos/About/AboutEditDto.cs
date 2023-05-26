using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institutional.Core.Dto.Dtos.About
{
    public class AboutEditDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string BigImageUrl { get; set; }
        public string SmallImageUrl { get; set; }
        public IFormFile SmallPicture { get; set; }
        public IFormFile BigPicture { get; set; }
        public string ExperienceYear { get; set; }
        public string SockVariety { get; set; }
        public string Employee { get; set; }
        public string HappyCustomer { get; set; }
        public string ShowType { get; set; }
    }
}
