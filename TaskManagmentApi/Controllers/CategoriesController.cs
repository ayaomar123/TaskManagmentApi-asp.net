using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagmentApi.Data;
using TaskManagmentApi.Models;
using TaskManagmentApi.Models.Dto;
using TaskManagmentApi.Models.Resources;

namespace TaskManagmentApi.Controllers
{
    [Route("api/categories")]
    [ApiController]
    //[Authorize]

    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public CategoriesController(ApplicationDbContext context)
        {
            _db = context;
        }

        // GET: api/categories
        /*[HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Category> catgoeries = _db.Categories;
            //var ObjCategoryList = _db.Categories.ToList();
            return Ok(catgoeries);
        }*/

        [HttpGet]
        public ActionResult GetCategoriesWithTasks()
        {
            var categories =  _db.Categories
                .Include(c => c.Tasks)
                .Select(t => new {
                    Id = t.Id,
                    Name = t.Name,
                    Description = t.Description,
                    Tasks = t.Tasks.Select(t => new
                    {
                        Id = t.Id,
                        Title = t.Title,
                        Description = t.Description
                    })
                })
                .ToList();

            return Ok(categories);
        }


        [HttpGet("{id}")]
        public IActionResult Show(int id)
        {
            var category = _db.Categories
            .Include(c => c.Tasks)
            .Select(t => new {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                Tasks = t.Tasks.Select(t => new
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description
                })
            }).FirstOrDefault(c => c.Id == id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public IActionResult Store(CategoryDto categoryDto)
        {
            Category category = new();
            category.Name = categoryDto.Name;
            category.Description = categoryDto.Description;
            _db.Categories.Add(category);
            _db.SaveChanges();
            return CreatedAtAction(nameof(Show), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CategoryDto category)
        {
            var categorydb = _db.Categories.Find(id);
            if (categorydb == null) return NotFound("Category not found.");

            categorydb.Name = category.Name;
            categorydb.Description = category.Description;
            _db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _db.Categories .Include(c => c.Tasks).FirstOrDefault(c => c.Id == id);

            if (category == null)
                return NotFound("Category not found.");
            _db.Tasks.RemoveRange(category.Tasks);
            _db.Categories.Remove(category);
            _db.SaveChanges();

            return NoContent();
        }

    }
}
