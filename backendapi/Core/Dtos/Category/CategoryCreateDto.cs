using backendapi.Core.Enums;

namespace backendapi.Core.Dtos.Category
{
    public class CategoryCreateDto
    {
        public string Name { get; set; }
        public PriorityLevel Level { get; set; }
    }
}
