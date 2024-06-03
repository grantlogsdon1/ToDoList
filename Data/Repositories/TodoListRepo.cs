﻿using Common;
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

        public void UpdateTodoListTask(TodoListTaskDTO taskDTO)
        {
            var taskEntity = _db.Tasks.Where(x => x.ListItemId == taskDTO.ListItemId).FirstOrDefault();

            if (taskEntity != null)
            {
                taskEntity.Detail = taskDTO.Detail;
                taskEntity.IsComplete = taskDTO.IsComplete;
            }

            _db.SaveChanges();
        }
    }
}
