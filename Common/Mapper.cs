using DTOs;
using Entity;

namespace Common
{
    public static class Mapper
    {
        public static TodoListDTO Map(this TodoList entity)
        {
            TodoListDTO dto = new TodoListDTO();

            dto.ListId = entity.ListId;
            dto.Name = entity.Name;
            dto.CreatedDateTime = entity.CreatedDateTime;

            return dto;
        }

        public static TodoListTaskDTO Map(this TodoListTask entity)
        {
            TodoListTaskDTO dto = new TodoListTaskDTO();

            dto.ListItemId = entity.ListItemId;
            dto.ListId = entity.ListId;
            dto.Detail = entity.Detail;
            dto.IsComplete = entity.IsComplete;

            return dto;
        }
    }
}
