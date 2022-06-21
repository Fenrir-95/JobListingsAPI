using System;
using System.Collections.Generic;

#nullable disable

namespace JobListingsAPI.Models
{
    public partial class TblRequiredSkill
    {
        public int ReqSkillId { get; set; }
        public int ListingId { get; set; }
        public string RsName { get; set; }
        public DateTime RsCreatedDate { get; set; }
    }
}
