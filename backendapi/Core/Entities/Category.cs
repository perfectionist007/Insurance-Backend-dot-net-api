using backendapi.Core.Enums;

namespace backendapi.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public PriorityLevel Level{ get; set; }

        // Relations
        public ICollection<Policy> Policies { get; set; }
    }
}
