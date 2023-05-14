using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ReminderService.Application.Contexts;
using ReminderService.Domain.Entities;
using ReminderService.Domain.Repositories;
using System.Linq.Expressions;

namespace ReminderService.Application.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly ReminderContext _context;

        public BaseRepository(ReminderContext context)
        {
            _context = context;
        }

        protected DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsyc(T entity)
        {
            EntityEntry<T> entry = await Table.AddAsync(entity);
            return entry.State == EntityState.Added;
        }

        public IQueryable<T> GetAll(bool tracking = true)
        {
            IQueryable<T> query = Table.AsQueryable();
            if (!tracking) query = query.AsNoTracking();

            return query;
        }

        public async Task<T> GetByIdAsync(int id, bool tracking = true)
        {
            IQueryable<T> query = Table.AsQueryable();
            if (!tracking) query = query.AsNoTracking();

            return await query?.FirstOrDefaultAsync(x => x.Id == id);
        }

        public bool Update(T entity)
        {
            EntityEntry<T> entry = Table.Update(entity);
            return entry.State == EntityState.Modified;
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression, bool tracking = true)
        {
            IQueryable<T> query = Table.AsQueryable();
            if (!tracking) query = query.AsNoTracking();

            IQueryable<T> result = query.Where(expression);
            return result;
        }

        public bool Remove(T entity)
        {
            EntityEntry<T> entry = Table.Remove(entity);
            return entry.State == EntityState.Deleted;
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            Table.RemoveRange(entities);
        }
    }
}
