using Microsoft.AspNetCore.Mvc;
using todoapi.Data;
using todoapi.Models;
using todoapi.Models.Enums;

namespace todoapi.Controllers
{
    [ApiController]
    [Route("api/todo")]
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
                Status = StatusType.Pending,
            };

            await dbContext.Todos.AddAsync(todo);
            await dbContext.SaveChangesAsync();

            return Ok(todo);

        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateTodo([FromRoute] Guid id)
        {
            var todo = await dbContext.Todos.FindAsync(id);
            if (todo != null)
            {
                todo.Status = todo.Status == StatusType.Completed ? StatusType.Pending : StatusType.Completed;
                
                await dbContext.SaveChangesAsync();
                return Ok(todo);

            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteTodo([FromRoute] Guid id)
        {
            var todo = await dbContext.Todos.FindAsync(id);
            if (todo != null)
            {
                dbContext.Todos.Remove(todo);
                await dbContext.SaveChangesAsync();
                return Ok(todo);
            }

            return NotFound();
        }

        }
    }
