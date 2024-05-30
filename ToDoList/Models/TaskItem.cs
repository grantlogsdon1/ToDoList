namespace ToDoList.Models
{
    public class TaskItem
    {
        public int ListItemId { get; set; }

        public int ListId { get; set; }

        public string? Detail { get; set; }

        public bool IsComplete { get; set; }
    }
}
