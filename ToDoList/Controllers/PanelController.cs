using DTOs;
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
            return ViewComponent("Panel");
        }

        public IActionResult AddList()
        {
            _todoListService.AddTodoList();
            return RedirectToAction("Index", "Home");
        }
    }
}
