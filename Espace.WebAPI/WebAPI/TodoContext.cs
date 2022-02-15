using Espace.Service.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Espace.WebAPI
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options) { }

        public DbSet<TodoItem> Todos => Set<TodoItem>();
    }
}