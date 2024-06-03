namespace ToDoList.Models
{
    public class TodoListTaskModel
    {
        public int ListItemId { get; set; }

        public int ListId { get; set; }

        public string? Detail { get; set; }

        public bool IsComplete { get; set; }
    }
}
