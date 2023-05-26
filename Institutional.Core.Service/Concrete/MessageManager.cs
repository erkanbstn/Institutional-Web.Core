using Institutional.Core.Core.Models;
using Institutional.Core.Repository.Abstract;
using Institutional.Core.Service.Abstract;
namespace Institutional.Core.Service.Concrete
{
	public class MessageManager:IMessageService
	{
		private readonly IMessageRepository _MessageRepository;

		public MessageManager(IMessageRepository MessageRepository)
		{
			_MessageRepository = MessageRepository;
		}

		public async Task DeleteAsync(Message t)
		{
			await _MessageRepository.DeleteAsync(t);
		}

		public async Task<Message> GetByIdAsync(int id)
		{
			return await _MessageRepository.GetByIdAsync(id);
		}

		public async Task InsertAsync(Message t)
		{
			await _MessageRepository.InsertAsync(t);
		}

		public async Task<List<Message>> ToListAsync()
		{
			return await _MessageRepository.ToListAsync();
		}

		public async Task UpdateAsync(Message t)
		{
			await _MessageRepository.UpdateAsync(t);
		}
	}
}
