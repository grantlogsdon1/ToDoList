using DTOs;

namespace ToDoList.Models
{
    public class TodoListModel
    {
        public TodoListModel(TodoListDTO listDto)
        {
            ListId = listDto.ListId;
            Name = listDto.Name;
            CreateDateTime = listDto.CreatedDateTime;

            foreach(var task in listDto.Tasks)
            {
                TodoListTaskModel taskItem = new TodoListTaskModel();
                taskItem.ListItemId = task.ListItemId;
                taskItem.ListId = task.ListId;
                taskItem.Detail = task.Detail;
                taskItem.IsComplete = task.IsComplete;
                Tasks.Add(taskItem);
            }
        }

        public int ListId { get; set; }
        public string? Name { get; set; }
        public DateTime CreateDateTime { get; set; }

        public List<TodoListTaskModel>? Tasks { get; set; } = new();

    }
}
