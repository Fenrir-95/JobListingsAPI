using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobListingsAPI.Models;
using ListingsAPI;

namespace JobListingsAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PossibleListingApplicantsController : ControllerBase
    {
        listingsUniversalCodeBase universal = new listingsUniversalCodeBase();
        [HttpGet]
        public List<PossibleApplicants> getPossibleApplicants()
        {
            List<PossibleApplicants> possibleApplicantList = new List<PossibleApplicants>();
            var context = new ListingsAPIDBContext();
            var Listings = context.TblListings.ToList();
            if (Listings.Count() > 0)
            {
                foreach (var listing in Listings)
                {
                    PossibleApplicants posApplicant = new PossibleApplicants();
                    posApplicant.listing = listing;
                    List<TblApplicant> matchingApplicants = new List<TblApplicant>();
                    var requiredSkills = context.TblRequiredSkills.Where(x => x.ListingId == listing.ListingId).ToList();
                    if (requiredSkills.Count() > 0)
                    {
                        var applicants = context.TblApplicants.Join(context.TblApplicantSkills, app => app.ApplicantId, skill => skill.ApplicantId, (app, skill) => new { applicant = app, skills = skill }).ToList();
                        var possibleApplicants = applicants.Where(x => listing.ListMinExperienceRequired <= x.applicant.AppYearsExperience && listing.ListMaxExperienceRequired >= x.applicant.AppYearsExperience).ToList();
                        var possibleSkillMatch = possibleApplicants.Where(x => requiredSkills.Select(y => y.RsName).Contains(x.skills.AsName)).ToList();

                        foreach (var posMatches in possibleSkillMatch.Select(x=>x.applicant).Distinct())
                        {
                            matchingApplicants.Add(posMatches);
                        }

                    }
                    posApplicant.possibleApplicants = matchingApplicants;
                    possibleApplicantList.Add(posApplicant);
                }

            }

            universal.logActivity("GET", "PossibleListingApplicantsController", DateTime.Now, "", "");
            return possibleApplicantList;
        }

    }
}
