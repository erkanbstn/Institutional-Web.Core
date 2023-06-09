﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institutional.Core.Dto.Dtos.About
{
    public class AboutListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string BigImage { get; set; }
        public string SmallImage { get; set; }
        public string ExperienceYear { get; set; }
        public string SockVariety { get; set; }
        public string Employee { get; set; }
        public string HappyCustomer { get; set; }
        public string ShowType { get; set; }
    }
}
