using DTOs;

namespace ToDoList.Models
{
    public class TodoListModel
    {
        public int ListId { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public int CompletedTasks => Tasks.Count(x => x.IsComplete);

        public int TotalTasks => Tasks.Count;


        public List<TodoListTaskModel> Tasks { get; set; } = new();

    }
}
