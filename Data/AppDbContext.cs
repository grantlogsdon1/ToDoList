using Entity;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TodoList> TodoList { get; set; }
        public DbSet<TodoListTask> Tasks { get; set; } 
    }
}
