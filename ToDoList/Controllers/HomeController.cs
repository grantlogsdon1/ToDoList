using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            TodoListModel model = new TodoListModel();
            model.Name = "Test1";
            model.Tasks = new List<TodoListTaskModel>()
            {
                new TodoListTaskModel()
                {
                    Detail = "test task 1"
                },
                new TodoListTaskModel()
                {
                    Detail = "test task 2"
                },
            };

            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}