﻿namespace backendapi.Core.Dtos.Applicant
{
    public class ApplicantCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        //public string CoverLetter { get; set; }
        public long PolicyId { get; set; }
    }
}
