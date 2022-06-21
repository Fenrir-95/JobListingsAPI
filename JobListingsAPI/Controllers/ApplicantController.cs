using JobListingsAPI.Models;
using ListingsAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobListingsAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {

        listingsUniversalCodeBase universal = new listingsUniversalCodeBase();
        [HttpGet]
        public TblApplicant Get()
        {
            return new TblApplicant();
        }

        [HttpGet("GetAll")]
        public List<TblApplicant> GetAll()
        {
            using (var context = new ListingsAPIDBContext())
            {
                universal.logActivity("GET", "ApplicantController", DateTime.Now, "", "");
                return context.TblApplicants.ToList();
            }

        }

        [HttpGet("GetById")]
        public TblApplicant GetById(int id)
        {
            using (var context = new ListingsAPIDBContext())
            {
                universal.logActivity("GET", "ApplicantController", DateTime.Now, id.ToString(), "");
                return context.TblApplicants.Where(x => x.ApplicantId == id).FirstOrDefault();
            }
        }

        [HttpPost("SubmitNewApplicant")]
        public void AddNewApplicant([FromBody] TblApplicant applicant)
        {
            using (var context = new ListingsAPIDBContext())
            {
                applicant.ApplicantId = 0;
                context.TblApplicants.Add(applicant);
                context.SaveChanges();
                universal.logActivity("POST", "ApplicantController", DateTime.Now, applicant.ApplicantId.ToString(), "");
            }
        }

        [HttpPatch("UpdateApplicant")]
        public void UpdateApplicant(int id,[FromBody] TblApplicant applicant)
        {
            using (var context = new ListingsAPIDBContext())
            {
                var applicantEntry = context.TblApplicants.Where(x => x.ApplicantId == id).FirstOrDefault();
                if(applicantEntry != null)
                {
                    applicantEntry.AppName = applicant.AppName;
                    applicantEntry.AppSurname = applicant.AppSurname;
                    applicantEntry.AppIdentityNumber = applicant.AppIdentityNumber;
                    applicantEntry.AppYearsExperience = applicant.AppYearsExperience;
                    applicantEntry.AppEmail = applicant.AppEmail;
                    applicantEntry.AppContactNumber = applicant.AppContactNumber;
                    applicantEntry.AppLocation = applicant.AppLocation;
                    applicantEntry.AppDateModified = DateTime.Now;

                    context.SaveChanges();
                    universal.logActivity("PATCH", "ApplicantController", DateTime.Now, applicantEntry.ApplicantId.ToString(), "");
                }
                
            }
        }

        [HttpDelete("DeleteApplicant")]
        public void Delete(int id)
        {
            using (var context = new ListingsAPIDBContext())
            {
                var applicantToDelete = context.TblApplicants.Where(x => x.ApplicantId == id).FirstOrDefault();
                context.TblApplicants.Remove(applicantToDelete);
                context.SaveChanges();

                universal.logActivity("DELETE", "ApplicantController", DateTime.Now, applicantToDelete.ApplicantId.ToString(), "");
            }
        }
    }
}
