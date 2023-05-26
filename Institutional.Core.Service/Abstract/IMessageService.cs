using Institutional.Core.Core.Models;
namespace Institutional.Core.Service.Abstract
{
	public interface IMessageService : IGenericService<Message>
	{
		Task<int> MessageCount();
        Task<List<Message>> ToListByStatusAsync();
        Task DeleteAllMessages();
    }
}
