using System;
using System.Collections.Generic;

#nullable disable

namespace JobListingsAPI.Models
{
    public partial class TblApplicant
    {
        public int ApplicantId { get; set; }
        public string AppName { get; set; }
        public string AppSurname { get; set; }
        public string AppIdentityNumber { get; set; }
        public int AppYearsExperience { get; set; }
        public string AppEmail { get; set; }
        public int AppContactNumber { get; set; }
        public string AppLocation { get; set; }
        public DateTime AppDateCreated { get; set; }
        public DateTime? AppDateModified { get; set; }
    }
}
