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

        public void AddTodoList()
        {
            TodoList newList = new TodoList();
            int countOfNewLists = GetCountOfNewList();
            if (countOfNewLists == 0)
                newList.Name = Constants.NEW_LIST_NAME;
            else
                newList.Name = $"{Constants.NEW_LIST_NAME} ({countOfNewLists})";


            _db.Add(newList);
            _db.SaveChanges();
        }

        public void DeleteTodoList(int listId)
        {
            TodoList todoList = _db.TodoList.Where(x => x.ListId == listId).FirstOrDefault();

            if (todoList != null)
            {
                _db.TodoList.Remove(todoList);
                _db.SaveChanges();
            }
        }

        private int GetCountOfNewList()
        {
            return _db.TodoList.Count(x => x.Name.Contains(Constants.NEW_LIST_NAME));
        }

        public List<TodoListDTO> GetAllTodoLists()
        {
            List<TodoListDTO> listDTOs = new List<TodoListDTO>();
            List<TodoList> listEntities = _db.TodoList.ToList();

            foreach (var entity in listEntities)
            {
                listDTOs.Add(entity.MapToDto());
            }

            return listDTOs;

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

        public TodoListDTO GetMostRecentTodoList()
        {
            TodoListDTO todoListDto = null;

            TodoList todoListEntity = _db.TodoList.OrderByDescending(x => x.CreatedDateTime).FirstOrDefault();
            if (todoListEntity != null)
            {
                todoListDto = todoListEntity.MapToDto();
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

        public void DeleteTask(int taskId)
        {
            var task = _db.Tasks.Where(x => x.TaskId == taskId).FirstOrDefault();
            if (task != null)
            {
                _db.Tasks.Remove(task);
            }
            _db.SaveChanges();
            _db.SaveChanges();
        }
    }
}
