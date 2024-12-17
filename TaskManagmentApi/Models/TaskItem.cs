using System.ComponentModel.DataAnnotations;

namespace TaskManagmentApi.Models
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } // e.g., Pending, Completed
        public int Priority { get; set; } // 1: High, 2: Medium, 3: Low
        public DateTime DueDate { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
