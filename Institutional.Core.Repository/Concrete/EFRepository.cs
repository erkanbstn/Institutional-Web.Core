using Institutional.Core.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institutional.Core.Repository.Concrete
{
    public class EFRepository<T> : IGenericRepository<T> where T : class
    {
        public Task DeleteAsync(T t)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(T t)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(T t)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> ToListAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T t)
        {
            throw new NotImplementedException();
        }
    }
}
