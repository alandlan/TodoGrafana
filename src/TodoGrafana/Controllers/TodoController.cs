using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoGrafana.Models;
using TodoGrafana.Services;

namespace TodoGrafana.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            this._todoService = todoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var todos = await _todoService.GetTodosAsync();
            return Ok(todos);
        }

        [HttpGet("{id:length(24)}", Name = "GetTodo")]
        public async Task<IActionResult> Get(string id)
        {
            var todo = await _todoService.GetTodoAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Todo todo)
        {
            await _todoService.CreateTodoAsync(todo);
            return CreatedAtRoute("GetTodo", new { id = todo.Id.ToString() }, todo);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Todo todoIn)
        {
            var todo = await _todoService.GetTodoAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            await _todoService.UpdateTodoAsync(id, todoIn);
            return NoContent();
        }
        
    }
}