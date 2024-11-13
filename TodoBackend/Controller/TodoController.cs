using Microsoft.AspNetCore.Mvc;
using TodoBackend.Models;
using TodoBackend.Services;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace TodoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoData _todoData;
        private readonly ILogger<TodoController> _logger;

        public TodoController(TodoData dataService, ILogger<TodoController> logger)
        {
            _todoData = dataService;
            _logger = logger;
        }


        // GET: api/todo
        [HttpGet]
        public ActionResult<IEnumerable<TodoTask>>Get()
        {
            List<TodoTask> data = _todoData.GetAll();
            _logger.LogInformation($"Return {data.Count} todos.");
            return Ok(data);
        }

        // GET: api/todo/x
        [HttpGet("{id}")]
        public ActionResult<TodoTask> Get(int id)
        {
            var todo = _todoData.GetById(id);
            if (todo == null)
            {
                return NotFound();
            }
            _logger.LogInformation($"Return {todo.Title}.");
            return Ok(todo);
        }

        // POST: api/todo
        [HttpPost]
        public ActionResult<TodoTask> Post([FromBody] TodoTask newTask)
        {
            _todoData.Add(newTask);
            _logger.LogInformation($"Add {newTask.Title}.");
            return CreatedAtAction(nameof(Get), new { id = newTask.Id }, newTask);
        }

        // PUT: api/todo/x
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TodoTask updatedTask)
        {
            var task = _todoData.GetById(id);
            if (task == null)
            {
                return NotFound();
            }
            _todoData.Update(id, updatedTask);
            _logger.LogInformation($"Update {updatedTask.Title}.");
            return NoContent();
        }

        // DELETE: api/todo/x
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var task = _todoData.GetById(id);
            if (task == null)
            {
                return NotFound();
            }
            _todoData.Delete(id);
            _logger.LogInformation($"Delete {task.Title}.");
            return NoContent();
        }
    }
}