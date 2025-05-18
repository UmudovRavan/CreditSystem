using CreditManagementSystemHomework.Data;
using CreditManagementSystemHomework.Entities;
using CreditManagementSystemHomework.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManagementSystemHomework.Repository.Implementation
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly CreditManagementDB _context;
        private readonly DbSet<TEntity> _dbSet;
        private CreditManagementDB context;

        public GenericRepository(CreditManagementDB context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            _dbSet.Remove(entity);
            return true;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var entities = await _dbSet.Where(e => !e.IsDeleted).AsNoTracking().ToListAsync();
            return entities;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _dbSet.Update(entity);
            return entity;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
