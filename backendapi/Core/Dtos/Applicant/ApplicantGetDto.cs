namespace backendapi.Core.Dtos.Applicant
{
    public class ApplicantGetDto
    {
        public long ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        //public string CoverLetter { get; set; }
        public string ResumeUrl { get; set; }
        public long PolicyId { get; set; }
        public string PolicyTitle { get; set; }
    }
}
