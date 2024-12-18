using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using TaskManagmentApi.Data;
using TaskManagmentApi.Models;
using TaskManagmentApi.Models.Dto;
using TaskManagmentApi.Models.Resources;

namespace TaskManagmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public TasksController(ApplicationDbContext context)
        {
            _db = context;
        }

        [HttpGet]
        public  IActionResult GetTasks()
        {
            var tasks = _db.Tasks
                .Include(t => t.Category)
                .Select(t => new
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Status = t.Status,
                    Priority = t.Priority,
                    DueDate = t.DueDate,
                    CategoryId = t.Category.Id,
                    CategoryName = t.Category.Name
                }).
                ToList();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult Show(int id)
        {
            var task = _db.Tasks.Include(t => t.Category)
                .Select(t => new
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Status = t.Status,
                    Priority = t.Priority,
                    DueDate = t.DueDate,
                    CategoryId = t.Category.Id,
                    CategoryName = t.Category.Name
                }).FirstOrDefault();
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody] TaskDto taskDto)
        {
            var categoryExists = _db.Categories.Any(c => c.Id == taskDto.CategoryId);
            if (!categoryExists)
            {
                return NotFound($"Category with ID {taskDto.CategoryId} not found.");
            }

            // Map DTO to entity
            var task = new TaskItem
            {
                Title = taskDto.Title,
                Description = taskDto.Description,
                Status = taskDto.Status,
                Priority = taskDto.Priority,
                DueDate = taskDto.DueDate,
                CategoryId = taskDto.CategoryId
            };

            _db.Tasks.Add(task);
            _db.SaveChanges();

            return CreatedAtAction(nameof(Show), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TaskDto taskDto)
        {
            var task = _db.Tasks.Find(id);
            if (task == null) return NotFound("task not found.");
            
            var categoryExists = _db.Categories.Any(c => c.Id == taskDto.CategoryId);
            if (!categoryExists)
            {
                return NotFound($"Category with ID {taskDto.CategoryId} not found.");
            }

            task.Title = taskDto.Title;
            task.Description = taskDto.Description;
            task.Status = taskDto.Status;
            task.Priority = taskDto.Priority;
            task.DueDate = taskDto.DueDate;
            task.CategoryId = taskDto.CategoryId;
            _db.SaveChanges();


            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var task = _db.Tasks.Find(id);
            if (task == null)
                return NotFound();

            _db.Tasks.Remove(task);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
