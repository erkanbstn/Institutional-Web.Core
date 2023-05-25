using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institutional.Core.Core.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? DeletedDate { get; set; }
        public bool Status { get; set; } = true;
    }
}
