using System;
using System.Collections.Generic;

#nullable disable

namespace JobListingsAPI.Models
{
    public partial class ActionLog
    {
        public int LogId { get; set; }
        public string LogController { get; set; }
        public string LogAction { get; set; }
        public string LogNewValue { get; set; }
        public string LogOldValue { get; set; }
        public DateTime? LogDateTime { get; set; }
    }
}
