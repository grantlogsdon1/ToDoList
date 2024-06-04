﻿using DTOs;
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

        public IActionResult Index(int istId)
        {
            if (istId == 0)
                istId = 1;

            TodoListDTO todoListDto = _todoListService.GetTodoList(istId);
            TodoListModel model = todoListDto.MapToModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateTask([FromBody] TodoListTaskModel task)
        {
            if (ModelState.IsValid)
            {
                TodoListTaskDTO taskDto = task.MapToDto();
                _todoListService.UpdateTodoListTask(taskDto);
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public IActionResult UpdateTodoListHeader(int listId, string name)
        {
            TodoListDTO listDto = new TodoListDTO()
            {
                ListId = listId,
                Name = name
            };
            _todoListService.UpdateTodoListHeader(listDto);
            return Json(new { success = true });
        }

        public IActionResult AddTask(int listId)
        {
            _todoListService.AddTask(listId);

            return RedirectToAction("Index", new { listId = listId });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}