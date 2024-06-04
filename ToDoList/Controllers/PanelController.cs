using Microsoft.AspNetCore.Mvc;
using Services;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class PanelController : Controller
    {
        private readonly TodoListService _todoListService;

        public PanelController(TodoListService todoListService)
        {
            _todoListService = todoListService;
        }

        public IActionResult Index()
        {
            List<TodoListModel> todoLists = new List<TodoListModel>();
            var todoListDtos = _todoListService.GetAllTodoLists();
            foreach(var listDto in todoListDtos)
            {
                todoLists.Add(listDto.MapToModel());
            }

            return ViewComponent("PanelItems", new {todoLists});
        }
    }
}
