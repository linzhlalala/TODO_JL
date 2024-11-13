using TodoBackend.Models;
using System.Collections.Generic;
using System.Linq;

namespace TodoBackend.Services
{
    public class TodoData
    {
        private static List<TodoTask> list_tasks = new List<TodoTask>();

        public TodoData()
        {
            // Mock data
            list_tasks = new List<TodoTask>
            {
                new TodoTask { Id = 1, Title = "Set a backend", IsCompleted = false },
                new TodoTask { Id = 2, Title = "Set a frondend", IsCompleted = false }
            };
        }

        // Get all todo items
        public List<TodoTask> GetAll() => list_tasks;

        // Get a todo item by id
        public TodoTask GetById(int id) => list_tasks.FirstOrDefault(t => t.Id == id);

        // Add a new todo item
        public void Add(TodoTask task)
        {
            task.Id = list_tasks.Count > 0 ? list_tasks.Max(t => t.Id) + 1 : 1;
            list_tasks.Add(task);
        }

        // Update an existing todo item
        public void Update(int id, TodoTask updatedItem)
        {
            var item = list_tasks.FirstOrDefault(t => t.Id == id);
            if (item != null)
            {
                item.Title = updatedItem.Title;
                item.IsCompleted = updatedItem.IsCompleted;
            }
        }

        // Delete a todo item
        public void Delete(int id)
        {
            var item = list_tasks.FirstOrDefault(t => t.Id == id);
            if (item != null)
            {
                list_tasks.Remove(item);
            }
        }
    }
}
