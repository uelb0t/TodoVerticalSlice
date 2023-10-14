using Application.Features.Todo.CreateTodo;
using Application.Features.Todo.GetTodoById;
using Microsoft.AspNetCore.Mvc;

namespace Api.Features.Todo
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ICreateTodoHandler _createTodoHandler;
        private readonly IGetTodoByIdHandler _getTodoHandler;

        public TodoController(ICreateTodoHandler createTodoHandler, IGetTodoByIdHandler getTodoHandler)
        {
            _createTodoHandler = createTodoHandler;
            _getTodoHandler = getTodoHandler;
        }
        
        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var output = await _getTodoHandler.Handle(new GetTodoByIdInput(id));
            if (!output.Success)
                return NotFound(output);
            
            return Ok(output);
        }

        // POST: api/Todo
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTodoInput input)
        {
            var output = await _createTodoHandler.Handle(input);
            if (!output.Success)
                return BadRequest(output);
            
            return CreatedAtAction(nameof(Get), new { id = output.Id }, output);
        }
    }
}
