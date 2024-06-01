using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class TodoList
    {
        [Key]
        public int ListId { get; set; }

        public string? Name { get; set; }

        public DateTime CreatedDateTime { get; set; }


        public List<TodoListTask>? Tasks { get; set; }
    }
}