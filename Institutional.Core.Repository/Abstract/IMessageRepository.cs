﻿using Institutional.Core.Core.Models;
namespace Institutional.Core.Repository.Abstract
{
	public interface IMessageRepository : IGenericRepository<Message>
	{
		Task<int> MessageCount();
		Task DeleteAllMessages();

    }
}
