﻿using Institutional.Core.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Institutional.Core.Repository.Concrete
{
    public class EFRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _appDbContext;
        DbSet<T> _object;
        public EFRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _object = _appDbContext.Set<T>();
        }

        public async Task DeleteAsync(T t)
        {
            //_object.Remove(t);
            _object.Update(t);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _object.FindAsync(id);
        }

        public async Task InsertAsync(T t)
        {
            await _object.AddAsync(t);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<T>> ToListAsync()
        {
            return await _object.ToListAsync();
        }

        public async Task<List<T>> ToListByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _object.Where(filter).ToListAsync();
        }

        public async Task UpdateAsync(T t)
        {
            _object.Update(t);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
