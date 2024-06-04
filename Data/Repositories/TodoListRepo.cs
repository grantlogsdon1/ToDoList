using Common;
using DTOs;
using Entity;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

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
                todoListDto = todoListEntity.MapToDto();
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
                foreach (var taskEntity in taskEntities)
                {
                    TodoListTaskDTO taskDTO = taskEntity.MapToDto();
                    todoListTasks.Add(taskDTO);
                }
            }

            return todoListTasks;
        }

        public void UpdateTodoListHeader(TodoListDTO todoListDTO)
        {
            var listEntity = _db.TodoList.Where(x => x.ListId == todoListDTO.ListId).FirstOrDefault();

            if (listEntity != null)
            {
                listEntity.Name = todoListDTO.Name;
            }

            _db.SaveChanges();
        }

        public void UpdateTodoListTask(TodoListTaskDTO taskDTO)
        {
            var taskEntity = _db.Tasks.Where(x => x.TaskId == taskDTO.TaskId).FirstOrDefault();

            if (taskEntity != null)
            {
                taskEntity.Detail = taskDTO.Detail;
                taskEntity.IsComplete = taskDTO.IsComplete;
            }

            _db.SaveChanges();
        }

        public void AddTask(int listId)
        {
            TodoListTask newTask = new TodoListTask()
            {
                ListId = listId,
                IsComplete = false
            };

            _db.Tasks.Add(newTask);
            _db.SaveChanges();
        }

        public void DeleteTask (int taskId)
        {
            var task = _db.Tasks.Where(x => x.TaskId == taskId).FirstOrDefault();
            if(task != null)
            {
                _db.Tasks.Remove(task);
            }
            _db.SaveChanges();
            _db.SaveChanges();
        }
    }
}
