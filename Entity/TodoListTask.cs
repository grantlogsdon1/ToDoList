using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class TodoListTask
    {
        [Key]
        public int TaskId { get; set; }

        [ForeignKey(nameof(TodoList))]
        public int ListId { get; set; }

        public string? Detail { get; set; }

        public bool IsComplete { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

        public TodoList TodoList { get; set; }
    }
}
