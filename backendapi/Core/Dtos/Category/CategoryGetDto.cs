using backendapi.Core.Enums;

namespace backendapi.Core.Dtos.Category
{
    public class CategoryGetDto
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public PriorityLevel Level { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
