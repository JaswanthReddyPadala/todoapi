using Microsoft.EntityFrameworkCore;
using todoapi.Models;

namespace todoapi.Data
{
    public class TodoListDbContext : DbContext
    {
        public TodoListDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }
    }
}
