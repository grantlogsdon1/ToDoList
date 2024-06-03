using Entity;

namespace DTOs
{
    public class TodoListDTO
    {
        public int ListId { get; set; }

        public string? Name { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public List<TodoListTaskDTO>? Tasks { get; set; } = new();
    }
}
