using Microsoft.AspNetCore.Mvc;
using Services;

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
            return ViewComponent("Panel");
        }
    }
}
