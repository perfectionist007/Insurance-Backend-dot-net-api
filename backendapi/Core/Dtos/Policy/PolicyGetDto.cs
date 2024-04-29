using backendapi.Core.Entities;
using backendapi.Core.Enums;

namespace backendapi.Core.Dtos.Policy
{
    public class PolicyGetDto
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public Duration Time { get; set; }
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
