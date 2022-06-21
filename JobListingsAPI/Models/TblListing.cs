using System;
using System.Collections.Generic;

#nullable disable

namespace JobListingsAPI.Models
{
    public partial class TblListing
    {
        public int ListingId { get; set; }
        public int CompanyId { get; set; }
        public string ListPositionName { get; set; }
        public int ListMinExperienceRequired { get; set; }
        public int ListMaxExperienceRequired { get; set; }
        public decimal? ListAnnualSalary { get; set; }
        public DateTime ListDateListed { get; set; }
        public DateTime? ListDateModified { get; set; }
    }
}
