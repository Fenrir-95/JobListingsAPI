using JobListingsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListingsAPI
{
    public class PossibleApplicants
    {
        public TblListing listing { get; set; }
        public List<TblApplicant> possibleApplicants { get; set; }
    }
    public class listingsUniversalCodeBase
    {
        public void logActivity(string action, string controller, DateTime logdt, string newValue, string oldValue)
        {
            ActionLog al = new ActionLog();
            al.LogAction = action;
            al.LogController = controller;
            al.LogDateTime = logdt;
            al.LogNewValue = newValue;
            al.LogOldValue = oldValue;
        }
    }
}
