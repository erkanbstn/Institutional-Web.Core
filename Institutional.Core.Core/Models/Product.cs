namespace Institutional.Core.Core.Models
{
    public class Product : BaseModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Detail { get; set; }
        public string? Detail2 { get; set; }
        public string Image { get; set; }
        public string ShowType { get; set; }
    }
}
