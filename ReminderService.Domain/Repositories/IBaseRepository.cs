using ReminderService.Domain.Entities;
using System.Linq.Expressions;

namespace ReminderService.Domain.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id, bool tracking = true);
        IQueryable<T> Where(Expression<Func<T, bool>> expression, bool tracking = true);
        IQueryable<T> GetAll(bool tracking = true);
        Task<bool> AddAsync(T entity);
        bool Update(T entity);
        bool Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        Task RemoveRangeAsync(ICollection<int> ids);
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
