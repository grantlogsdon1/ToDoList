using Common;
using DTOs;
using Entity;

namespace Data.Repositories
{
    public class TodoListRepo
    {
        AppDbContext _db;

        public TodoListRepo(AppDbContext db)
        {
            _db = db;
        }

        public TodoListDTO GetTodoList(int id)
        {
            TodoListDTO todoListDto = null;
            TodoList todoListEntity = _db.TodoList.Where(x => x.ListId == id).FirstOrDefault();

            if (todoListEntity != null)
            {
                todoListDto = todoListEntity.Map();
                todoListDto.Tasks = GetTodoListTasks(id);
            }
            
            return todoListDto;
        }

        public List<TodoListTaskDTO> GetTodoListTasks(int id)
        {
            List<TodoListTaskDTO> todoListTasks = new();

            List<TodoListTask> taskEntities = _db.Tasks.Where(x => x.ListId == id).ToList();

            if (taskEntities.Any())
            {
                foreach(var taskEntity in taskEntities)
                {
                    TodoListTaskDTO taskDTO = taskEntity.Map();
                    todoListTasks.Add(taskDTO);
                }
            }

            return todoListTasks;
        }
    }
}
