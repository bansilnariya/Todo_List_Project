using System.ComponentModel.DataAnnotations;

namespace Todo_List_Project.Model
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        public string Task { get; set; }

        public bool IsComplete {  get; set; }
        public DateTime DateTime { get; set; }  


    }
}
