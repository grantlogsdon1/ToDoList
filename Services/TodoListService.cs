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

        public void UpdateTodoListHeader(TodoListDTO todoListDto)
        {
            _todoRepo.UpdateTodoListHeader(todoListDto);
        }

        public void UpdateTodoListTask(TodoListTaskDTO todoListTaskDTO)
        {
            _todoRepo.UpdateTodoListTask(todoListTaskDTO);
        }

        public void AddTask(int listId)
        {
            _todoRepo.AddTask(listId);
        }

        public void DeleteTask(int taskId)
        {
            _todoRepo.DeleteTask(taskId);
        }
    }
}
