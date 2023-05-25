using Institutional.Core.Core.Models;
using Institutional.Core.Repository.Abstract;
using Institutional.Core.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institutional.Core.Service.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactRepository _ContactRepository;

        public ContactManager(IContactRepository ContactRepository)
        {
            _ContactRepository = ContactRepository;
        }

        public async Task DeleteAsync(Contact t)
        {
            await _ContactRepository.DeleteAsync(t);
        }

        public async Task<Contact> GetByIdAsync(Contact t)
        {
            return await _ContactRepository.GetByIdAsync(t);
        }

        public async Task InsertAsync(Contact t)
        {
            await _ContactRepository.InsertAsync(t);
        }

        public async Task<List<Contact>> ToListAsync()
        {
            return await _ContactRepository.ToListAsync();
        }

        public async Task UpdateAsync(Contact t)
        {
            await _ContactRepository.UpdateAsync(t);
        }
    }
}
