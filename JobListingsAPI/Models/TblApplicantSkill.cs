using System;
using System.Collections.Generic;

#nullable disable

namespace JobListingsAPI.Models
{
    public partial class TblApplicantSkill
    {
        public int AppSkillId { get; set; }
        public int ApplicantId { get; set; }
        public string AsName { get; set; }
        public DateTime AsCreatedDate { get; set; }
    }
}
