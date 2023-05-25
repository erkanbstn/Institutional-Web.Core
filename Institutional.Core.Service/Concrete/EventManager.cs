﻿using Institutional.Core.Core.Models;
using Institutional.Core.Repository.Abstract;
using Institutional.Core.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<Event> GetByIdAsync(Event t)
        {
            return await _EventRepository.GetByIdAsync(t);
        }

        public async Task InsertAsync(Event t)
        {
            await _EventRepository.InsertAsync(t);
        }

        public async Task<List<Event>> ToListAsync()
        {
            return await _EventRepository.ToListAsync();
        }

        public async Task UpdateAsync(Event t)
        {
            await _EventRepository.UpdateAsync(t);
        }
    }
}
