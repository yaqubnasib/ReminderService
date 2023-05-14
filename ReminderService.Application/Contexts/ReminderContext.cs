using Microsoft.EntityFrameworkCore;
using ReminderService.Domain.Entities;
using System.Reflection;

namespace ReminderService.Application.Contexts
{
    public class ReminderContext : DbContext
    {
        public ReminderContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Reminder> Reminders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
