using DTOs;

namespace ToDoList.Models
{
    public class TodoListModel
    {
        public TodoListModel(ListDTO listDto)
        {
            //TODO move mapping to another class
            Name = listDto.ListHeader.Name;
            foreach(var task in listDto.Tasks)
            {
                TaskItem taskItem = new TaskItem();
                taskItem.ListItemId = task.ListItemId;
                taskItem.IsComplete = task.IsComplete;
                taskItem.Detail = task.Detail;
                Tasks.Add(taskItem);
            }
        }
        public string Name { get; set; }

        public List<TaskItem>? Tasks { get; set; }

    }
}
