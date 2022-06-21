using JobListingsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListingsAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CompanyController : Controller
    {
        [HttpGet("GET")]
        public TblCompany getDefault()
        {
            return new TblCompany();
        }

        [HttpGet("GetByID")]
        public IEnumerable<TblCompany> getByName(int ID)
        {
            using (var context = new ListingsAPIDBContext())
            {
                return context.TblCompanies.Where(x => x.CompanyId == ID).ToList();
            }
        }

        [HttpGet("GetByName")]
        public IEnumerable<TblCompany> getByName(string companyName)
        {
            using (var context = new ListingsAPIDBContext())
            {
                return context.TblCompanies.Where(x => x.CompName.ToLower() == companyName.ToLower()).ToList();
            }
        }

        [HttpPost("SubmitNewCompany")]
        public void AddNewCompany([FromBody] TblCompany Company)
        {
            using (var context = new ListingsAPIDBContext())
            {
                Company.CompanyId = 0;
                context.TblCompanies.Add(Company);
                context.SaveChanges();
            }
        }

        [HttpPatch("UpdateCompany")]
        public void UpdateCompany(int id, [FromBody] TblCompany company)
        {
            using (var context = new ListingsAPIDBContext())
            {
                var companyEntry = context.TblCompanies.Where(x => x.CompanyId == id).FirstOrDefault();
                if (companyEntry != null)
                {
                    companyEntry.CompName = company.CompName;
                    companyEntry.CompLocation = company.CompLocation;
                    companyEntry.CompDescription = company.CompDescription;
                    companyEntry.CompDateModified = DateTime.Now;

                    context.SaveChanges();
                }

            }
        }

        [HttpDelete("DeleteCompany")]
        public void DeleteCompany(int id)
        {
            using (var context = new ListingsAPIDBContext())
            {
                var CompanyToDelete = context.TblCompanies.Where(x => x.CompanyId == id).FirstOrDefault();
                if (CompanyToDelete != null)
                {
                    context.TblCompanies.Remove(CompanyToDelete);
                    context.SaveChanges();
                }
            }
        }
    }
}
