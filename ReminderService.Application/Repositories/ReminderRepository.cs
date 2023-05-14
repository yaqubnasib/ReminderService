using Microsoft.EntityFrameworkCore;
using ReminderService.Application.Contexts;
using ReminderService.Domain.Entities;
using ReminderService.Domain.Repositories;

namespace ReminderService.Application.Repositories
{
    public class ReminderRepository : BaseRepository<Reminder>, IReminderRepository
    {
        public ReminderRepository(ReminderContext context) : base(context)
        {
        }

        public IQueryable<Reminder> GetDueReminders(DateTime dueDate, bool tracking = true)
        {
            IQueryable<Reminder> query = Table.Where(x => x.SendAt == dueDate).AsQueryable();
            if (!tracking) query = query.AsNoTracking();

            return query;
        }
    }
}
