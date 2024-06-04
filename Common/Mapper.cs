using DTOs;
using Entity;

namespace Common
{
    public static class Mapper
    {
        public static TodoListDTO MapToDto(this TodoList entity)
        {
            TodoListDTO dto = new TodoListDTO();

            dto.ListId = entity.ListId;
            dto.Name = entity.Name;
            dto.CreatedDateTime = entity.CreatedDateTime;

            return dto;
        }

        public static TodoListTaskDTO MapToDto(this TodoListTask entity)
        {
            TodoListTaskDTO dto = new TodoListTaskDTO();

            dto.TaskId = entity.TaskId;
            dto.ListId = entity.ListId;
            dto.Detail = entity.Detail;
            dto.IsComplete = entity.IsComplete;
            dto.CreatedDateTime = entity.CreatedDateTime;

            return dto;
        }


    }
}
