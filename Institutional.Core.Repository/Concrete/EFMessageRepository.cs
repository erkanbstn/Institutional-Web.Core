﻿using Institutional.Core.Core.Models;
using Institutional.Core.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institutional.Core.Repository.Concrete
{
	public class EFMessageRepository : EFRepository<Message>, IMessageRepository
	{
		public EFMessageRepository(AppDbContext appDbContext) : base(appDbContext)
		{
		}
	}
}