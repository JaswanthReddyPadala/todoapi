using Microsoft.AspNetCore.Mvc;
using todoapi.Data;
using todoapi.Models;

namespace todoapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly TodoListDbContext dbContext;

        public TodoController(TodoListDbContext dbContext) {
            this.dbContext = dbContext;
        }

        //Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;
        [HttpGet]
        public IActionResult GetAllTodos()
        {
            return Ok(dbContext.Todos.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> AddTodo(AddTodoRequest addTodoRequest)
        {
            var todo = new Todo()
            {
                Id = Guid.NewGuid(),
                Description = addTodoRequest.Description,
                Status = addTodoRequest.Status,
            };

            await dbContext.Todos.AddAsync(todo);
            await dbContext.SaveChangesAsync();

            return Ok(todo);

        }

        [HttpDelete]

        }
    }
