namespace Institutional.Core.Core.Models
{
    public class About : BaseModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string? BigImage { get; set; }
        public string? SmallImage { get; set; }
        public string ExperienceYear { get; set; }
        public string SockVariety { get; set; }
        public string Employee { get; set; }
        public string HappyCustomer { get; set; }
        public string ShowType { get; set; }
    }
}
