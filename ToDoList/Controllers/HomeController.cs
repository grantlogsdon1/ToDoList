using DTOs;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Diagnostics;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TodoListService _todoListService;

        public HomeController(ILogger<HomeController> logger, TodoListService todoListService)
        {
            _logger = logger;
            _todoListService = todoListService;
        }

        public IActionResult Index(int id)
        {
            if (id == 0)
                id = 1;

            TodoListDTO todoListDto = _todoListService.GetTodoList(id);
            TodoListModel model = todoListDto.MapToModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult EditTask([FromBody] TodoListTaskModel task)
        {
            if (ModelState.IsValid)
            {
                TodoListTaskDTO taskDto = task.MapToDto();
                _todoListService.UpdateTodoListTask(taskDto);
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false});
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}