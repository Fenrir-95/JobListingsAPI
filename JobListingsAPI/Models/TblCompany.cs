using System;
using System.Collections.Generic;

#nullable disable

namespace JobListingsAPI.Models
{
    public partial class TblCompany
    {
        public int CompanyId { get; set; }
        public string CompName { get; set; }
        public string CompDescription { get; set; }
        public string CompLocation { get; set; }
        public DateTime CompDateCreated { get; set; }
        public DateTime? CompDateModified { get; set; }
    }
}
