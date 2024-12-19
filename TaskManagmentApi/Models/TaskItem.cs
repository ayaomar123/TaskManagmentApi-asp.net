using System.ComponentModel.DataAnnotations;

namespace TaskManagmentApi.Models
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; } // e.g., Pending, Completed
        public TaskPriority Priority { get; set; } // Updated to use enum
        public DateTime DueDate { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

    public enum TaskPriority
    {
        High = 1,
        Medium = 2,
        Low = 3
    }
}
