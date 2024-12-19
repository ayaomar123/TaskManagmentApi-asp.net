namespace TaskManagmentApi.Models.Dto
{
    public class TaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; } // e.g., Pending, Completed
        public TaskPriority Priority { get; set; } // Updated to use enum
        public DateTime DueDate { get; set; }
        public int CategoryId { get; set; }
    }
}
