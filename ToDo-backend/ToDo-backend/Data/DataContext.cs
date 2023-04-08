global using Microsoft.EntityFrameworkCore;

namespace ToDo_backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<ToDo> ToDoList { get; set; }
        public DbSet<User> Users { get; set; }
    }


}
