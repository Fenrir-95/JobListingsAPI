using JobListingsAPI.Models;
using ListingsAPI;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobListingsAPI.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        listingsUniversalCodeBase universal = new listingsUniversalCodeBase();
        [HttpGet]
        public TblApplication Get()
        {
            return new TblApplication();
        }

        [HttpGet("GetAll")]
        public List<TblApplication> GetAll()
        {
            using (var context = new ListingsAPIDBContext())
            {
                universal.logActivity("GET", "ApplicationController", DateTime.Now, "", "");
                return context.TblApplications.ToList();

            }
        }

        [HttpGet("GetById")]
        public TblApplication GetById(int id)
        {
            using (var context = new ListingsAPIDBContext())
            {

                universal.logActivity("GET", "ApplicationController", DateTime.Now, id.ToString(), "");
                return context.TblApplications.Where(x => x.ApplicationId == id).FirstOrDefault();
            }
        }

        [HttpPost("SubmitNewApplication")]
        public void AddNewApplication([FromBody] TblApplication application)
        {
            using (var context = new ListingsAPIDBContext())
            {
                application.ApplicationId = 0;
                context.TblApplications.Add(application);
                context.SaveChanges();

                universal.logActivity("POST", "ApplicationController", DateTime.Now, application.ApplicationId.ToString(), "");
            }
        }

        [HttpPatch("UpdateApplication")]
        public string UpdateApplication(int id, [FromBody] TblApplication application)
        {
            using (var context = new ListingsAPIDBContext())
            {
                var applicationEntry = context.TblApplications.Where(x => x.ApplicationId == id).FirstOrDefault();
                if (applicationEntry != null)
                {
                    applicationEntry.ApplicantId = application.ApplicantId;
                    applicationEntry.ListingId = application.ListingId;

                    context.SaveChanges();

                    universal.logActivity("PATCH", "ApplicationController", DateTime.Now, application.ApplicationId.ToString(), "");
                    return "Successful update.";
                }
                else
                {
                    return "Application Entry Not Found";
                }

            }
        }

        [HttpDelete("DeleteApplication")]
        public void Delete(int id)
        {
            using (var context = new ListingsAPIDBContext())
            {
                var applicationToDelete = context.TblApplications.Where(x => x.ApplicationId == id).FirstOrDefault();
                context.TblApplications.Remove(applicationToDelete);
                context.SaveChanges();

                universal.logActivity("DELETE", "ApplicationController", DateTime.Now, applicationToDelete.ApplicationId.ToString(), "");
            }
        }
    }
}
