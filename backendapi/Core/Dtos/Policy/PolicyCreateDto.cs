using backendapi.Core.Enums;

namespace backendapi.Core.Dtos.Policy
{
    public class PolicyCreateDto
    {
        public string Title { get; set; }
        public Duration Time { get; set; }
        public long CategoryId { get; set; }
    }
}
