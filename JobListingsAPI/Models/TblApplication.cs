using System;
using System.Collections.Generic;

#nullable disable

namespace JobListingsAPI.Models
{
    public partial class TblApplication
    {
        public int ApplicationId { get; set; }
        public int ListingId { get; set; }
        public int ApplicantId { get; set; }
        public DateTime AppDateCreated { get; set; }
    }
}
