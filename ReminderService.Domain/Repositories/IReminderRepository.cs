using ReminderService.Domain.Entities;
using System.Diagnostics;

namespace ReminderService.Domain.Repositories
{
    public interface IReminderRepository : IBaseRepository<Reminder>
    {
        IQueryable<Reminder> GetDueReminders(DateTime dueDate, bool tracking = true);
    }
}
