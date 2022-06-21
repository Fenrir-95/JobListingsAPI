using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobListingsAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobListingsAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RequiredSkillsController : ControllerBase
    {
        [HttpGet("GetAll")]
        public List<TblRequiredSkill> GetAll()
        {
            using (var context = new ListingsAPIDBContext())
            {
                return context.TblRequiredSkills.ToList();
            }
        }

        [HttpGet("GetByID")]
        public TblRequiredSkill Get(int id)
        {
            using (var context = new ListingsAPIDBContext())
            {
                var requiredSkillEntry = context.TblRequiredSkills.Where(x => x.ReqSkillId == id).FirstOrDefault();
                if(requiredSkillEntry != null)
                {
                    return requiredSkillEntry;
                }
                else
                {
                    return null;
                }
            }
        }


        [HttpPost]
        public string Post([FromBody] TblRequiredSkill reqSkillEntry)
        {
            using (var context = new ListingsAPIDBContext())
            {
                var requiredSkillEntry = context.TblRequiredSkills.Where(x => x.RsName.ToLower() == reqSkillEntry.RsName.ToLower() && x.ListingId == reqSkillEntry.ListingId).FirstOrDefault();
                if (requiredSkillEntry == null)
                {
                    reqSkillEntry.ReqSkillId = 0;
                    context.TblRequiredSkills.Add(reqSkillEntry);
                    context.SaveChanges();
                    return "Success Insert.";
                }
                else
                {
                    return "Entry For Listing Already exists.";
                }
            }
        }


        [HttpDelete]
        public string Delete(int id)
        {
            using (var context = new ListingsAPIDBContext())
            {
                var requiredSkillEntry = context.TblRequiredSkills.Where(x => x.ReqSkillId == id).FirstOrDefault();
                if (requiredSkillEntry != null)
                {
                    context.TblRequiredSkills.Remove(requiredSkillEntry);
                    context.SaveChanges();
                    return "Successful delete.";
                }
                else
                {
                    return "Entry not found.";
                }
            }
        }
    }
}
