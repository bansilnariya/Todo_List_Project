using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Todo_List_Project.Model
{
    public class TodoDBContext : DbContext
    {
        public TodoDBContext(DbContextOptions<TodoDBContext> options) : base(options)
        {


        }
        public DbSet<Todo> Todos { get; set; }


    }
    class test
    {
        public string Id { get; set; }
        public string    Name { get; set; }
    }
}
