using Microsoft.AspNetCore.Http;
namespace Institutional.Core.Dto.Dtos.PageImage
{
    public class PageImageListDto
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
        public string ShowType { get; set; }
    }
}
