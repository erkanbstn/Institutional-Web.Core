namespace Institutional.Core.Core.Models
{
    public class Testimonial : BaseModel
    {
        public string Content { get; set; }
        public string Company { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }
    }
}
