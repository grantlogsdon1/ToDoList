using Data.Repositories;
using DTOs;

namespace Services
{
    public class TodoListService
    {
        TodoListRepo _todoRepo;

        public TodoListService(TodoListRepo todoRepo)
        {
            _todoRepo = todoRepo;
        }

        public TodoListDTO GetTodoList(int id)
        {
            return _todoRepo.GetTodoList(id);
        }

        public void UpdateTodoListTask(TodoListTaskDTO todoListTaskDTO)
        {
            _todoRepo.UpdateTodoListTask(todoListTaskDTO);
        }
    }
}
