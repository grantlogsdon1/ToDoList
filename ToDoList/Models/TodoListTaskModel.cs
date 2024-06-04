namespace ToDoList.Models
{
    public class TodoListTaskModel
    {
        public int TaskId { get; set; }

        public int ListId { get; set; }

        public string? Detail { get; set; }

        public bool IsComplete { get; set; }

        public DateTime CreatedDateTime { get; set; }

    }
}
