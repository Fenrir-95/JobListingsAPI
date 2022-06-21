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
    public class ListingsController : ControllerBase
    {
        listingsUniversalCodeBase universal = new listingsUniversalCodeBase();

        [HttpGet]
        public TblListing Get()
        {
            return new TblListing();
        }

        [HttpGet("GetAll")]
        public List<TblListing> GetAll()
        {
            using (var context = new ListingsAPIDBContext())
            {
                universal.logActivity("GET", "ListingsController", DateTime.Now, "", "");
                return context.TblListings.ToList();
            }

        }

        [HttpGet("GetById")]
        public TblListing GetById(int id)
        {
            using (var context = new ListingsAPIDBContext())
            {
                universal.logActivity("GET", "ListingsController", DateTime.Now, id.ToString(), "");
                return context.TblListings.Where(x => x.ListingId == id).FirstOrDefault();
            }
        }

        [HttpPost("SubmitNewListing")]
        public void AddNewListing([FromBody] TblListing Listing)
        {
            using (var context = new ListingsAPIDBContext())
            {
                Listing.ListingId = 0;
                context.TblListings.Add(Listing);
                context.SaveChanges();

                universal.logActivity("POST", "ListingsController", DateTime.Now, Listing.ListingId.ToString(), "");
            }
        }

        [HttpPatch("UpdateListing")]
        public void UpdateListing(int id, [FromBody] TblListing Listing)
        {
            using (var context = new ListingsAPIDBContext())
            {
                var ListingEntry = context.TblListings.Where(x => x.ListingId == id).FirstOrDefault();
                if (ListingEntry != null)
                {
                    ListingEntry.ListPositionName = Listing.ListPositionName;
                    ListingEntry.ListMinExperienceRequired = Listing.ListMinExperienceRequired;
                    ListingEntry.ListMaxExperienceRequired = Listing.ListMaxExperienceRequired;
                    ListingEntry.CompanyId = Listing.CompanyId;
                    ListingEntry.ListAnnualSalary = Listing.ListAnnualSalary;

                    ListingEntry.ListDateModified = DateTime.Now;

                    context.SaveChanges();
                    universal.logActivity("PATCH", "ListingsController", DateTime.Now, ListingEntry.ListingId.ToString(), "");
                }

            }
        }

        [HttpDelete("DeleteListing")]
        public void Delete(int id)
        {
            using (var context = new ListingsAPIDBContext())
            {
                var ListingToDelete = context.TblListings.Where(x => x.ListingId == id).FirstOrDefault();
                context.TblListings.Remove(ListingToDelete);
                context.SaveChanges();

                universal.logActivity("DELETE", "ListingsController", DateTime.Now, id.ToString(), "");
            }
        }
    }
}
