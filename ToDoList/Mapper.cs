using DTOs;
using ToDoList.Models;

namespace ToDoList
{
    public static class Mapper
    {
        public static TodoListDTO MapToDto(this TodoListModel model)
        {
            TodoListDTO dto = new TodoListDTO();

            dto.ListId = model.ListId;
            dto.Name = model.Name;
            dto.CreatedDateTime = model.CreatedDateTime;

            foreach (TodoListTaskModel taskModel in model.Tasks)
            {
                TodoListTaskDTO taskDto = taskModel.MapToDto();
                dto.Tasks.Add(taskDto);
            }

            return dto;
        }

        public static TodoListModel MapToModel(this TodoListDTO dto)
        {
            TodoListModel model = new TodoListModel();

            model.ListId = dto.ListId;
            model.Name = dto.Name;
            model.CreatedDateTime = dto.CreatedDateTime;

            foreach (TodoListTaskDTO taskDto in dto.Tasks)
            {
                TodoListTaskModel taskModel = taskDto.MapToModel();
                model.Tasks.Add(taskModel);
            }

            return model;
        }

        public static TodoListTaskDTO MapToDto(this TodoListTaskModel model)
        {
            TodoListTaskDTO dto = new TodoListTaskDTO();

            dto.ListId = model.ListId;
            dto.ListItemId = model.ListItemId;
            dto.Detail = model.Detail;
            dto.IsComplete = model.IsComplete;

            return dto;
        }

        public static TodoListTaskModel MapToModel(this TodoListTaskDTO dto)
        {
            TodoListTaskModel model = new TodoListTaskModel();

            model.ListId = dto.ListId;
            model.ListItemId = dto.ListItemId;
            model.Detail = dto.Detail;
            model.IsComplete = dto.IsComplete;

            return model;
        }
    }
}
