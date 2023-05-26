namespace Institutional.Core.Core.Models
{
    public class Contact : BaseModel
    {
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string MapLocation { get; set; }
    }
}
