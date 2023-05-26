using Institutional.Core.Core.Models;
using Institutional.Core.Repository.Abstract;
using Institutional.Core.Service.Abstract;
namespace Institutional.Core.Service.Concrete
{
    public class EventManager : IEventService
    {
        private readonly IEventRepository _EventRepository;

        public EventManager(IEventRepository EventRepository)
        {
            _EventRepository = EventRepository;
        }

        public async Task DeleteAsync(Event t)
        {
            await _EventRepository.DeleteAsync(t);
        }

        public async Task<int> EventCount()
        {
            return await _EventRepository.EventCount();
        }

        public async Task<Event> GetByIdAsync(int id)
        {
            return await _EventRepository.GetByIdAsync(id);
        }

        public async Task InsertAsync(Event t)
        {
            await _EventRepository.InsertAsync(t);
        }

        public async Task<List<Event>> ToListAsync()
        {
            return await _EventRepository.ToListAsync();
        }

        public async Task<List<Event>> ToListByFilterAsync()
        {
            return await _EventRepository.ToListByFilterAsync(b => b.Status == true);
        }

        public async Task UpdateAsync(Event t)
        {
            await _EventRepository.UpdateAsync(t);
        }
    }
}
