using System.Data.Entity;

namespace TaskManager.Models
{
    public class TaskManagerContext : DbContext
    {
        public TaskManagerContext() : base("TaskManager")
        {
        }

        public DbSet<Task> Tasks { get; set; }
    }
}