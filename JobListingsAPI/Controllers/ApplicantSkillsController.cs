using JobListingsAPI.Models;
using ListingsAPI;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobListingsAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApplicantSkillsController : ControllerBase
    {
        listingsUniversalCodeBase universal = new listingsUniversalCodeBase();
        [HttpGet]
        public IEnumerable<TblApplicantSkill> GetAll()
        {
            var context = new ListingsAPIDBContext();
            universal.logActivity("GET", "ApplicantSkillsController", DateTime.Now, "", "");
            return context.TblApplicantSkills.ToList();
        }

        [HttpGet("getSkillsByApplicant")]
        public List<TblApplicantSkill> GetSkillByApplicant(int ID)
        {
            var context = new ListingsAPIDBContext();

            var applicantskills = context.TblApplicants.Join(context.TblApplicantSkills, app => app.ApplicantId, appskill => appskill.ApplicantId, (app, appskill) => new { applicant = app, skills = appskill }).Where(x => x.applicant.ApplicantId == ID).ToList();

            universal.logActivity("GET", "ApplicantSkillsController", DateTime.Now, ID.ToString(), "");

            return applicantskills.Select(x => x.skills).ToList();
        }

        [HttpPost]
        public string addSkill(int applicantID, [FromBody] TblApplicantSkill skill)
        {
            var context = new ListingsAPIDBContext();

            var applicant = context.TblApplicants.Where(x => x.ApplicantId == applicantID).FirstOrDefault();
            if (applicant != null)
            {
                if (skill.AsName != "")
                {
                    skill.AsCreatedDate = DateTime.Now;
                    skill.AppSkillId = 0;
                    context.TblApplicantSkills.Add(skill);
                    context.SaveChanges();
                    universal.logActivity("POST", "ApplicantSkillsController", DateTime.Now, applicantID.ToString(), skill.ToString());
                }
            }
            return "";
        }

        [HttpDelete]
        public void deleteSkill(int skillID)
        {
            var context = new ListingsAPIDBContext();
            var skillEntryToDelete = context.TblApplicantSkills.Where(x => x.AppSkillId == skillID).FirstOrDefault();
            if(skillEntryToDelete != null)
            {
                context.TblApplicantSkills.Remove(skillEntryToDelete);
                context.SaveChanges();
                universal.logActivity("DELETE", "ApplicantSkillsController", DateTime.Now,skillID.ToString(),"");
            }
        }
    }
}
