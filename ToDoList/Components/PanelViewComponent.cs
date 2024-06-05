using Microsoft.AspNetCore.Mvc;
using Services;
using ToDoList.Models;

namespace ToDoList.Components
{
    public class PanelViewComponent : ViewComponent
    {
        private readonly TodoListService _todoListService;


        public PanelViewComponent(TodoListService todoListService)
        {
            _todoListService = todoListService;

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<TodoListModel> todoLists = new List<TodoListModel>();
            var todoListDtos = _todoListService.GetAllTodoLists();
            foreach (var listDto in todoListDtos)
            {
                todoLists.Add(listDto.MapToModel());
            }

            return View(todoLists);
        }
    }
}
