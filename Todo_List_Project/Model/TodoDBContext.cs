using Microsoft.EntityFrameworkCore;

namespace Todo_List_Project.Model
{
    public class TodoDBContext:DbContext
    {
        public TodoDBContext(DbContextOptions<TodoDBContext> options):base(options) 
        {
            

        }
        public DbSet<Todo> Todoslist { get; set; }
    }
}
