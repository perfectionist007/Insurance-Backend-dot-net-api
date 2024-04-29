using backendapi.Core.Enums;

namespace backendapi.Core.Entities
{
    public class Policy : BaseEntity
    {
        public string Title { get; set; }
        public Duration Time{ get; set; }

        // Relations
        public long CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Applicant> Applicants { get; set; }
    }
}
