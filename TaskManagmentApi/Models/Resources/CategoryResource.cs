using TaskManagmentApi.Models.Dto;

namespace TaskManagmentApi.Models.Resources
{
    public class CategoryResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<TaskResource> Tasks { get; set; }
    }
}
