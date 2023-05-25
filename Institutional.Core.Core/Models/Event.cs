using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institutional.Core.Core.Models
{
    public class Event : BaseModel
    {
        public string BirthDayContent { get; set; }
        public string ConversationContent { get; set; }
        public string DinnerParty { get; set; }
    }
}
