namespace Institutional.Core.Core.Models
{
    public class Message : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
