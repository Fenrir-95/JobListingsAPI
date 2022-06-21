using System;
using System.Collections.Generic;

#nullable disable

namespace JobListingsAPI.Models
{
    public partial class TblErrorLog
    {
        public int LogId { get; set; }
        public string Controller { get; set; }
        public string ExceptionMessage { get; set; }
        public string StackTrace { get; set; }
        public DateTime ErrorDate { get; set; }
    }
}
