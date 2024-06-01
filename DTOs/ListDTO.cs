using Entity;

namespace DTOs
{
    public class ListDTO
    {
        public TodoList ListHeader { get; set; }

        public List<TodoListTask>? Tasks { get; set; }
    }
}
